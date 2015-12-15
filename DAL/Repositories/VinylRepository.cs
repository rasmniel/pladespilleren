using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        public IEnumerable<Vinyl> ReadBrokenVinyls()
        {
            return db.Vinyls
                .Include(vinyl => vinyl.Artist)
                .Include(vinyl => vinyl.Genre)
                .Where(vinyl => vinyl.Artist == null || vinyl.Genre == null);
        }

        public IEnumerable<Vinyl> ReadGoodVinyls()
        {
            return db.Vinyls
                .Include(vinyl => vinyl.Artist)
                .Include(vinyl => vinyl.Genre)
                .Where(vinyl => vinyl.Artist != null && vinyl.Genre != null);
        }

        public Vinyl Create(Vinyl entity)
        {
            db.Vinyls.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(Vinyl entity)
        {
            db.Vinyls.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Vinyl entity)
        {
            var original = db.Vinyls
                .Include(vinyl => vinyl.Genre)
                .Include(vinyl => vinyl.Artist)
                .FirstOrDefault(vinyl => vinyl.Id == entity.Id);
            
            // Set all values from new entity to the old (except object references)
            db.Entry(original).CurrentValues.SetValues(entity);

            // Update artist reference
            if (entity.Artist != null)
            {
                if (original.Artist == null || entity.Artist.Id != original.Artist.Id)
                {
                    db.Artists.Attach(entity.Artist);
                    original.Artist = entity.Artist;
                }
            }
            else
            {
                original.Artist = null;
            }

            // Update genre reference
            if (entity.Genre != null)
            {
                if (original.Genre == null || entity.Genre.Id != original.Genre.Id)
                {
                    db.Genres.Attach(entity.Genre);
                    original.Genre = entity.Genre;
                }
            }
            else
            {
                original.Genre = null;
            }

            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
