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
                    Name = "...And Justice for All",
                    Genre = new Genre() { Name = "Thrash Metal" },
                    Price = 139.50,
                    Year = 1988
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Cannibal Corpse" },
                    Name = "Tomb of the Mutilated",
                    Genre = new Genre { Name = "Death Metal" },
                    Price = 149.00,
                    Year = 1992
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Slayer" },
                    Name = "Hell Awaits",
                    Genre = new Genre { Name = "Thrash" },
                    Price = 249.00,
                    Year = 1989
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Pantera" },
                    Name = "Cowboys From Hell",
                    Genre = new Genre { Name = "Heavy Metal" },
                    Price = 175.00,
                    Year = 1990
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Tool" },
                    Name = "Lateralus",
                    Genre = new Genre { Name = "Progressive Rock" },
                    Price = 399.99,
                    Year = 2005
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Alice in Chains" },
                    Name = "Alice in Chains",
                    Genre = new Genre { Name = "Grunge" },
                    Price = 160.00,
                    Year = 1995
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Lunatic Soul" },
                    Name = "Lunatic Soul",
                    Genre = new Genre { Name = "Industrial Rock" },
                    Price = 215.99,
                    Year = 2015
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Opeth" },
                    Name = "Orchid",
                    Genre = new Genre { Name = "Heavy Metal" },
                    Price = 139.75,
                    Year = 2001
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Soen" },
                    Name = "Tellurian",
                    Genre = new Genre { Name = "Progressive Metal" },
                    Price = 220.99,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Marilyn Manson" },
                    Name = "Antichrist Superstar",
                    Genre = new Genre { Name = "Heavy Metal" },
                    Price = 199.00,
                    Year = 2013
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "At The Gates" },
                    Name = "Slaughter of the Soul",
                    Genre = new Genre { Name = "Thrash Metal" },
                    Price = 155.25,
                    Year = 1995
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Ghost" },
                    Name = "Infestissumam",
                    Genre = new Genre { Name = "Heavy Rock" },
                    Price = 99.99,
                    Year = 2013
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "In Flames" },
                    Name = "Siren Charms",
                    Genre = new Genre { Name = "Heavy Metal" },
                    Price = 225.50,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Crosses" },
                    Name = "†††",
                    Genre = new Genre { Name = "Industrial Hard Rock" },
                    Price = 199.75,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Invocator" },
                    Name = "Excursion Demise",
                    Genre = new Genre { Name = "Death Metal" },
                    Price = 190.99,
                    Year = 1991
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Amorphis" },
                    Name = "Elegy",
                    Genre = new Genre { Name = "Hard Rock" },
                    Price = 150.25,
                    Year = 1996
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Katatonia" },
                    Name = "Dead End Kings",
                    Genre = new Genre { Name = "Progressive Hard Rock" },
                    Price = 249.00,
                    Year = 2012
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Myrkur" },
                    Name = "Myrkur",
                    Genre = new Genre { Name = "Black Metal" },
                    Price = 110.00,
                    Year = 2012
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Black Sabbath" },
                    Name = "Sabbath Bloody Sabbath",
                    Genre = new Genre { Name = "Old School Heavy" },
                    Price = 99.99,
                    Year = 1973
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Deep Purple" },
                    Name = "Fireball",
                    Genre = new Genre { Name = "Hard Rock" },
                    Price = 255.99,
                    Year = 1971
                },

                new Vinyl()
                {
                    Artist = new Artist() { Name = "Cattle Decapitation" },
                    Name = "Humanure",
                    Genre = new Genre { Name = "Speed Metal" },
                    Price = 135.75,
                    Year = 2004
                }
            };

            context.Vinyls.AddRange(vinyls);
            base.Seed(context);
        }
    }
}
