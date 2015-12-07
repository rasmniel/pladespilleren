using BE;
using System.Collections.Generic;

namespace MVC.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Vinyl> BrokenVinyls { get; set; }

        public IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Vinyl> AllVinyls { get; set; }
    }
}