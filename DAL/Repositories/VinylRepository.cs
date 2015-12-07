using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BE;
using DAL.Db;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

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
            db.Vinyls.Attach(entity);
            Vinyl existing = db.Vinyls.AsNoTracking()
                .Include(vinyl => vinyl.Artist)
                .Include(vinyl => vinyl.Genre)
                .Where(v => v.Id == entity.Id).FirstOrDefault();
            ObjectStateManager stateManager = ((IObjectContextAdapter)db).ObjectContext.ObjectStateManager;
            if (entity.Artist != null)
            {
                if (existing.Artist == null || (existing.Artist != null && entity.Artist.Id != existing.Artist.Id))
                {
                    stateManager.ChangeRelationshipState(entity, entity.Artist, e => e.Artist, EntityState.Added);
                }
            }
            if (entity.Genre != null)
            {
                if (existing.Genre == null || (existing.Genre != null && entity.Genre.Id != existing.Genre.Id))
                {
                    stateManager.ChangeRelationshipState(entity, entity.Genre, v => v.Genre, EntityState.Added);
                }
            }
            db.Entry(entity).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Catching to avoid app-crash - implement changing an existing genre/artist for vinyl entity...
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
