using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.View;

namespace WindowsFormsApplication1.Presenter
{
    public class SettingsPresenter : ISettingsPresenter
    {
        IViewSettings _view;
        IModelSettings _model;
        IDialogService _dialog;

        #region ISettingsPresenter
        public IViewSettings View
        {
            get { return _view; }
            set
            {
                _view = value;
                InitializeView();
            }
        }
        #endregion

        public SettingsPresenter(IViewSettings view, IModelSettings model, IDialogService dialog)
        {
            _model = model;
            _view = view;
            _dialog = dialog;
            InitializeView();
        }

        public SettingsPresenter(IModelSettings model, IDialogService dialog)
        {
            _model = model;
            _dialog = dialog;
        }

        private void InitializeView()
        {
            _view.CancelSettings += _view_CancelSettings;
            _view.LoadSettings += _view_LoadSettings;
            _view.SaveSettings += _view_SaveSettings;
            _view.Disposed += _view_Disposed;
        }

        private void _view_Disposed()
        {
            //release resources
            _view.CancelSettings -= _view_CancelSettings;
            _view.LoadSettings -= _view_LoadSettings;
            _view.SaveSettings -= _view_SaveSettings;
            _view.Disposed -= _view_Disposed;
        }

        private void _view_SaveSettings()
        {
            if (_model.SaveConnectionStringToConfig(_view.ConnectionString, "WindowsFormsApplication1.Properties.Settings.ConnectionStringNORTHWND"))
                _dialog.ShowMessageBox("Настройки сохранены. Применения настроек осуществится после перезагрузки программы.");
            else _dialog.ShowMessageBox("Настройки не были сохранены. Невозможно сохранить настройки в несуществующую конфигурацию.");
            _view.CloseForm();
        }

        private void _view_LoadSettings()
        {
            _view.ConnectionString = _model.LoadConnectionStringFromConfig("WindowsFormsApplication1.Properties.Settings.ConnectionStringNORTHWND");
        }

        private void _view_CancelSettings()
        {
            _view.CloseForm();
        }
    }
}
