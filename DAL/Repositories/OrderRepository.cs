using DAL.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly PladespillerenDbContext db = new PladespillerenDbContext();

        public Order Read(int? id)
        {
            return db.Orders.Include(order => order.Vinyl).FirstOrDefault(order => order.Id == id);
        }

        public IEnumerable<Order> ReadAll()
        {
            return db.Orders.Include(order => order.Vinyl).ToList();
        }

        public Order Create(Order entity)
        {
            db.Orders.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(Order entity)
        {
            db.Orders.Remove(entity);
            db.SaveChanges();
        }

        public void Update(Order entity)
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
