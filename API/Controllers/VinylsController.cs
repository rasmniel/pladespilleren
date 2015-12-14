using System;
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

        // GET api/values
        public HttpResponseMessage Get()
        {
            IEnumerable<Vinyl> vinyls = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.Found, vinyls);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Vinyl vinyl)
        {
            if (vinyl != null)
            {
                Vinyl newVinyl = Repo.Create(vinyl);
                return Request.CreateResponse(HttpStatusCode.Created, newVinyl);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, vinyl);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Vinyl vinyl)
        {
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
