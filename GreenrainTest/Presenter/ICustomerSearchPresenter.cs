using WindowsFormsApplication1.View;

namespace WindowsFormsApplication1.Presenter
{
    public interface ICustomerSearchPresenter : IPresenter<ICustomerSearchView>
    {
        int PageSize { get; set; }
    }
}
