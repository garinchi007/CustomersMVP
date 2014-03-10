using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Presenter;
using WindowsFormsApplication1.View;
using Moq;
using System.Configuration;

namespace GreenrainTestTests
{
    [TestClass]
    public class SettingsPresenterTest
    {
        Mock<IViewSettings> view;
        Mock<IModelSettings> model;
        Mock<IDialogService> dialog;

        [TestInitialize]
        public void PreTestInitialize()
        {
            view = new Mock<IViewSettings>();
            model = new Mock<IModelSettings>();
            dialog = new Mock<IDialogService>();
        }

        [TestMethod]
        public void SaveSettings()
        {
            string ConnectionString = "TestConnectionString";
            view.Setup(m => m.ConnectionString).Returns(ConnectionString);
            ISettingsPresenter presenter = new SettingsPresenter(view.Object, model.Object, dialog.Object);

            view.Raise(m => m.SaveSettings += null);

            //verify saving ConnectionString
            model.Verify(m => m.SaveConnectionStringToConfig(ConnectionString, It.IsAny<string>()));
            view.Verify(m => m.CloseForm());
        }

        [TestMethod]
        public void LoadSettings()
        {
            string Config = "TestConnectionString";
            model.Setup(m => m.LoadConnectionStringFromConfig(Config)).Returns("CurrentConnectionString");
            view.Setup(m => m.ConnectionString).Returns(model.Object.LoadConnectionStringFromConfig(Config));
            ISettingsPresenter presenter = new SettingsPresenter(view.Object, model.Object, dialog.Object);

            view.Raise(m => m.LoadSettings += null);

            //verify loading ConnectionString
            model.Verify(m => m.LoadConnectionStringFromConfig(Config));
            Assert.AreEqual(view.Object.ConnectionString, "CurrentConnectionString");
        }

        [TestMethod]
        public void CancelSettings()
        {
            ISettingsPresenter presenter = new SettingsPresenter(view.Object, model.Object, dialog.Object);

            view.Raise(m => m.CancelSettings += null);

            //verify closing form
            view.Verify(m => m.CloseForm());
        }
    }
}
