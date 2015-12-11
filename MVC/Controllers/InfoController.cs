using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class InfoController : Controller
    {
        // GET: About Info
        public ActionResult About()
        {
            return View();
        }

        // GET: Contact Info
        public ActionResult Contact()
        {
            return View();
        }
    }
}