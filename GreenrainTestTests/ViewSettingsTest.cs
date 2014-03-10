using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WindowsFormsApplication1.Presenter;
using WindowsFormsApplication1.View;
using WindowsFormsApplication1.Model;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GreenrainTestTests
{
    [TestClass]
    public class ViewSettingsTest
    {
        Button savesettings;
        Button cancelsettings;
        TextBox user;
        TextBox password;
        TextBox server;
        TextBox dbname;
        ComboBox integrsec;

        private void PrepareControls(ViewSettings view)
        {
            savesettings = GUITester.FindControl<Button>(view, "button_ok");
            cancelsettings = GUITester.FindControl<Button>(view, "button_cancel");
            user = GUITester.FindControl<TextBox>(view, "bd_user");
            password = GUITester.FindControl<TextBox>(view, "bd_pass");
            server = GUITester.FindControl<TextBox>(view, "bd_server");
            dbname = GUITester.FindControl<TextBox>(view, "bd_name");
            integrsec = GUITester.FindControl<ComboBox>(view, "bd_is");
        }

        private static class GUITester
        {
            public static T FindControl<T>(Control container, string name)
                  where T : Control
            {
                if (container is T && container.Name == name)
                    return container as T;
                if (container.Controls.Count == 0)
                    return null;
                foreach (Control child in container.Controls)
                {
                    Control control = FindControl<T>(child, name);
                    if (control != null)
                        return control as T;
                }
                return null;
            }
        }

        [TestMethod]
        public void LoadConnectionStringToView()
        {
            Mock<IModelSettings> model = new Mock<IModelSettings>();
            string ConnectionString = "Server=localhost;Integrated Security=true;Database=NORTHWND;User Id=sa;Password=";
            model.Setup(m => m.LoadConnectionStringFromConfig(It.IsAny<string>())).Returns(ConnectionString);
            ISettingsPresenter presenter = new SettingsPresenter(model.Object, new DialogService());
            ViewSettings view = new ViewSettings(presenter);
            PrepareControls(view);

            //verify loading connection string to view
            Assert.AreEqual(user.Text, "sa");
            Assert.AreEqual(password.Text, "");
            Assert.AreEqual(server.Text, "localhost");
            Assert.AreEqual(dbname.Text, "NORTHWND");
            Assert.AreEqual(integrsec.SelectedItem.ToString(), "true");
        }

        [TestMethod]
        public void LoadNullConnectionStringToView()
        {
            Mock<IModelSettings> model = new Mock<IModelSettings>();
            string ConnectionString = null;
            model.Setup(m => m.LoadConnectionStringFromConfig(It.IsAny<string>())).Returns(ConnectionString);
            ISettingsPresenter presenter = new SettingsPresenter(model.Object, new DialogService());
            ViewSettings view = new ViewSettings(presenter);
            PrepareControls(view);

            //verify loading connection string to view
            Assert.AreEqual(user.Text, "");
            Assert.AreEqual(password.Text, "");
            Assert.AreEqual(server.Text, "");
            Assert.AreEqual(dbname.Text, "");
            Assert.AreEqual(integrsec.SelectedItem.ToString(), "false");
        }

        [TestMethod]
        public void SaveConnectionStringFromView()
        {
            Mock<IModelSettings> model = new Mock<IModelSettings>();
            model.Setup(m => m.SaveConnectionStringToConfig(It.IsAny<string>(), It.IsAny<string>()));
            string ConnectionString = "Server=localhost;Integrated Security=true;Database=NORTHWND;User Id=sa;Password=";
            model.Setup(m => m.LoadConnectionStringFromConfig(It.IsAny<string>())).Returns(ConnectionString);
            Mock<IDialogService> dialog = new Mock<IDialogService>();
            ISettingsPresenter presenter = new SettingsPresenter(model.Object, dialog.Object);
            ViewSettings view = new ViewSettings(presenter);
            PrepareControls(view);

            savesettings.PerformClick();

            //verify saving connection string from view
            model.Verify(m => m.SaveConnectionStringToConfig(view.ConnectionString, It.IsAny<string>()));
        }
    }
}
