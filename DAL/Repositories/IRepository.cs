using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IRepository<T> : IDisposable
    {
        T Read(int? id);

        IEnumerable<T> ReadAll();

        T Create(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
