using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL.Db
{
    public class PladespillerenDbInitializer : DropCreateDatabaseAlways<PladespillerenDbContext>
    {
        protected override void Seed(PladespillerenDbContext context)
        {
            Vinyl vinyl = new Vinyl()
            {
                Artist = new Artist() {Name = "Metallica"},
                Name = "...And Justice For All",
                Genre = new Genre() { Name = "Thrash Metal"},
                Price = 139,
                Year = 1988
            };
            context.Vinyls.Add(vinyl);
            base.Seed(context);
        }
    }
}
