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

        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns>Http response including all orders.</returns>
        public HttpResponseMessage Get()
        {
            IEnumerable<Order> orders = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, orders);
        }

        /// <summary>
        /// Get an order.
        /// </summary>
        /// <param name="id">Id of the order to get.</param>
        /// <returns>Http response including an order.</returns>
        public HttpResponseMessage Get(int id)
        {
            Order order = Repo.Read(id);
            if (order != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, order);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Create an order.
        /// </summary>
        /// <param name="order">Order to create.</param>
        /// <returns>Http response including the newly created order.</returns>
        public HttpResponseMessage Post([FromBody]Order order)
        {
            if (order != null)
            {
                Order newVinyl = Repo.Create(order);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, order);
        }

        /// <summary>
        /// Update an existing order.
        /// </summary>
        /// <param name="order">Order to update.</param>
        /// <returns>Http response.</returns>
        public HttpResponseMessage Put([FromBody]Order order)
        {
            if (order != null)
            {
                Repo.Update(order);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Delete an order.
        /// </summary>
        /// <param name="id">Id of the order to delete.</param>
        /// <returns>Http response.</returns>
        public HttpResponseMessage Delete(int id)
        {
            Order toDelete = Repo.Read(id);
            if (toDelete != null)
            {
                Repo.Delete(toDelete);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
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
