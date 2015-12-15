using System;
using System.Net.Http;
using System.Web.Mvc;
using BE;
using Microsoft.AspNet.Identity;
using MVC.Models;
using System.Collections.Generic;
using MVC.Infrastructure;

namespace MVC.Controllers
{
    public class VinylsController : Controller
    {
        private readonly GenericGateway<Vinyl> VinylsGateway = new GenericGateway<Vinyl>();
        private readonly GenericGateway<Genre> GenresGateway = new GenericGateway<Genre>();
        private readonly GenericGateway<Artist> ArtistsGateway = new GenericGateway<Artist>();
        private readonly GenericGateway<Order> OrdersGateway = new GenericGateway<Order>();

        public ActionResult Index()
        {
            HttpResponseMessage response = VinylsGateway.ReadAll();
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            var vinyls = response.Content.ReadAsAsync<IEnumerable<Vinyl>>().Result;
            return View(vinyls);
        }

        public ActionResult Create(Vinyl vinyl)
        {
            CreateViewModel model = new CreateViewModel();
            model.Vinyl = vinyl ?? new Vinyl();

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
        public ActionResult Create([Bind(Include = "Id,Name,CoverUrl,Year,Price")] Vinyl vinyl, int artistId, int genreId)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage artistResponse = ArtistsGateway.Read(artistId);
                if (!artistResponse.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(artistResponse.StatusCode);
                vinyl.Artist = artistResponse.Content.ReadAsAsync<Artist>().Result;

                HttpResponseMessage genreResponse = GenresGateway.Read(genreId);
                if (!genreResponse.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(genreResponse.StatusCode);
                vinyl.Genre = genreResponse.Content.ReadAsAsync<Genre>().Result;

                HttpResponseMessage response = VinylsGateway.Create(vinyl);
                if (!response.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(genreResponse.StatusCode);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Create", vinyl);
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

        public ActionResult Details(int? id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            Vinyl vinyl = response.Content.ReadAsAsync<Vinyl>().Result;
            return View(vinyl);
        }

        public ActionResult Delete(int? id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            Vinyl vinyl = response.Content.ReadAsAsync<Vinyl>().Result;
            return View(vinyl);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            var vinyl = response.Content.ReadAsAsync<Vinyl>().Result;

            HttpResponseMessage deleteResponse = VinylsGateway.Delete(vinyl.Id);
            if (!deleteResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(deleteResponse.StatusCode);

            return RedirectToAction("Index");
        }

        public ActionResult Buy(int id, bool? completed)
        {
            BuyViewModel model = new BuyViewModel();
            HttpResponseMessage response = VinylsGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            model.Vinyl = response.Content.ReadAsAsync<Vinyl>().Result;

            model.Completed = completed ?? false;
            if (model.Completed)
            {
                Order order = new Order()
                {
                    Date = DateTime.Now,
                    Vinyl = model.Vinyl,
                    UserId = User.Identity.GetUserId(),
                    UserName = User.Identity.GetUserName()
                };
                HttpResponseMessage orderResponse = OrdersGateway.Create(order);
                if (!orderResponse.IsSuccessStatusCode)
                    return new HttpStatusCodeResult(orderResponse.StatusCode);
            }
            return View(model);
        }
    }
}
