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
                    CoverUrl = "http://www.metalinjection.net/wp-content/uploads/2014/12/Metallica-and-Justice-for-All.jpg",
                    Genre = genres[0],
                    Price = 139.50,
                    Year = 1988
                },

                new Vinyl()
                {
                    Artist = artists[1],
                    Name = "Tomb of the Mutilated",
                    CoverUrl = "http://ecx.images-amazon.com/images/I/61wq12YDzFL.jpg",
                    Genre = genres[1],
                    Price = 149.00,
                    Year = 1992
                },

                new Vinyl()
                {
                    Artist = artists[2],
                    Name = "Hell Awaits",
                    CoverUrl = "http://www.metalblade.com/us/covers/Slayer-HellAwaits.jpg",
                    Genre = genres[0],
                    Price = 249.00,
                    Year = 1989
                },

                new Vinyl()
                {
                    Artist = artists[3],
                    Name = "Cowboys From Hell",
                    CoverUrl = "http://www.musicfearsatan.com/DSK/pantera_cowboys_(big).jpg",
                    Genre = genres[2],
                    Price = 175.00,
                    Year = 1990
                },

                new Vinyl()
                {
                    Artist = artists[4],
                    Name = "Lateralus",
                    CoverUrl = "http://kat.unblock.al/yuqme/albums/21/477/4686417696.jpg",
                    Genre = genres[3],
                    Price = 399.99,
                    Year = 2005
                },

                new Vinyl()
                {
                    Artist = artists[5],
                    Name = "Alice in Chains",
                    CoverUrl = "http://www.metal-archives.com/images/3/9/6/2/3962.jpg",
                    Genre = genres[4],
                    Price = 160.00,
                    Year = 1995
                },

                new Vinyl()
                {
                    Artist = artists[6],
                    Name = "Lunatic Soul",
                    CoverUrl = "http://www.progarchives.com/progressive_rock_discography_covers/4127/cover_16882122008.jpg",
                    Genre = genres[5],
                    Price = 215.99,
                    Year = 2015
                },

                new Vinyl()
                {
                    Artist = artists[7],
                    Name = "Orchid",
                    CoverUrl = "http://www.rankopedia.com/CandidatePix/83281.gif",
                    Genre = genres[2],
                    Price = 139.75,
                    Year = 2001
                },

                new Vinyl()
                {
                    Artist = artists[8],
                    Name = "Tellurian",
                    CoverUrl = "http://i.imgur.com/21OsXIB.jpg",
                    Genre = genres[3],
                    Price = 220.99,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = artists[9],
                    Name = "Antichrist Superstar",
                    CoverUrl = "http://36.media.tumblr.com/tumblr_mawbz7xxVE1rgc6e6o1_500.jpg",
                    Genre = genres[2],
                    Price = 199.00,
                    Year = 2013
                },

                new Vinyl()
                {
                    Artist = artists[10],
                    Name = "Slaughter of the Soul",
                    CoverUrl = "https://c2.staticflickr.com/4/3573/3770275478_07eb5fd206.jpg",
                    Genre = genres[0],
                    Price = 155.25,
                    Year = 1995
                },

                new Vinyl()
                {
                    Artist = artists[11],
                    Name = "Infestissumam",
                    CoverUrl = "http://blastbeast.dk/wp-content/uploads/2013/04/ghostin.jpg",
                    Genre = genres[2],
                    Price = 99.99,
                    Year = 2013
                },

                new Vinyl()
                {
                    Artist = artists[12],
                    Name = "Siren Charms",
                    CoverUrl = "http://cdn.albumoftheyear.org/album/2014/16220-siren-charms.jpg",
                    Genre = genres[2],
                    Price = 225.50,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = artists[13],
                    Name = "†††",
                    CoverUrl = "http://ripitup.com.au/content/uploads/2014/08/crosses-crosses1.jpg",
                    Genre = genres[5],
                    Price = 199.75,
                    Year = 2014
                },

                new Vinyl()
                {
                    Artist = artists[14],
                    Name = "Excursion Demise",
                    CoverUrl = "http://bit.ly/1ORgwer",
                    Genre = genres[1],
                    Price = 190.99,
                    Year = 1991
                },

                new Vinyl()
                {
                    Artist = artists[15],
                    Name = "Elegy",
                    CoverUrl = "http://www.metal-archives.com/images/1/6/2/162.jpg?0125",
                    Genre = genres[8],
                    Price = 150.25,
                    Year = 1996
                },

                new Vinyl()
                {
                    Artist = artists[16],
                    Name = "Dead End Kings",
                    CoverUrl = "https://meatmeadmetal.files.wordpress.com/2012/08/dead-end-kings.jpg",
                    Genre = genres[3],
                    Price = 249.00,
                    Year = 2012
                },

                new Vinyl()
                {
                    Artist = artists[17],
                    Name = "Myrkur",
                    CoverUrl = "http://www.metal-archives.com/images/4/5/4/4/454413.jpg?4337",
                    Genre = genres[6],
                    Price = 110.00,
                    Year = 2012
                },

                new Vinyl()
                {
                    Artist = artists[18],
                    Name = "Sabbath Bloody Sabbath",
                    CoverUrl = "https://s3.amazonaws.com/rapgenius/cover_1035162272009.jpg",
                    Genre = genres[7],
                    Price = 99.99,
                    Year = 1973
                },

                new Vinyl()
                {
                    Artist = artists[19],
                    Name = "Fireball",
                    CoverUrl = "http://3.bp.blogspot.com/_6tJHBv82MIM/TR7ASD1BFuI/AAAAAAAABOY/R8AAYiX8vvg/s1600/Deep_Purple_Fireball.jpg",
                    Genre = genres[8],
                    Price = 255.99,
                    Year = 1971
                },

                new Vinyl()
                {
                    Artist = artists[20],
                    Name = "Humanure",
                    CoverUrl = "http://www.amoeba.com/sized-images/max/500/500/uploads/albums/covers/other//CattleDecapitation_Humanure.jpg",
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
