using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BE;
using DAL;
using DAL.Repositories;

namespace API.Controllers
{
    public class VinylsController : ApiController
    {
        private readonly VinylRepository Repo = DALFacade.GetVinylRepository();

        /// <summary>
        /// Get all vinyls.
        /// </summary>
        /// <returns>Http response.</returns>
        public HttpResponseMessage Get()
        {
            IEnumerable<Vinyl> vinyls = Repo.ReadAll();
            if (vinyls.Any())
            {
                return Request.CreateResponse(HttpStatusCode.OK, vinyls);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Get a vinyl.
        /// </summary>
        /// <param name="id">Id of the vinyl to get.</param>
        /// <returns>Http response including a vinyl.</returns>
        public HttpResponseMessage Get(int id)
        {
            Vinyl vinyl = Repo.Read(id);
            if (vinyl != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, vinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Create a vinyl.
        /// </summary>
        /// <param name="vinyl">The vinyl to create.</param>
        /// <returns>Http response including the newly created vinyl.</returns>
        public HttpResponseMessage Post([FromBody]Vinyl vinyl)
        {
            if (vinyl != null)
            {
                Vinyl newVinyl = Repo.Create(vinyl);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, vinyl);
        }

        /// <summary>
        /// Update a vinyl.
        /// </summary>
        /// <param name="vinyl">The vinyl to update.</param>
        /// <returns>Http response.</returns>
        public HttpResponseMessage Put([FromBody]Vinyl vinyl)
        {
            if (vinyl != null)
            {
                Repo.Update(vinyl);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Delete a vinyl.
        /// </summary>
        /// <param name="id">Id of the vinyl to delete.</param>
        /// <returns>Http response.</returns>
        public HttpResponseMessage Delete(int id)
        {
            Vinyl toDelete = Repo.Read(id);
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
