using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApplication1.Repository;

namespace WindowsFormsApplication1.Model
{
    public class CustomerPaging
    {
        private ICustomersRepository _rep;
        public PageInfo<Customer> page { get; set; }
        private bool LastPage = false;

        public CustomerPaging(ICustomersRepository rep)
        {
            _rep = rep;
            page = new PageInfo<Customer>();
        }

        public CustomerPaging(ICustomersRepository rep, PageInfo<Customer> pageinfo)
        {
            _rep = rep;
            if (pageinfo != null) page = pageinfo;
            else page = new PageInfo<Customer>();
        }

        public IEnumerable<Customer> GetPageResultByFilter(Customer cust, int PageNumber)
        {
            try
            {
                page.CustomerRecordsCount = _rep.GetAll().WithCountryLike(cust.Country).WithCityLike(cust.City).WithCompanyLike(cust.CompanyName).Count();
                //count the number of pages
                int ostatok = 0;
                page.PageCount = Math.DivRem(page.CustomerRecordsCount, page.PageSize, out ostatok);
                if (ostatok > 0) page.PageCount++;
                //correct the user input
                if (page.PageCount == 0) page.CurrentPage = 0;
                else
                {
                    if (!LastPage)
                    {
                        if (PageNumber > page.PageCount) PageNumber = page.PageCount;
                        if (PageNumber < 1) PageNumber = 1;
                        page.CurrentPage = PageNumber;
                    }
                    else { page.CurrentPage = page.PageCount; LastPage = false; }
                }
                int offset = 0;
                if (page.CurrentPage != 0) offset = (page.CurrentPage - 1) * page.PageSize;
                //load filtered customers
                return _rep.GetAll().WithCountryLike(cust.Country).WithCityLike(cust.City).WithCompanyLike(cust.CompanyName).Skip(offset).Take(page.PageSize);
            }
            catch (Exception e)
            {
                if (cust == null) Log.WriteLine("Exception on getting page result. Customer cannot be null. " + e.Message);
                else Log.WriteLine("Exception on getting page result. Cannot connect to database. " + e.Message);
                return null;
            }
        }

        public IEnumerable<Customer> GetLastPageResultByFilter(Customer cust)
        {
            LastPage = true;
            return GetPageResultByFilter(cust, 0);
        }
    }
}
