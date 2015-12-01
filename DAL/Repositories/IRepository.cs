using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        T Read(int? id);

        IEnumerable<T> ReadAll();

        bool Create(T entity);

        bool Delete(T entity);

        bool Update(T entity);
    }
}
