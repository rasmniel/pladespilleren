using BE;
using DAL;
using DAL.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly ArtistRepository Repo = DALFacade.GetArtistRepository();

        // GET api/artists
        public HttpResponseMessage Get()
        {
            IEnumerable<Artist> artists = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, artists);
        }

        // GET api/artists/5
        public HttpResponseMessage Get(int id)
        {
            Artist artist = Repo.Read(id);
            if (artist != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, artist);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/artists
        public HttpResponseMessage Post([FromBody]Artist artist)
        {
            if (artist != null)
            {
                Artist newVinyl = Repo.Create(artist);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, artist);
        }

        // PUT api/artists/5
        public HttpResponseMessage Put([FromBody]Artist artist)
        {
            if (artist != null)
            {
                Repo.Update(artist);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/artists/5
        public HttpResponseMessage Delete(int id)
        {
            Artist toDelete = Repo.Read(id);
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
