using System;
using System.Linq;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected DataNorthwindDataContext context;
        private bool _isDatabaseExists = false;

        public IQueryable<T> GetAll()
        {
            return GetTable();
        }

        public bool IsDatabaseExists
        {
            get { return _isDatabaseExists; }
        }

        protected abstract IQueryable<T> GetTable();

        public RepositoryBase()
        {
            context = new DataNorthwindDataContext();
            _isDatabaseExists = context.DatabaseExists();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                    context = null;
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
