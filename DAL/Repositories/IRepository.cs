using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BE;

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
