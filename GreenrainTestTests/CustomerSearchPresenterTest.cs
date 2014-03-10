using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WindowsFormsApplication1.Repository;
using WindowsFormsApplication1.View;
using WindowsFormsApplication1.Presenter;
using WindowsFormsApplication1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System;

namespace GreenrainTestTests
{
    [TestClass]
    public class CustomerSearchPresenterTest
    {
        private IEnumerable<Customer> customers;
        Mock<ICustomerSearchView> mockview;
        Mock<ICustomersRepository> mockrep;
        int CurrentPage = 0;
        bool IsNextButEnabled = false;
        bool IsPreviuosButEnabled = false;

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

            mockview = new Mock<ICustomerSearchView>();
            mockrep = new Mock<ICustomersRepository>();
            //change data
            mockrep.Setup(m => m.GetAll()).Returns(customers.AsQueryable());
            //when Currentpage set value save it in local variable
            mockview.SetupSet(p => p.CurrentPage = It.IsAny<int>()).Callback<int>(value => CurrentPage = value);
            //when IsNextButEnabled set value save it in local variable
            mockview.SetupSet(p => p.IsNextButEnabled = It.IsAny<bool>()).Callback<bool>(value => IsNextButEnabled = value);
            //when IsPreviuosButEnabled set value save it in local variable
            mockview.SetupSet(p => p.IsPreviuosButEnabled = It.IsAny<bool>()).Callback<bool>(value => IsPreviuosButEnabled = value);
        }

        [TestMethod]
        public void LoadingComboBoxes()
        {
            mockview.Setup(m => m.CustomersToSearch).Returns(new Customer() { Country = "USA", City = "New York", CompanyName = "New York Support Center" });
            mockview.Setup(m => m.LoadComboBoxCountry(It.IsAny<IEnumerable<string>>())).Raises(m => m.ChangeCountry += null);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);

            mockview.Verify(m => m.LoadComboBoxCountry(It.IsAny<IEnumerable<string>>()), Times.Once);
            mockview.Verify(m => m.LoadComboBoxCities(It.IsAny<IEnumerable<string>>()), Times.Once);
        }

        [TestMethod]
        public void PreviousPageWhenCurrentPageIs2PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 2
            mockview.SetupGet(m => m.CurrentPage).Returns(2);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //raise click on previous button, try to change page on 1
            mockview.Raise(m => m.Previous += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void PreviousPageWhenCurrentPageIs4PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 4
            mockview.SetupGet(m => m.CurrentPage).Returns(4);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;

            //trying to change page on 3
            mockview.Raise(m => m.Previous += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 3);
            //when page changed on 3 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 3 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void PreviousPageWhenCurrentPageIs7PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //trying to change page on 6
            mockview.Raise(m => m.Previous += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page, when (CurrentPage - 1) > PageCount, CurrentPage should equals PageCount 
            Assert.AreEqual(CurrentPage, 4);
            //when page changed on 4 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 4 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void PreviousPageWhenCurrentPageIs7PageCount0()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USAs", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //trying to change page on 6
            mockview.Raise(m => m.Previous += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page, when (CurrentPage - 1) > PageCount, CurrentPage should equals PageCount 
            Assert.AreEqual(CurrentPage, 0);
            //when page changed on 0 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 0 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void PreviousPageWhenCurrentPageIs7PageCount1()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USA", City = "Boston", CompanyName = "Boston Calling Center" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //trying to change page on 6
            mockview.Raise(m => m.Previous += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page, when (CurrentPage - 1) > PageCount, CurrentPage should equals PageCount 
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void BeginningPageWhenCurrentPageIs2PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 2
            mockview.SetupGet(m => m.CurrentPage).Returns(2);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.Beginning += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void BeginningPageWhenCurrentPageIs4PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 4
            mockview.SetupGet(m => m.CurrentPage).Returns(4);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.Beginning += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void BeginningPageWhenCurrentPageIs7PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.Beginning += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void BeginningPageWhenCurrentPageIs7PageCount1()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USA", City = "Boston", CompanyName = "Boston Calling Center" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.Beginning += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void BeginningPageWhenCurrentPageIs7PageCount0()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USAs", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;
            IsNextButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.Beginning += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 0);
            //when page changed on 0 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 0 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void NextPageWhenCurrentPageIs3PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 3
            mockview.SetupGet(m => m.CurrentPage).Returns(3);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 4
            mockview.Raise(m => m.Next += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 4);
            //when page changed on 4 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 4 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void NextPageWhenCurrentPageIs1PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 1
            mockview.SetupGet(m => m.CurrentPage).Returns(1);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;

            //trying to change page on 2
            mockview.Raise(m => m.Next += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 2);
            //when page changed on 2 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 2 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void NextPageWhenCurrentPageIs7PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 8
            mockview.Raise(m => m.Next += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page, when (CurrentPage + 1) > PageCount, CurrentPage = PageCount
            Assert.AreEqual(CurrentPage, 4);
            //when page changed on 4 NextButoons should be enabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 4 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void NextPageWhenCurrentPageIs7PageCount0()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USAs", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 8
            mockview.Raise(m => m.Next += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page, when (CurrentPage + 1) > PageCount, CurrentPage = PageCount
            Assert.AreEqual(CurrentPage, 0);
            //when page changed on 0 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 0 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void NextPageWhenCurrentPageIs7PageCount1()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USA", City = "Boston", CompanyName = "Boston Calling Center" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 8
            mockview.Raise(m => m.Next += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page, when (CurrentPage + 1) > PageCount, CurrentPage = PageCount
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void EndingPageWhenCurrentPageIs3PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 3
            mockview.SetupGet(m => m.CurrentPage).Returns(3);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 4
            mockview.Raise(m => m.Ending += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 4);
            //when page changed on 4 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 4 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void EndingPageWhenCurrentPageIs1PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 1
            mockview.SetupGet(m => m.CurrentPage).Returns(1);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;

            //trying to change page on 4
            mockview.Raise(m => m.Ending += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 4);
            //when page changed on 4 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 4 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void EndingPageWhenCurrentPageIs7PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on ending
            mockview.Raise(m => m.Ending += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 4);
            //when page changed on 4 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 4 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void EndingPageWhenCurrentPageIs7PageCount1()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USA", City = "Boston", CompanyName = "Boston Calling Center" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on ending
            mockview.Raise(m => m.Ending += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void EndingPageWhenCurrentPageIs7PageCount0()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USAs", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on ending
            mockview.Raise(m => m.Ending += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 0);
            //when page changed on 0 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 0 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void ChangeTBoxOn2WhenPageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 2
            mockview.SetupGet(m => m.CurrentPage).Returns(2);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 2
            mockview.Raise(m => m.PageChangeTBox += null, new KeyPressEventArgs('\r'));

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 2);
            //when page changed on 2 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 2 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void ChangeTBoxOn1WhenPageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 1
            mockview.SetupGet(m => m.CurrentPage).Returns(1);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.PageChangeTBox += null, new KeyPressEventArgs('\r'));

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void ChangeTBoxOn0WhenPageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 0
            mockview.SetupGet(m => m.CurrentPage).Returns(0);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 0
            mockview.Raise(m => m.PageChangeTBox += null, new KeyPressEventArgs('\r'));

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void ChangeTBoxOn7WhenPageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 7
            mockview.Raise(m => m.PageChangeTBox += null, new KeyPressEventArgs('\r'));

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 4);
            //when page changed on 4 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 4 PreviousButtons should be enabled
            Assert.IsTrue(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void ChangeTBoxOn7WhenPageCount1()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USA", City = "Boston", CompanyName = "Boston Calling Center" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 7
            mockview.Raise(m => m.PageChangeTBox += null, new KeyPressEventArgs('\r'));

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void ChangeTBoxOn7WhenPageCount0()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USAs", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 7
            mockview.Raise(m => m.PageChangeTBox += null, new KeyPressEventArgs('\r'));

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 0);
            //when page changed on 0 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 0 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void SearchWhenCurrentPageIs2PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 2
            mockview.SetupGet(m => m.CurrentPage).Returns(2);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.SearchCustomers += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void SearchWhenCurrentPageIs4PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 4
            mockview.SetupGet(m => m.CurrentPage).Returns(4);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsPreviuosButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.SearchCustomers += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void SearchWhenCurrentPageIs7PageCount4()
        {
            //customers to search
            Customer cust = new Customer() { Country = "s", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.SearchCustomers += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be enabled
            Assert.IsTrue(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void SearchWhenCurrentPageIs7PageCount1()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USA", City = "Boston", CompanyName = "Boston Calling Center" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.SearchCustomers += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 1);
            //when page changed on 1 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 1 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }

        [TestMethod]
        public void SearchWhenCurrentPageIs7PageCount0()
        {
            //customers to search
            Customer cust = new Customer() { Country = "USAs", City = "", CompanyName = "" };
            //CurrentPage before click is 7
            mockview.SetupGet(m => m.CurrentPage).Returns(7);
            //setup view
            mockview.Setup(m => m.CustomersToSearch).Returns(cust);
            ICustomerSearchPresenter presenter = new CustomerSearchPresenter(mockview.Object, mockrep.Object);
            presenter.PageSize = 2;
            IsNextButEnabled = true;
            IsPreviuosButEnabled = true;

            //trying to change page on 1
            mockview.Raise(m => m.SearchCustomers += null);

            //verify loading customers page
            mockview.Verify(m => m.ShowFilteredCustomers(It.IsAny<IEnumerable<Customer>>()), Times.Once);
            //verify current page
            Assert.AreEqual(CurrentPage, 0);
            //when page changed on 0 NextButoons should be disabled
            Assert.IsFalse(IsNextButEnabled);
            //when page changed on 0 PreviousButtons should be disabled
            Assert.IsFalse(IsPreviuosButEnabled);
        }
    }
}
