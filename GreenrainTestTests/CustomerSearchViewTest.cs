using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Moq;
using WindowsFormsApplication1.View;
using WindowsFormsApplication1.Repository;
using WindowsFormsApplication1.Presenter;
using WindowsFormsApplication1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;



namespace GreenrainTestTests
{
    [TestClass]
    public class CustomerSearchViewTest
    {
        private IEnumerable<Customer> customers;
        Mock<ICustomersRepository> rep;
        ComboBox combcountry;
        ComboBox combcity;
        DataGridView datagrid;
        Button searchbut;
        Button endingbut;
        Button previousbut;
        Button beginningbut;
        Button nextbut;
        TextBox pagetbox;
        TextBox companyname;

        [TestInitialize]
        public void PreTestInitialize()
        {
            customers = new Customer[]
            {
                new Customer() { CustomerID = "FRST", Country = "Russia", City = "Moscow", CompanyName = "Gasprom"},
                new Customer() { CustomerID = "SCND", Country = "USA", City = "New York", CompanyName = "New York Entertaiment"},
                new Customer() { CustomerID = "THRD", Country = "Ukraine", City = "Kiev", CompanyName = "Ukraine Development"},
                new Customer() { CustomerID = "FRTH", Country = "Russia", City = "St. Peterburg", CompanyName = "Petersburg Development"},
                new Customer() { CustomerID = "FIFT", Country = "USA", City = "New York", CompanyName = "New York Support Center"},
                new Customer() { CustomerID = "SIXT", Country = "Germany", City = "Berlin", CompanyName = "Berlin Bank"},
                new Customer() { CustomerID = "SEVT", Country = "USA", City = "Boston", CompanyName = "Boston Calling Center"},
                new Customer() { CustomerID = "EIGT", Country = "France", City = "Paris", CompanyName = "Paris Development"},
                new Customer() { CustomerID = "NINT", Country = "Russia", City = "Moscow", CompanyName = "Moscow Development"},
                new Customer() { CustomerID = "TENT", Country = "Spain", City = "Madrid", CompanyName = "Madrid Calling Center"}
            };
            rep = new Mock<ICustomersRepository>();
        }

        private static class GUITester
        {
            public static T FindControl<T>(Control container, string name)
                  where T : Control
            {
                if (container is T && container.Name == name)
                    return container as T;
                if (container.Controls.Count == 0)
                    return null;
                foreach (Control child in container.Controls)
                {
                    Control control = FindControl<T>(child, name);
                    if (control != null)
                        return control as T;
                }
                return null;
            }
        }

        private void PrepareControls(CustomerSearchView view)
        {
            combcountry = GUITester.FindControl<ComboBox>(view, "Country_cbox");
            combcity = GUITester.FindControl<ComboBox>(view, "City_cbox");
            datagrid = GUITester.FindControl<DataGridView>(view, "dataGridViewCustomers");
            searchbut = GUITester.FindControl<Button>(view, "Search_btn");
            endingbut = GUITester.FindControl<Button>(view, "ending");
            previousbut = GUITester.FindControl<Button>(view, "previous");
            beginningbut = GUITester.FindControl<Button>(view, "beginning");
            nextbut = GUITester.FindControl<Button>(view, "next");
            pagetbox = GUITester.FindControl<TextBox>(view, "page_tbox");
            companyname = GUITester.FindControl<TextBox>(view, "CompanyName_tBox");
        }

        private List<string> GetListFromComboBox(ComboBox comb)
        {
            List<string> list = new List<string>();
            foreach (var item in comb.Items)
            {
                list.Add(item.ToString());
            }
            return list;
        }

        [TestMethod]
        public void LoadViewComboboxes()
        {
            rep.Setup(m => m.GetAll()).Returns(customers.OrderBy(c => c.Country).AsQueryable());
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);

            //verify count of comboboxes items, there are 6 countries in array
            Assert.AreEqual(combcountry.Items.Count, 6);
            //customers was ordered by countries, first Country is France, there are only one city in France
            Assert.AreEqual(combcity.Items.Count, 1);

            IEnumerable<string> expectedcities = new List<string> { "Paris" };
            List<string> citieslist = GetListFromComboBox(combcity);

            //verify items in combcity
            CollectionAssert.AreEqual(citieslist.OrderBy(c => c).ToArray(), expectedcities.OrderBy(c => c).ToArray());

            IEnumerable<string> expectedcountries = new List<string> { "Russia", "USA", "Ukraine", "Germany", "France", "Spain" };
            List<string> countrieslist = GetListFromComboBox(combcountry);

            //verify items in combcountry
            CollectionAssert.AreEqual(countrieslist.OrderBy(c => c).ToArray(), expectedcountries.OrderBy(c => c).ToArray());
        }

        [TestMethod]
        public void LoadViewComboboxesNullValues()
        {
            rep.Setup(m => m.GetAll()).Returns((IQueryable<Customer>)null);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);

            //verify count of comboboxes items, there are 0 countries in null array
            Assert.AreEqual(combcountry.Items.Count, 0);
            //verify count of comboboxes items, there are 0 cities in null array
            Assert.AreEqual(combcity.Items.Count, 0);
        }

        [TestMethod]
        public void LoadViewCityComboboxWhenCountryChanged()
        {
            rep.Setup(m => m.GetAll()).Returns(customers.OrderBy(c => c.Country).AsQueryable());
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);

            //verify count of comboboxes items, there are 6 countries in array
            Assert.AreEqual(combcountry.Items.Count, 6);
            //customers was ordered by countries, first Country is France, there are only one city in France
            Assert.AreEqual(combcity.Items.Count, 1);

            IEnumerable<string> expectedcities = new List<string> { "Paris" };
            List<string> citieslist = GetListFromComboBox(combcity);

            //verify items in combcity
            CollectionAssert.AreEqual(citieslist.OrderBy(c => c).ToArray(), expectedcities.OrderBy(c => c).ToArray());
            //change country on Russia
            combcountry.SelectedIndex = 2;
            expectedcities = new List<string> { "Moscow", "St. Peterburg" };
            citieslist = GetListFromComboBox(combcity);

            //verify items in combcity
            CollectionAssert.AreEqual(citieslist.OrderBy(c => c).ToArray(), expectedcities.OrderBy(c => c).ToArray());
        }

        [TestMethod]
        public void LoadViewGridView()
        {
            rep.Setup(m => m.GetAll()).Returns(customers.OrderBy(c => c.Country).AsQueryable());
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);

            searchbut.PerformClick();

            //verify count of datagridview rows, only 1 customer from France, Paris
            Assert.AreEqual(datagrid.Rows.Count, 1);
            //verify customer in datagridview, expected customer from Paris
            Assert.AreEqual(datagrid.Rows[0].Cells["City"].Value.ToString(), "Paris");
        }

        [TestMethod]
        public void LoadViewGridViewNullValues()
        {
            rep.Setup(m => m.GetAll()).Returns((IQueryable<Customer>)null);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);

            searchbut.PerformClick();

            //verify count of datagridview rows, 0 customers from null array
            Assert.AreEqual(datagrid.Rows.Count, 0);
        }

        [TestMethod]
        public void ViewGridViewCanPaginate()
        {
            rep.Setup(m => m.GetAll()).Returns(customers.OrderBy(c => c.Country).AsQueryable());
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            //set 2 customers per page
            presenter.PageSize = 2;
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);
            //there are 7 customers from countries contains 's'
            combcountry.Text = "s";
            combcity.Text = "";

            searchbut.PerformClick();

            //verify count of datagridview rows, 2 customers on first page
            Assert.AreEqual(datagrid.Rows.Count, 2);
            //verify that NextButtons is enabled
            Assert.IsTrue(endingbut.Enabled && nextbut.Enabled);
            //verify that PrevButtons is disabled
            Assert.IsFalse(previousbut.Enabled && beginningbut.Enabled);

            endingbut.PerformClick();

            //verify count of datagridview rows, 1 customers on last page
            Assert.AreEqual(datagrid.Rows.Count, 1);
            //verify currentpage textbox, expected page - 4
            Assert.AreEqual(pagetbox.Text, "4");
            //verify that NextButtons is disabled on last page
            Assert.IsFalse(endingbut.Enabled && nextbut.Enabled);
            //verify that PrevButtons is enabled on last page
            Assert.IsTrue(previousbut.Enabled && beginningbut.Enabled);

            //changing data
            rep.Setup(m => m.GetAll()).Returns((IQueryable<Customer>)null);
            //try to get previous page
            previousbut.PerformClick();

            //but page 3 is not exists, there are no customers in database, expect 0 rows in datagrid
            Assert.AreEqual(datagrid.Rows.Count, 0);
            //verify number of current page
            Assert.AreEqual(pagetbox.Text, "0");
            //verify that NextButtons is disabled
            Assert.IsFalse(endingbut.Enabled && nextbut.Enabled);
            //verify that PrevButtons is disabled
            Assert.IsFalse(previousbut.Enabled && beginningbut.Enabled);
        }

        [TestMethod]
        public void ViewGridViewGoTo0PageWhenDataIsMissing()
        {
            rep.Setup(m => m.GetAll()).Returns(customers.OrderBy(c => c.Country).AsQueryable());
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            //set 2 customers per page
            presenter.PageSize = 2;
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);
            //there are 7 customers from countries contains 's'
            combcountry.Text = "s";
            combcity.Text = "";

            searchbut.PerformClick();

            //changing data
            rep.Setup(m => m.GetAll()).Returns((IQueryable<Customer>)null);
            //try to get next page
            nextbut.PerformClick();

            //but page 2 is not exists, there are no customers in database, expect 0 rows in datagrid
            Assert.AreEqual(datagrid.Rows.Count, 0);
            //verify number of current page
            Assert.AreEqual(pagetbox.Text, "0");
            //verify that NextButtons is disabled
            Assert.IsFalse(endingbut.Enabled && nextbut.Enabled);
            //verify that PrevButtons is disabled
            Assert.IsFalse(previousbut.Enabled && beginningbut.Enabled);
        }

        [TestMethod]
        public void ViewGridViewGoToMaximumPossiblePageWhenFilterWasChanged()
        {
            rep.Setup(m => m.GetAll()).Returns(customers.OrderBy(c => c.Country).AsQueryable());
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(rep.Object);
            //set 2 customers per page
            presenter.PageSize = 2;
            CustomerSearchView view = new CustomerSearchView(presenter);
            PrepareControls(view);
            //there are 7 customers from countries contains 's'
            combcountry.Text = "s";
            combcity.Text = "";

            //go to 1 page
            searchbut.PerformClick();
            //go to 4 page
            endingbut.PerformClick();
            //changing data, there are 3 customers from countries contains 'ss'
            combcountry.Text = "ss";
            //try to get 3 page
            previousbut.PerformClick();

            //but page 3 is not exists, there are only 2 pages of customers with 1 customer on second page
            Assert.AreEqual(datagrid.Rows.Count, 1);
            //verify that 2 page was loaded
            Assert.AreEqual(pagetbox.Text, "2");
            //verify that NextButtons is disabled
            Assert.IsFalse(endingbut.Enabled && nextbut.Enabled);
            //verify that PrevButtons is enabled
            Assert.IsTrue(previousbut.Enabled && beginningbut.Enabled);
        }
    }
}
