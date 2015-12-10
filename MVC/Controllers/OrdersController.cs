using BE;
using DAL;
using DAL.Repositories;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderRepository OrderRepo = DALFacade.GetOrderRepository();

        public ActionResult Index()
        {
            IEnumerable<Order> orders = new List<Order>();
            if (User.IsInRole("Admin"))
            {
                orders = OrderRepo.ReadAll();
            }
            else if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                orders = OrderRepo.ReadCustomerOrders(userId);
            }
            return View(orders);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = OrderRepo.Read(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            OrderRepo.Delete(order);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                OrderRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}