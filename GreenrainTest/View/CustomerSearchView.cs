using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApplication1.Presenter;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Repository;

namespace WindowsFormsApplication1.View
{
    public partial class CustomerSearchView : UserControl, ICustomerSearchView
    {
        ICustomerSearchPresenter _presenter;

        public CustomerSearchView()
        {
            InitializeComponent();
            _presenter = new CustomerSearchPresenter(this, new CustomersRepository());
        }

        public CustomerSearchView(ICustomerSearchPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.View = this;
        }

        #region ICustomerSearchView
        public Customer CustomersToSearch
        {
            get
            {
                Customer cust = new Customer();
                cust.Country = Country_cbox.Text;
                cust.City = City_cbox.Text;
                cust.CompanyName = CompanyName_tBox.Text;
                return cust;
            }
        }

        public void LoadComboBoxCountry(IEnumerable<string> Countries)
        {
            if (Countries != null)
            {
                if (Countries.Count() != 0)
                {
                    Country_cbox.DataSource = Countries.ToList();
                    return;
                }
            }
            Country_cbox.DataSource = null;
        }

        public void LoadComboBoxCities(IEnumerable<string> Cities)
        {
            if (Cities != null)
            {
                if (Cities.Count() != 0)
                {
                    City_cbox.DataSource = Cities.ToList();
                    return;
                }
            }
            City_cbox.DataSource = null;
        }

        public void ShowFilteredCustomers(IEnumerable<Customer> FilteredCustomers)
        {
            if (FilteredCustomers != null)
            {
                if (FilteredCustomers.Count() != 0)
                {
                    dataGridViewCustomers.DataSource = FilteredCustomers.ToList();
                    return;
                }
            }
            dataGridViewCustomers.DataSource = null;
        }

        public int CurrentPage
        {
            get
            {
                try
                {
                    return int.Parse(page_tbox.Text);
                }
                catch (Exception)
                {
                    return 1;
                }
            }
            set
            {
                page_tbox.Text = value.ToString();
                if (value == 0) page_tbox.Enabled = false;
                else page_tbox.Enabled = true;
            }
        }

        public bool IsPreviuosButEnabled
        {
            get
            {
                return previous.Enabled;
            }
            set
            {
                if (previous.Enabled != value)
                {
                    previous.Enabled = value;
                    beginning.Enabled = value;
                }
            }
        }

        public bool IsNextButEnabled
        {
            get
            {
                return next.Enabled;
            }
            set
            {
                if (next.Enabled != value)
                {
                    next.Enabled = value;
                    ending.Enabled = value;
                }
            }
        }

        public event VoidEventHandler ChangeCountry;
        public event VoidEventHandler SearchCustomers;

        public event VoidEventHandler Beginning;
        public event VoidEventHandler Previous;
        public event VoidEventHandler Next;
        public event VoidEventHandler Ending;
        public event KeyPressEventHandler PageChangeTBox;
        public event VoidEventHandler Disposed;
        #endregion


        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (SearchCustomers != null)
            {
                SearchCustomers();
            }
        }

        private void Country_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeCountry != null)
            {
                ChangeCountry();
            }
        }

        private void Country_cbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (ChangeCountry != null)
            {
                ChangeCountry();
            }
        }

        private void beginning_Click(object sender, EventArgs e)
        {
            if (Beginning != null)
            {
                Beginning();
            }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (Previous != null)
            {
                Previous();
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (Next != null)
            {
                Next();
            }
        }

        private void ending_Click(object sender, EventArgs e)
        {
            if (Ending != null)
            {
                Ending();
            }
        }

        private void page_tbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PageChangeTBox != null)
            {
                PageChangeTBox(this, e);
            }
        }
    }
}
