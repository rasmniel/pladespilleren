using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;

namespace DAL
{
    // Singleton class
    public class DALFacade
    {
        public static VinylRepository GetVinylRepository()
        {
            return new VinylRepository();
        }

        public static ArtistRepository GetArtistRepository()
        {
            return new ArtistRepository();
        }

        public static GenreRepository GetGenreRepository()
        {
            return new GenreRepository();
        }
    }
}
