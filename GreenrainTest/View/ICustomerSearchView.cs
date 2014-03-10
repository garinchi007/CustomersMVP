using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.View
{
    public interface ICustomerSearchView : IView
    {
        //customers filter
        Customer CustomersToSearch { get; }
        void LoadComboBoxCountry(IEnumerable<string> Countries);
        void LoadComboBoxCities(IEnumerable<string> Cities);
        event VoidEventHandler ChangeCountry;
        event VoidEventHandler SearchCustomers;
        //navigation and table
        void ShowFilteredCustomers(IEnumerable<Customer> FilteredCustomers);
        int CurrentPage { get; set; }
        event VoidEventHandler Beginning;
        event VoidEventHandler Previous;
        event VoidEventHandler Next;
        event VoidEventHandler Ending;
        event KeyPressEventHandler PageChangeTBox;
        event VoidEventHandler Disposed;
        bool IsPreviuosButEnabled { get; set; }
        bool IsNextButEnabled { get; set; }
    }
}
