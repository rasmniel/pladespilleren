using System.Net;
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
