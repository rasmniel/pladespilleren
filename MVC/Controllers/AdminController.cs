using System.Collections.Generic;
using BE;
using MVC.Models;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using MVC.Infrastructure;

namespace MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly GenericGateway<Vinyl> VinylsGateway = new GenericGateway<Vinyl>();
        private readonly GenericGateway<Genre> GenresGateway = new GenericGateway<Genre>();
        private readonly GenericGateway<Artist> ArtistsGateway = new GenericGateway<Artist>();

        public ActionResult Index()
        {
            AdminViewModel model = new AdminViewModel();

            HttpResponseMessage response = VinylsGateway.ReadAll();
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            var brokenVinyls = response.Content.ReadAsAsync<IEnumerable<Vinyl>>().Result;
            model.BrokenVinyls = brokenVinyls.Where(vinyl => vinyl.Artist == null || vinyl.Genre == null);

            HttpResponseMessage artistResponse = ArtistsGateway.ReadAll();
            if (!artistResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(artistResponse.StatusCode);
            var artists = artistResponse.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
            model.Artists = artists.OrderBy(artist => artist.Name);

            HttpResponseMessage genreResponse = GenresGateway.ReadAll();
            if (!genreResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(genreResponse.StatusCode);
            var genres = genreResponse.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            model.Genres = genres.OrderBy(genre => genre.Name);

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            Vinyl vinyl = response.Content.ReadAsAsync<Vinyl>().Result;

            return View(vinyl);
        }

        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult CreateArtist([Bind(Include = "Id,Name")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = ArtistsGateway.Create(artist);
                if (!response.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenre([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = GenresGateway.Create(genre);
                if (!response.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteArtist(int? id)
        {
            HttpResponseMessage response = ArtistsGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            Artist artist = response.Content.ReadAsAsync<Artist>().Result;

            HttpResponseMessage vinylResponse = VinylsGateway.ReadAll();
            if (!vinylResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(vinylResponse.StatusCode);

            var vinyls = vinylResponse.Content.ReadAsAsync<IEnumerable<Vinyl>>().Result;
            foreach (Vinyl v in vinyls)
            {
                if (v.Artist.Id == artist.Id)
                {
                    v.Artist = null;
                    HttpResponseMessage updateResponse = VinylsGateway.Update(v);
                    if (!updateResponse.IsSuccessStatusCode)
                        return new HttpStatusCodeResult(updateResponse.StatusCode);
                }
            }
            HttpResponseMessage deleteResponse = ArtistsGateway.Delete(artist.Id);
            if (!deleteResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(deleteResponse.StatusCode);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteGenre(int? id)
        {
            HttpResponseMessage response = GenresGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            Genre genre = response.Content.ReadAsAsync<Genre>().Result;

            HttpResponseMessage vinylResponse = VinylsGateway.ReadAll();
            if (!vinylResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(vinylResponse.StatusCode);

            var vinyls = vinylResponse.Content.ReadAsAsync<IEnumerable<Vinyl>>().Result;
            foreach (Vinyl v in vinyls)
            {
                if (v.Genre.Id == genre.Id)
                {
                    v.Genre = null;
                    HttpResponseMessage updateResponse = VinylsGateway.Update(v);
                    if (!updateResponse.IsSuccessStatusCode)
                        return new HttpStatusCodeResult(updateResponse.StatusCode);
                }
            }
            HttpResponseMessage deleteResponse = GenresGateway.Delete(genre.Id);
            if (!deleteResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(deleteResponse.StatusCode);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            EditViewModel model = new EditViewModel();

            HttpResponseMessage response = VinylsGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            model.Vinyl = response.Content.ReadAsAsync<Vinyl>().Result;

            HttpResponseMessage artistResponse = ArtistsGateway.ReadAll();
            if (!artistResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(artistResponse.StatusCode);
            model.Artists = artistResponse.Content.ReadAsAsync<IEnumerable<Artist>>().Result;

            HttpResponseMessage genreResponse = GenresGateway.ReadAll();
            if (!genreResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(genreResponse.StatusCode);
            model.Genres = genreResponse.Content.ReadAsAsync<IEnumerable<Genre>>().Result;

            return View(model);
        }

        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CoverUrl,Year,Price")] Vinyl vinyl, int artistId, int genreId)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage artistResponse = ArtistsGateway.Read(artistId);
                if (!artistResponse.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(artistResponse.StatusCode);
                vinyl.Artist = artistResponse.Content.ReadAsAsync<Artist>().Result;

                HttpResponseMessage genreResponse = GenresGateway.Read(genreId);
                if (!artistResponse.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(genreResponse.StatusCode);
                vinyl.Genre = genreResponse.Content.ReadAsAsync<Genre>().Result;

                HttpResponseMessage response = VinylsGateway.Update(vinyl);
                if (!response.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(response.StatusCode);
            }
            return RedirectToAction("Index");
        }
    }
}