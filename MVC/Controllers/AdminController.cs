using BE;
using DAL;
using DAL.Repositories;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly GenreRepository GenreRepo = DALFacade.GetGenreRepository();
        private readonly ArtistRepository ArtistRepo = DALFacade.GetArtistRepository();

        public ActionResult Index()
        {
            AdminViewModel model = new AdminViewModel();
            model.Artists = ArtistRepo.ReadAll();
            model.Genres = GenreRepo.ReadAll();
            return View(model);
        }
    }
}