using System;
using System.Configuration;

namespace WindowsFormsApplication1.Model
{
    public class ModelSettings : IModelSettings
    {
        public ModelSettings()
        {
        }

        public bool SaveConnectionStringToConfig(string ConnectionString, string Config)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings[Config].ConnectionString = ConnectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
                return true;
            }
            catch (Exception e)
            {
                Log.WriteLine("Connection string cannot be saved. Config is null or doesn't exist. " + e.Message);
                return false;
            }
        }

        public string LoadConnectionStringFromConfig(string Config)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[Config].ConnectionString;
            }
            catch (Exception e)
            {
                Log.WriteLine("Connection string cannot be loaded. Config is null or doesn't exist. " + e.Message);
                return "";
            }
        }
    }
}
