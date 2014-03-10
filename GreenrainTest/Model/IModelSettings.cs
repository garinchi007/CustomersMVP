namespace WindowsFormsApplication1.Model
{
    public interface IModelSettings
    {
        bool SaveConnectionStringToConfig(string ConnectionString, string Config);
        string LoadConnectionStringFromConfig(string Config);
    }
}
