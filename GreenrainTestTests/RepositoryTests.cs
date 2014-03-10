using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Repository;
using System.Collections.Generic;
using Moq;


namespace GreenrainTestTests
{
    [TestClass]
    public class RepositoryTests
    {
        private IEnumerable<Customer> customers;
        Mock<ICustomersRepository> mock;

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
            mock = new Mock<ICustomersRepository>();
            mock.Setup(m => m.GetAll()).Returns(customers.AsQueryable());
        }

        [TestMethod]
        public void LoadCountriesTest()
        {
            IEnumerable<string> countries = mock.Object.GetAll().GetCountries();
            //expected array
            IEnumerable<string> countriesExpected = new List<string> { "Russia", "USA", "Ukraine", "Germany", "France", "Spain" };

            //verify filter, there are six different countries in array
            CollectionAssert.AreEqual(countries.OrderBy(c => c).ToArray(), countriesExpected.OrderBy(c => c).ToArray());
        }

        [TestMethod]
        public void LoadCitiesForCountryTest()
        {
            IEnumerable<string> cities = mock.Object.GetAll().GetCities("USA");
            //expected array
            IEnumerable<string> citiesExpected = new List<string> { "New York", "Boston" };

            //verify filter, there are two different cities in USA
            CollectionAssert.AreEqual(cities.OrderBy(c => c).ToArray(), citiesExpected.OrderBy(c => c).ToArray());
        }

        [TestMethod]
        public void LoadCitiesForNullCountryTest()
        {
            IEnumerable<string> cities = mock.Object.GetAll().GetCities(null);

            //cities is null if Country is null, exception was added to log
            Assert.IsNull(cities);
        }

        [TestMethod]
        public void LoadCitiesForNonExistentCountryTest()
        {
            IEnumerable<string> cities = mock.Object.GetAll().GetCities("Mashnoria");
            //verify filter, there are zero cities in nonexistent country
            Assert.AreEqual(cities.Count(), 0);
        }

        [TestMethod]
        public void LoadCitiesForLetterTest()
        {
            IEnumerable<string> cities = mock.Object.GetAll().GetCities("s");
            //expected array
            IEnumerable<string> citiesExpected = new List<string> { "Moscow", "New York", "St. Peterburg", "Boston", "Madrid" };

            //verify filter, there are five different cities in countries that contains s (or S)
            CollectionAssert.AreEqual(cities.OrderBy(c => c).ToArray(), citiesExpected.OrderBy(c => c).ToArray());
        }

        [TestMethod]
        public void LoadCustomerPageTest()
        {
            Customer cust = new Customer() { Country = "USA", City = "", CompanyName = "" };
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 3 customers from USA, load second page
            Customer[] result = custpage.GetPageResultByFilter(cust, 2).ToArray();

            //on second page we expect 1 customer
            Assert.AreEqual(result.Count(), 1);
            //from Boston
            Assert.AreEqual(result[0].City, "Boston");
        }

        [TestMethod]
        public void LoadCustomerPageTestWithNonexistentPage()
        {
            Customer cust = new Customer() { Country = "USA", City = "", CompanyName = "" };
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 3 customers from USA, try to load fifth page
            Customer[] result = custpage.GetPageResultByFilter(cust, 5).ToArray();

            //second page will be loaded, because we have only two pages of customers right now
            Assert.AreEqual(custpage.page.CurrentPage, 2);
            //on second page we expect 1 customer
            Assert.AreEqual(result.Count(), 1);
            //from Boston
            Assert.AreEqual(result[0].City, "Boston");
        }

        [TestMethod]
        public void LoadCustomerPageTestWithLessThenZeroPage()
        {
            Customer cust = new Customer() { Country = "USA", City = "", CompanyName = "" };
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 3 customers from USA, try to load -5 page
            Customer[] result = custpage.GetPageResultByFilter(cust, -5).ToArray();

            //first page will be loaded
            Assert.AreEqual(custpage.page.CurrentPage, 1);
            //on first page we expect 2 customer
            Assert.AreEqual(result.Count(), 2);
            //from New York
            Assert.AreEqual(result[0].City, "New York");
            Assert.AreEqual(result[1].City, "New York");
        }

        [TestMethod]
        public void LoadCustomerPageTestWithZeroPage()
        {
            Customer cust = new Customer() { Country = "USA", City = "", CompanyName = "" };
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 3 customers from USA, try to load zero page
            Customer[] result = custpage.GetPageResultByFilter(cust, 0).ToArray();

            //first page will be loaded
            Assert.AreEqual(custpage.page.CurrentPage, 1);
            //on first page we expect 2 customer
            Assert.AreEqual(result.Count(), 2);
            //from New York
            Assert.AreEqual(result[0].City, "New York");
            Assert.AreEqual(result[1].City, "New York");
        }

        [TestMethod]
        public void LoadCustomerPageTestWithNullCustomer()
        {
            Customer cust = null;
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 3 customers from USA, try to load first page
            IEnumerable<Customer> result = custpage.GetPageResultByFilter(cust, 1);

            //zero page will be loaded
            Assert.AreEqual(custpage.page.CurrentPage, 0);
            //expected null result
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoadCustomerPageTestWithNullCity()
        {
            Customer cust = new Customer() { Country = "USA", City = null, CompanyName = "" };
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 3 customers from USA, try to load first page
            IEnumerable<Customer> result = custpage.GetPageResultByFilter(cust, 1);

            //zero page will be loaded
            Assert.AreEqual(custpage.page.CurrentPage, 0);
            //expected null result
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoadCustomerPageTestWithNullCompanyName()
        {
            Customer cust = new Customer() { Country = "USA", City = "", CompanyName = null };
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 3 customers from USA, try to load first page
            IEnumerable<Customer> result = custpage.GetPageResultByFilter(cust, 1);

            //zero page will be loaded
            Assert.AreEqual(custpage.page.CurrentPage, 0);
            //expected null result
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoadCustomerPageTestWithNullCountry()
        {
            Customer cust = new Customer() { Country = null, City = "Moscow", CompanyName = "" };
            //create customerpaging class with 2 items per page
            CustomerPaging custpage = new CustomerPaging(mock.Object, new PageInfo<Customer>(2));

            //there are 2 customers from Moscow, try to load first page
            IEnumerable<Customer> result = custpage.GetPageResultByFilter(cust, 1);

            //zero page will be loaded
            Assert.AreEqual(custpage.page.CurrentPage, 0);
            //expected null result
            Assert.IsNull(result);
        }
    }
}
