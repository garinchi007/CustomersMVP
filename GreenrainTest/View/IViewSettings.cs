namespace WindowsFormsApplication1.View
{
    public interface IViewSettings : IView
    {
        void CloseForm();
        string ConnectionString { get; set; }
        event VoidEventHandler SaveSettings;
        event VoidEventHandler CancelSettings;
        event VoidEventHandler LoadSettings;
        event VoidEventHandler Disposed;
    }
}
