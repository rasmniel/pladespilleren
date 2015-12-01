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
    class ArtistRepository : IRepository<Artist>
    {
        private readonly PladespillerenDbContext db = new PladespillerenDbContext();

        public Artist Read(int? id)
        {
            return db.Artists.FirstOrDefault(artist => artist.Id == id);
        }

        public IEnumerable<Artist> ReadAll()
        {
            return db.Artists.ToList();
        }

        public bool Create(Artist entity)
        {
            db.Artists.Add(entity);
            db.SaveChanges();
            return true;
        }

        public bool Delete(Artist entity)
        {
            db.Artists.Remove(entity);
            db.SaveChanges();
            return true;
        }

        public bool Update(Artist entity)
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
