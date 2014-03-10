using System;
using System.Linq;

namespace WindowsFormsApplication1.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll();
        bool IsDatabaseExists { get; }
    }
}
