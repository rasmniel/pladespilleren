using System.Data.Entity;

namespace DAL.Db
{
    public class PladespillerenDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PladespillerenDbContext() : base("PladespillerenConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new PladespillerenDbInitializer());
        }

        public DbSet<BE.Vinyl> Vinyls { get; set; }

        public DbSet<BE.Artist> Artists { get; set; }

        public DbSet<BE.Genre> Genres { get; set; }

        public DbSet<BE.Order> Orders { get; set; }
    }
}
