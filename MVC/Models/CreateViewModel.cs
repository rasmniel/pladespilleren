using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CreateViewModel
    {
        public Vinyl Vinyl { get; set; }

        public IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}