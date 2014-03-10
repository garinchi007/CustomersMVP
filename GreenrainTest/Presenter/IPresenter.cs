using WindowsFormsApplication1.View;

namespace WindowsFormsApplication1.Presenter
{
    public interface IPresenter<T> where T : IView
    {
        T View { get; set; }
    }
}
