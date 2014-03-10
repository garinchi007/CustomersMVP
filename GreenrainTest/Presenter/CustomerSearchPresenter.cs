using System;
using WindowsFormsApplication1.Repository;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.View;

namespace WindowsFormsApplication1.Presenter
{
    public class CustomerSearchPresenter : ICustomerSearchPresenter
    {
        ICustomerSearchView _view;
        ICustomersRepository _rep;
        private int pagesize = 10;

        #region ICustomerSearchPresenter
        public ICustomerSearchView View
        {
            get
            {
                return _view;
            }
            set
            {
                _view = value;
                InitializeView();
            }
        }

        public int PageSize
        {
            get
            {
                return pagesize;
            }
            set
            {
                pagesize = value;
            }
        }
        #endregion

        public CustomerSearchPresenter(ICustomerSearchView view, ICustomersRepository rep)
        {
            _view = view;
            _rep = rep;
            InitializeView();
        }

        public CustomerSearchPresenter(ICustomersRepository rep)
        {
            _rep = rep;
        }

        private void InitializeView()
        {
            _view.ChangeCountry += View_ChangeCountry;
            _view.SearchCustomers += View_SearchCustomers;
            _view.Beginning += _view_Beginning;
            _view.Ending += _view_Ending;
            _view.Next += _view_Next;
            _view.Previous += _view_Previous;
            _view.PageChangeTBox += _view_PageChangeTBox;
            _view.Disposed += _view_Disposed;
            //load ComboBoxes
            _view.LoadComboBoxCountry(_rep.GetAll().GetCountries());
        }

        private void _view_Disposed()
        {
            //release resources
            _view.ChangeCountry -= View_ChangeCountry;
            _view.SearchCustomers -= View_SearchCustomers;
            _view.Beginning -= _view_Beginning;
            _view.Ending -= _view_Ending;
            _view.Next -= _view_Next;
            _view.Previous -= _view_Previous;
            _view.PageChangeTBox -= _view_PageChangeTBox;
            _view.Disposed -= _view_Disposed;
            _rep.Dispose();
        }

        public enum NavButton
        {
            Previous,
            Beginning,
            Next,
            Ending,
            ChangeTbox
        }

        private void UpdateView(NavButton navbutton)
        {
            CustomerPaging custpage = new CustomerPaging(_rep, new PageInfo<Customer>(pagesize));
            switch (navbutton)
            {
                case NavButton.Previous:
                    {
                        //update dataGridView
                        _view.ShowFilteredCustomers(custpage.GetPageResultByFilter(_view.CustomersToSearch, _view.CurrentPage - 1));
                        //set buttons
                        if (custpage.page.CurrentPage <= 1) _view.IsPreviuosButEnabled = false;
                        if (custpage.page.CurrentPage <= custpage.page.PageCount - 1) _view.IsNextButEnabled = true;
                        else _view.IsNextButEnabled = false;
                    }
                    break;
                //also using for Search Button
                case NavButton.Beginning:
                    {
                        //update dataGridView
                        _view.ShowFilteredCustomers(custpage.GetPageResultByFilter(_view.CustomersToSearch, 1));
                        //set buttons
                        _view.IsPreviuosButEnabled = false;
                        if (custpage.page.PageCount > 1) _view.IsNextButEnabled = true;
                        else _view.IsNextButEnabled = false;
                        if (custpage.page.CurrentPage < 1) _view.IsNextButEnabled = false;
                    }
                    break;
                case NavButton.Next:
                    {
                        //update dataGridView
                        _view.ShowFilteredCustomers(custpage.GetPageResultByFilter(_view.CustomersToSearch, _view.CurrentPage + 1));
                        //set buttons
                        if (custpage.page.CurrentPage == custpage.page.PageCount) _view.IsNextButEnabled = false;
                        if (custpage.page.PageCount <= 1) _view.IsPreviuosButEnabled = false;
                        if (custpage.page.CurrentPage == 2) _view.IsPreviuosButEnabled = true;
                    }
                    break;
                case NavButton.Ending:
                    {
                        //update dataGridView
                        _view.ShowFilteredCustomers(custpage.GetLastPageResultByFilter(_view.CustomersToSearch));
                        //set buttons
                        _view.IsNextButEnabled = false;
                        if (custpage.page.CurrentPage > 1) _view.IsPreviuosButEnabled = true;
                        else _view.IsPreviuosButEnabled = false;
                    }
                    break;
                case NavButton.ChangeTbox:
                    {
                        //update dataGridView
                        _view.ShowFilteredCustomers(custpage.GetPageResultByFilter(_view.CustomersToSearch, _view.CurrentPage));
                        //set buttons
                        if (custpage.page.CurrentPage == custpage.page.PageCount) _view.IsNextButEnabled = false;
                        else _view.IsNextButEnabled = true;
                        if (custpage.page.CurrentPage > 1) _view.IsPreviuosButEnabled = true;
                        else _view.IsPreviuosButEnabled = false;
                    }
                    break;
            }
            //correct previous page on view
            _view.CurrentPage = custpage.page.CurrentPage;
        }

        private void _view_Previous()
        {
            UpdateView(NavButton.Previous);
        }

        private void _view_Beginning()
        {
            UpdateView(NavButton.Beginning);
        }

        private void _view_Next()
        {
            UpdateView(NavButton.Next);
        }

        private void _view_Ending()
        {
            UpdateView(NavButton.Ending);
        }


        private void View_SearchCustomers()
        {
            UpdateView(NavButton.Beginning);
        }

        private void _view_PageChangeTBox(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;

            if (e.KeyChar == 13)
            {
                UpdateView(NavButton.ChangeTbox);
            }
        }

        private void View_ChangeCountry()
        {
            _view.LoadComboBoxCities(_rep.GetAll().GetCities(_view.CustomersToSearch.Country));
        }
    }
}
