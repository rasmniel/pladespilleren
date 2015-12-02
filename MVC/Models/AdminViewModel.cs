﻿using BE;
using System.Collections.Generic;

namespace MVC.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Vinyl> BrokenVinyls { get; set; }
    }
}