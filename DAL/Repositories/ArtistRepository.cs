using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BE;
using DAL.Db;

namespace DAL.Repositories
{
    public class ArtistRepository : IRepository<Artist>
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

        public Artist Create(Artist entity)
        {
            db.Artists.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(Artist entity)
        {
            db.Artists.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Artist entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
