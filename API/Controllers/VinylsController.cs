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
        public HttpResponseMessage Get(int id)
        {
            Vinyl vinyl = Repo.Read(id);
            return Request.CreateResponse(HttpStatusCode.Found, vinyl);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public HttpResponseMessage Put([FromBody]Vinyl vinyl)
        {
            Repo.Update(vinyl);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
