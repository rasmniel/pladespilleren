using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class AdminViewModel
    {
        public IEnumerable<Artist> Artists { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}