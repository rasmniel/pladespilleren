using BE;
using DAL.Db;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly PladespillerenDbContext db = new PladespillerenDbContext();

        public Genre Read(int? id)
        {
            return db.Genres.FirstOrDefault(genre => genre.Id == id);
        }

        public IEnumerable<Genre> ReadAll()
        {
            return db.Genres.ToList();
        }

        public Genre Create(Genre entity)
        {
            db.Genres.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(Genre entity)
        {
            db.Genres.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Genre entity)
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
