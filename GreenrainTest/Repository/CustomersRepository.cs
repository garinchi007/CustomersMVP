using System.Linq;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{
    public class CustomersRepository : RepositoryBase<Customer>, ICustomersRepository
    {
        private bool IsMassegeShown = false;
        protected override IQueryable<Customer> GetTable()
        {
            if (IsDatabaseExists)
            {
                return context.Customers;
            }
            else
            {
                if (!IsMassegeShown)
                {
                    System.Windows.Forms.MessageBox.Show("Cannot connect to database. Verify connection string or database existence.");
                    IsMassegeShown = true;
                }
                Log.WriteLine("Cannot connect to database. Verify connection string or database existence.");
                return null;
            }
        }
    }
}
