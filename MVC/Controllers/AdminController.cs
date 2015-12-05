using BE;
using DAL;
using DAL.Repositories;
using MVC.Models;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly VinylRepository VinylRepo = DALFacade.GetVinylRepository();
        private readonly GenreRepository GenreRepo = DALFacade.GetGenreRepository();
        private readonly ArtistRepository ArtistRepo = DALFacade.GetArtistRepository();

        public ActionResult Index()
        {
            AdminViewModel model = new AdminViewModel();
            model.Artists = ArtistRepo.ReadAll();
            model.Genres = GenreRepo.ReadAll();
            model.BrokenVinyls = VinylRepo.ReadBrokenVinyls();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "Id,Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                ArtistRepo.Create(artist);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenre([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                GenreRepo.Create(genre);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteArtist(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = ArtistRepo.Read(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            foreach (Vinyl v in VinylRepo.ReadAll())
            {
                if (v.Artist != null)
                {
                    if (v.Artist.Id == artist.Id)
                    {
                        v.Artist = null;
                        VinylRepo.Update(v);
                    }
                }
            }
            ArtistRepo.Delete(artist);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteGenre(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = GenreRepo.Read(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            foreach (Vinyl v in VinylRepo.ReadAll())
            {
                if (v.Genre != null)
                {
                    if (v.Genre.Id == genre.Id)
                    {
                        v.Genre = null;
                        VinylRepo.Update(v);
                    }
                }
            }
            GenreRepo.Delete(genre);
            return RedirectToAction("Index");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Year,Price")] Vinyl vinyl, int artistId, int genreId)
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ArtistRepo.Dispose();
                GenreRepo.Dispose();
                VinylRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}