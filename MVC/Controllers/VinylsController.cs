using System;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using BE;
using Microsoft.AspNet.Identity;
using MVC.infrastructure;
using MVC.Models;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class VinylsController : Controller
    {
        private readonly VinylsGateway VinylsGateway = new VinylsGateway();
        private readonly GenresGateway GenresGateway = new GenresGateway();
        private readonly ArtistsGateway ArtistsGateway = new ArtistsGateway();
        private readonly OrdersGateway OrdersGateway = new OrdersGateway();

        public ActionResult Index()
        {
            HttpResponseMessage response = VinylsGateway.ReadAll();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var vinyls = response.Content.ReadAsAsync<IEnumerable<Vinyl>>().Result;
                return View(vinyls);
            }
            return new HttpStatusCodeResult(response.StatusCode);
        }

        public ActionResult Create()
        {
            CreateViewModel model = new CreateViewModel();
            model.Vinyl = new Vinyl();
            HttpResponseMessage artistResponse = ArtistsGateway.ReadAll();
            if (artistResponse.StatusCode == HttpStatusCode.OK)
            {
                model.Artists = artistResponse.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
            }

            HttpResponseMessage genreResponse = GenresGateway.ReadAll();
            if (genreResponse.StatusCode == HttpStatusCode.OK)
            {
                model.Genres = genreResponse.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            }
            return View(model);
        }

        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CoverUrl,Year,Price")] Vinyl vinyl, int artistId, int genreId)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage artistResponse = ArtistsGateway.Read(artistId);
                if (artistResponse.StatusCode == HttpStatusCode.OK)
                {
                    vinyl.Artist = artistResponse.Content.ReadAsAsync<Artist>().Result;
                }

                HttpResponseMessage genreResponse = GenresGateway.Read(genreId);
                if (genreResponse.StatusCode == HttpStatusCode.OK)
                {
                    vinyl.Genre = genreResponse.Content.ReadAsAsync<Genre>().Result;
                }

                HttpResponseMessage response = VinylsGateway.Create(vinyl);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            // TEMP. NON CRASH FIX
            CreateViewModel model = new CreateViewModel();
            model.Vinyl = vinyl;
            model.Artists = new List<Artist>();
            model.Genres = new List<Genre>();

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            var vinyl = response.Content.ReadAsAsync<Vinyl>().Result;
            if (vinyl == null)
            {
                return new HttpStatusCodeResult(response.StatusCode);
            }
            EditViewModel model = new EditViewModel();
            model.Vinyl = vinyl;
            HttpResponseMessage artistResponse = ArtistsGateway.ReadAll();
            if (artistResponse.StatusCode == HttpStatusCode.OK)
            {
                model.Artists = artistResponse.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
            }

            HttpResponseMessage genreResponse = GenresGateway.ReadAll();
            if (genreResponse.StatusCode == HttpStatusCode.OK)
            {
                model.Genres = genreResponse.Content.ReadAsAsync<IEnumerable<Genre>>().Result;
            }
            return View(model);
        }

        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CoverUrl,Year,Price")] Vinyl vinyl, int artistId, int genreId)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage artistResponse = ArtistsGateway.Read(artistId);
                if (artistResponse.StatusCode == HttpStatusCode.OK)
                {
                    vinyl.Artist = artistResponse.Content.ReadAsAsync<Artist>().Result;
                }

                HttpResponseMessage genreResponse = GenresGateway.Read(genreId);
                if (genreResponse.StatusCode == HttpStatusCode.OK)
                {
                    vinyl.Genre = genreResponse.Content.ReadAsAsync<Genre>().Result;
                }
                HttpResponseMessage response = VinylsGateway.Update(vinyl);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new HttpStatusCodeResult(response.StatusCode);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            var vinyl = response.Content.ReadAsAsync<Vinyl>().Result;
            if (vinyl == null)
            {
                return new HttpStatusCodeResult(response.StatusCode);
            }
            return View(vinyl);
        }

        public ActionResult Delete(int? id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            var vinyl = response.Content.ReadAsAsync<Vinyl>().Result;
            if (vinyl == null)
            {
                return new HttpStatusCodeResult(response.StatusCode);
            }
            return View(vinyl);
        }

        [ActionName("Delete")]
        [HttpPost, ValidateInput(true)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HttpResponseMessage response = VinylsGateway.Read(id);
            var vinyl = response.Content.ReadAsAsync<Vinyl>().Result;
            if (vinyl == null)
            {
                return new HttpStatusCodeResult(response.StatusCode);
            }
            HttpResponseMessage deletedResponse = VinylsGateway.Delete(vinyl.Id);
            if (deletedResponse.StatusCode != HttpStatusCode.OK)
            {
                return new HttpStatusCodeResult(response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Buy(int id, bool? completed)
        {
            BuyViewModel model = new BuyViewModel();
            HttpResponseMessage response = VinylsGateway.Read(id);
            var vinyl = response.Content.ReadAsAsync<Vinyl>().Result;
            if (vinyl == null)
            {
                return new HttpStatusCodeResult(response.StatusCode);
            }
            model.Vinyl = vinyl;
            model.Completed = completed ?? false;
            if (model.Completed)
            {
                Order order = new Order();
                order.Date = DateTime.Now;
                order.Vinyl = model.Vinyl;
                order.UserId = User.Identity.GetUserId();
                order.UserName = User.Identity.GetUserName();
                HttpResponseMessage orderResponse = OrdersGateway.Create(order);
                if (orderResponse.StatusCode != HttpStatusCode.OK)
                {
                    return new HttpStatusCodeResult(response.StatusCode);
                }
            }
            return View(model);
        }
    }
}
