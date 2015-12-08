﻿using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using BE;
using DAL;
using DAL.Repositories;
using Microsoft.AspNet.Identity;
using MVC.Models;

namespace MVC.Controllers
{
    public class VinylsController : Controller
    {
        private readonly VinylRepository vinylRepository = DALFacade.GetVinylRepository();
        private readonly OrderRepository orderRepository = DALFacade.GetOrderRepository();

        // GET: Vinyls
        public ActionResult Index()
        {
            return View(vinylRepository.ReadAll());
        }

        // GET: Vinyls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = vinylRepository.Read(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        // GET: Vinyls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vinyls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Year,Price")] Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                vinylRepository.Create(vinyl);
                return RedirectToAction("Index");
            }

            return View(vinyl);
        }

        // GET: Vinyls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = vinylRepository.Read(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        // POST: Vinyls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Year,Price")] Vinyl vinyl)
        {
            if (ModelState.IsValid)
            {
                vinylRepository.Update(vinyl);
                return RedirectToAction("Index");
            }
            return View(vinyl);
        }

        // GET: Vinyls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vinyl vinyl = vinylRepository.Read(id);
            if (vinyl == null)
            {
                return HttpNotFound();
            }
            return View(vinyl);
        }

        // POST: Vinyls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vinyl vinyl = vinylRepository.Read(id);
            vinylRepository.Delete(vinyl);
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Buy(int id, bool? completed)
        {
            BuyViewModel model = new BuyViewModel();
            model.Vinyl = vinylRepository.Read(id);
            model.Completed = completed ?? false;
            if (model.Completed)
            {
                Order order = new Order();
                order.Vinyl = model.Vinyl;
                order.UserId = User.Identity.GetUserId();
                orderRepository.Create(order);
            }
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vinylRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
