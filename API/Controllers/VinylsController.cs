using System.Collections.Generic;
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

        // GET api/vinyls
        public HttpResponseMessage Get()
        {
            IEnumerable<Vinyl> vinyls = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, vinyls);
        }

        // GET api/vinyls/5
        public HttpResponseMessage Get(int id)
        {
            Vinyl vinyl = Repo.Read(id);
            if (vinyl != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, vinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/vinyls
        public HttpResponseMessage Post([FromBody]Vinyl vinyl)
        {
            if (vinyl != null)
            {
                Vinyl newVinyl = Repo.Create(vinyl);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, vinyl);
        }

        // PUT api/values/5
        public HttpResponseMessage Put([FromBody]Vinyl vinyl)
        {
            if (vinyl != null)
            {
                Repo.Update(vinyl);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            Vinyl toDelete = Repo.Read(id);
            if (toDelete != null)
            {
                Repo.Delete(toDelete);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
