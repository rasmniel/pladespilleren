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
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
