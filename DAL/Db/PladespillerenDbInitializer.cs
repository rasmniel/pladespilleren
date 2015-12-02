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
            List<Vinyl> vinyls = new List<Vinyl>() {
                new Vinyl() {
                    Artist = new Artist() { Name = "Metallica" },
                    Name = "...And Justice For All",
                    Genre = new Genre() { Name = "Thrash Metal" },
                    Price = 139,
                    Year = 1988
                },
                new Vinyl()
                {
                    Artist = new Artist() { Name = "Cannibal Corpse" },
                    Name = "Tomb of the Mutilated",
                    Genre = new Genre { Name = "Death Metal" },
                    Price = 149,
                    Year = 1992
                }
            };

            context.Vinyls.AddRange(vinyls);
            base.Seed(context);
        }
    }
}
