﻿using System;
using DAL.Repositories;

namespace DAL
{
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

        public static OrderRepository GetOrderRepository()
        {
            return new OrderRepository();
        }
    }
}
