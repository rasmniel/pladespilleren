using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL.Db;

namespace DAL.Repositories
{
    public class VinylRepository : IRepository<Vinyl>
    {
        private readonly PladespillerenDbContext db = new PladespillerenDbContext();

        public Vinyl Read(int? id)
        {
            return db.Vinyls
                .Include(vinyl => vinyl.Artist)
                .Include(vinyl => vinyl.Genre)
                .FirstOrDefault(vinyl => vinyl.Id == id);
        }

        public IEnumerable<Vinyl> ReadAll()
        {
            return db.Vinyls
                .Include(vinyl => vinyl.Artist)
                .Include(vinyl => vinyl.Genre)
                .ToList();
        }

        public bool Create(Vinyl entity)
        {
            db.Vinyls.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Delete(Vinyl entity)
        {
            db.Vinyls.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Vinyl entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
