using BE;
using Microsoft.AspNet.Identity;
using MVC.Tnfrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrdersGateway OrdersGateway = new OrdersGateway();

        public ActionResult Index()
        {
            IEnumerable<Order> orders = new List<Order>();
            if (User.IsInRole("Admin"))
            {
                HttpResponseMessage response = OrdersGateway.ReadAll();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    orders = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
                }
                else
                {
                    return new HttpStatusCodeResult(response.StatusCode);
                }
            }
            else if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();

                HttpResponseMessage response = OrdersGateway.ReadAll();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    orders = response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
                    orders.Where(order => order.UserId == userId);
                }
                else
                {
                    return new HttpStatusCodeResult(response.StatusCode);
                }
            }
            return View(orders);
        }

        public ActionResult Delete(int? id)
        {
            HttpResponseMessage response = OrdersGateway.Read(id);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Order order = response.Content.ReadAsAsync<Order>().Result;
                HttpResponseMessage deleteResponse = OrdersGateway.Delete(order.Id);
                if (deleteResponse.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
            }
            return new HttpStatusCodeResult(response.StatusCode);
        }
    }
}