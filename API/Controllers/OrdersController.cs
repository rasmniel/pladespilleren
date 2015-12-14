using BE;
using DAL;
using DAL.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly OrderRepository Repo = DALFacade.GetOrderRepository();

        // GET api/orders
        public HttpResponseMessage Get()
        {
            IEnumerable<Order> orders = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }

        // GET api/orders/5
        public HttpResponseMessage Get(int id)
        {
            Order order = Repo.Read(id);
            if (order != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, order);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/orders
        public HttpResponseMessage Post([FromBody]Order order)
        {
            if (order != null)
            {
                Order newVinyl = Repo.Create(order);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, order);
        }

        // PUT api/orders/5
        public HttpResponseMessage Put([FromBody]Order order)
        {
            if (order != null)
            {
                Repo.Update(order);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/orders/5
        public HttpResponseMessage Delete(int id)
        {
            Order toDelete = Repo.Read(id);
            if (toDelete != null)
            {
                Repo.Delete(toDelete);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
