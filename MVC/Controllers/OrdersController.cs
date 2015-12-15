using BE;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;
using MVC.Infrastructure;

namespace MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly GenericGateway<Order> OrdersGateway = new GenericGateway<Order>();

        public ActionResult Index()
        {
            HttpResponseMessage response = OrdersGateway.ReadAll();
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            IEnumerable<Order> orders = new List<Order>();

            if (User.IsInRole("Admin"))
            {
                orders = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
            }
            else if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                orders = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
                orders.Where(order => order.UserId == userId);
            }
            return View(orders);
        }

        public ActionResult Delete(int? id)
        {
            HttpResponseMessage response = OrdersGateway.Read(id);
            if (!response.IsSuccessStatusCode)
                return new HttpStatusCodeResult(response.StatusCode);
            Order order = response.Content.ReadAsAsync<Order>().Result;

            HttpResponseMessage deleteResponse = OrdersGateway.Delete(order.Id);
            if (!deleteResponse.IsSuccessStatusCode)
                return new HttpStatusCodeResult(deleteResponse.StatusCode);

            return RedirectToAction("Index");
        }
    }
}