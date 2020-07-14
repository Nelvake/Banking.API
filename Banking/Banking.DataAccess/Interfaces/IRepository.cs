using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);

        bool Edit(T entity);

        bool Delete(T entity);

        T Get(Guid id);

        IList<T> GetAll();
        Task SingleOrDefaultAsync(Func<object, bool> p);
    }
}
