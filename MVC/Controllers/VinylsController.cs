using System;
using System.Net;
using System.Web.Mvc;
using BE;
using DAL;
using DAL.Repositories;
using Microsoft.AspNet.Identity;
using MVC.Models;

namespace MVC.Controllers
{
    public class VinylsController : Controller
    {
        private readonly VinylRepository VinylRepo = DALFacade.GetVinylRepository();
        private readonly GenreRepository GenreRepo = DALFacade.GetGenreRepository();
        private readonly ArtistRepository ArtistRepo = DALFacade.GetArtistRepository();
        private readonly OrderRepository OrderRepo = DALFacade.GetOrderRepository();

        public ActionResult Index()
        {
            return View(VinylRepo.ReadAll());
        }
        
        public ActionResult Create()
        {
            CreateViewModel model = new CreateViewModel();
            model.Vinyl = new Vinyl();
            model.Artists = ArtistRepo.ReadAll();
            model.Genres = GenreRepo.ReadAll();
            return View(model);
        }

        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CoverUrl,Year,Price")] Vinyl vinyl, int artistId, int genreId)
        {
            if (ModelState.IsValid)
            {
                vinyl.Artist = ArtistRepo.Read(artistId);
                vinyl.Genre = GenreRepo.Read(genreId);
                VinylRepo.Create(vinyl);
                return RedirectToAction("Index");
            }

            return View(vinyl);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = VinylRepo.Read(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            EditViewModel model = new EditViewModel();
            model.Vinyl = vinyl;
            model.Artists = ArtistRepo.ReadAll();
            model.Genres = GenreRepo.ReadAll();
            return View(model);
        }

        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CoverUrl,Year,Price")] Vinyl vinyl, int artistId, int genreId)
        {
            if (ModelState.IsValid)
            {
                Artist a = ArtistRepo.Read(artistId);
                vinyl.Artist = a;
                Genre g = GenreRepo.Read(genreId);
                vinyl.Genre = g;
                VinylRepo.Update(vinyl);
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = VinylRepo.Read(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = VinylRepo.Read(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vinyl vinyl = VinylRepo.Read(id);
            VinylRepo.Delete(vinyl);
            return RedirectToAction("Index");
        }

        public ActionResult Buy(int id, bool? completed)
        {
            BuyViewModel model = new BuyViewModel();
            model.Vinyl = VinylRepo.Read(id);
            model.Completed = completed ?? false;
            if (model.Completed)
            {
                Order order = new Order();
                order.Date = DateTime.Now;
                order.Vinyl = model.Vinyl;
                order.UserId = User.Identity.GetUserId();
                order.UserName = User.Identity.GetUserName();
                OrderRepo.Create(order);
            }
            return View(model);
        }

        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                VinylRepo.Dispose();
                ArtistRepo.Dispose();
                GenreRepo.Dispose();
                OrderRepo.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
