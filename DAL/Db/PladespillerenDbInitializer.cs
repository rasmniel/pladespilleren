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
            List<Artist> artists = new List<Artist>()
            {
                new Artist() { Name = "Metallica" },
                new Artist() { Name = "Cannibal Corpse" },
                new Artist() { Name = "Slayer" },
                new Artist() { Name = "Pantera" },
                new Artist() { Name = "Tool" },
                new Artist() { Name = "Alice in Chains" },
                new Artist() { Name = "Lunatic Soul" },
                new Artist() { Name = "Opeth" },
                new Artist() { Name = "Soen" },
                new Artist() { Name = "Marilyn Manson" },
                new Artist() { Name = "At The Gates" },
                new Artist() { Name = "Ghost" },
                new Artist() { Name = "In Flames" },
                new Artist() { Name = "Crosses" },
                new Artist() { Name = "Invocator" },
                new Artist() { Name = "Amorphis" },
                new Artist() { Name = "Katatonia" },
                new Artist() { Name = "Myrkur" },
                new Artist() { Name = "Black Sabbath" },
                new Artist() { Name = "Deep Purple" },
                new Artist() { Name = "Cattle Decapitation" }
            };

            List<Genre> genres = new List<Genre>()
            {
                new Genre() { Name = "Thrash Metal" },
                new Genre() { Name = "Death Metal" },
                new Genre() { Name = "Heavy Metal" },
                new Genre() { Name = "Progressive Metal" },
                new Genre() { Name = "Grunge" },
                new Genre() { Name = "Industrial Rock" },
                new Genre() { Name = "Black Metal" },
                new Genre() { Name = "Old School Heavy" },
                new Genre() { Name = "Hard Rock" },
                new Genre() { Name = "Speed Metal" },
            };

            List<Vinyl> vinyls = new List<Vinyl>() {
                new Vinyl() {
                    Artist = artists[0],
                    Name = "...And Justice for All",
                    Genre = genres[0],
                    Price = 139.50,
                    Year = 1988
                },

                new Vinyl()
                {
                    Artist = artists[1],
                    Name = "Tomb of the Mutilated",
                    Genre = genres[1],
                    Price = 149.00,
                    Year = 1992
                },

                new Vinyl()
                {
                    Artist = artists[2],
                    Name = "Hell Awaits",
                    Genre = genres[0],
                    Price = 249.00,
                    Year = 1989
                },

                new Vinyl()
                {
                    Artist = artists[3],
                    Name = "Cowboys From Hell",
                    Genre = genres[2],
                    Price = 175.00,
                    Year = 1990
                },

                new Vinyl()
                {
                    Artist = artists[4],
                    Name = "Lateralus",
                    Genre = genres[3],
                    Price = 399.99,
                    Year = 2005
                },

                new Vinyl()
                {
                    Artist = artists[5],
                    Name = "Alice in Chains",
                    Genre = genres[4],
                    Price = 160.00,
                    Year = 1995
                },

                new Vinyl()
                {
                    Artist = artists[6],
                    Name = "Lunatic Soul",
                    Genre = genres[5],
                    Price = 215.99,
                    Year = 2015
                },

                new Vinyl()
                {
                    Artist = artists[7],
                    Name = "Orchid",
                    Genre = genres[2],
                    Price = 139.75,
                    Year = 2001
                },

                new Vinyl()
                {
                    Artist = artists[8],
                    Name = "Tellurian",
                    Genre = genres[3],
                    Price = 220.99,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = artists[9],
                    Name = "Antichrist Superstar",
                    Genre = genres[2],
                    Price = 199.00,
                    Year = 2013
                },

                new Vinyl()
                {
                    Artist = artists[10],
                    Name = "Slaughter of the Soul",
                    Genre = genres[0],
                    Price = 155.25,
                    Year = 1995
                },

                new Vinyl()
                {
                    Artist = artists[11],
                    Name = "Infestissumam",
                    Genre = genres[2],
                    Price = 99.99,
                    Year = 2013
                },

                new Vinyl()
                {
                    Artist = artists[12],
                    Name = "Siren Charms",
                    Genre = genres[2],
                    Price = 225.50,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = artists[13],
                    Name = "†††",
                    Genre = genres[5],
                    Price = 199.75,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = artists[14],
                    Name = "Excursion Demise",
                    Genre = genres[1],
                    Price = 190.99,
                    Year = 1991
                },

                new Vinyl()
                {
                    Artist = artists[15],
                    Name = "Elegy",
                    Genre = genres[8],
                    Price = 150.25,
                    Year = 1996
                },

                new Vinyl()
                {
                    Artist = artists[16],
                    Name = "Dead End Kings",
                    Genre = genres[3],
                    Price = 249.00,
                    Year = 2012
                },

                new Vinyl()
                {
                    Artist = artists[17],
                    Name = "Myrkur",
                    Genre = genres[6],
                    Price = 110.00,
                    Year = 2012
                },

                new Vinyl()
                {
                    Artist = artists[18],
                    Name = "Sabbath Bloody Sabbath",
                    Genre = genres[7],
                    Price = 99.99,
                    Year = 1973
                },

                new Vinyl()
                {
                    Artist = artists[19],
                    Name = "Fireball",
                    Genre = genres[8],
                    Price = 255.99,
                    Year = 1971
                },

                new Vinyl()
                {
                    Artist = artists[20],
                    Name = "Humanure",
                    Genre = genres[9],
                    Price = 135.75,
                    Year = 2004
                }
            };

            context.Artists.AddRange(artists);
            context.Genres.AddRange(genres);
            context.Vinyls.AddRange(vinyls);
            base.Seed(context);
        }
    }
}
