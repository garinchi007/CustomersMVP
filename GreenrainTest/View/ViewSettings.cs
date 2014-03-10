using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication1.Presenter;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.View
{
    public partial class ViewSettings : UserControl, IViewSettings
    {
        #region IViewSettings
        public void CloseForm()
        {
            try
            {
                ((Form)this.TopLevelControl).Close();
            }
            catch (Exception)
            {
                Log.WriteLine("Cannot close form SettingsForm. Form isn't exist or not contain UserControl ViewSettings.");
            }
        }

        public string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = bd_server.Text;
                builder.InitialCatalog = bd_name.Text;
                builder.IntegratedSecurity = bool.Parse(bd_is.Text);
                builder.UserID = bd_user.Text;
                builder.Password = bd_pass.Text;
                return builder.ConnectionString;
            }
            set
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.ConnectionString = value;
                bd_server.Text = builder.DataSource;
                bd_name.Text = builder.InitialCatalog;
                bd_is.SelectedItem = builder.IntegratedSecurity.ToString().ToLower();
                bd_user.Text = builder.UserID;
                bd_pass.Text = builder.Password;
            }
        }

        public event VoidEventHandler SaveSettings;

        public event VoidEventHandler CancelSettings;

        public event VoidEventHandler LoadSettings;

        public event VoidEventHandler Disposed;
        #endregion

        ISettingsPresenter _presenter;

        public ViewSettings()
        {
            InitializeComponent();
            _presenter = new SettingsPresenter(this, new ModelSettings(), new DialogService());
            if (LoadSettings != null)
            {
                LoadSettings();
            }
        }

        public ViewSettings(ISettingsPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.View = this;
            if (LoadSettings != null)
            {
                LoadSettings();
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (SaveSettings != null)
            {
                SaveSettings();
            }
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (CancelSettings != null)
            {
                CancelSettings();
            }
        }
    }
}
