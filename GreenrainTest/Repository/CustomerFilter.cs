using System.Linq;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{
    public static class CustomerFilter
    {
        public static IQueryable<string> GetCountries(this IQueryable<Customer> q)
        {
            if (q != null)
                return q.GroupBy(c => c.Country).Select(x => x.Key);
            else
            {
                return null;
            }
        }

        public static IQueryable<string> GetCities(this IQueryable<Customer> q, string Country)
        {
            if (Country != null && q != null)
                return q.Where(c => c.Country.ToLower().Contains(Country.ToLower())).GroupBy(c => c.City).Select(x => x.Key);
            else
            {
                if (Country == null) Log.WriteLine("Exception on getting cities. Country cannot be null.");
                return null;
            }
        }

        public static IQueryable<Customer> WithCountryLike(this IQueryable<Customer> q, string name)
        {
            if (name != null && q != null)
                return q.Where(customer => customer.Country.ToLower().Contains(name.ToLower()));
            else
            {
                if (name == null) Log.WriteLine("Exception on filter by country. Country cannot be null.");
                return null;
            }
        }

        public static IQueryable<Customer> WithCityLike(this IQueryable<Customer> q, string name)
        {
            if (name != null && q != null)
                return q.Where(customer => customer.City.ToLower().Contains(name.ToLower()));
            else
            {
                if (name == null) Log.WriteLine("Exception on filter by city. City cannot be null.");
                return null;
            }
        }

        public static IQueryable<Customer> WithCompanyLike(this IQueryable<Customer> q, string name)
        {
            if (name != null && q != null)
                return q.Where(customer => customer.CompanyName.ToLower().Contains(name.ToLower()));
            else
            {
                if (name == null) Log.WriteLine("Exception on filter by company name. Company name cannot be null.");
                return null;
            }
        }
    }
}
