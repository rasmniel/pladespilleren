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

        /// <summary>
        /// Get all artists.
        /// </summary>
        /// <returns>Http response containing all artists.</returns>
        public HttpResponseMessage Get()
        {
            IEnumerable<Artist> artists = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, artists);
        }

        /// <summary>
        /// An artist with the specified id.
        /// </summary>
        /// <param name="id">Id of artist.</param>
        /// <returns>Http response containing the specified artist.</returns>
        public HttpResponseMessage Get(int id)
        {
            Artist artist = Repo.Read(id);
            if (artist != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, artist);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Create an artist.
        /// </summary>
        /// <param name="artist">Artist to create.</param>
        /// <returns>Http response containing newly created artist.</returns>
        public HttpResponseMessage Post([FromBody]Artist artist)
        {
            if (artist != null)
            {
                Artist newVinyl = Repo.Create(artist);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, artist);
        }

        /// <summary>
        /// Update an existing artist.
        /// </summary>
        /// <param name="artist">Artist to update.</param>
        /// <returns>Http response.</returns>
        public HttpResponseMessage Put([FromBody]Artist artist)
        {
            if (artist != null)
            {
                Repo.Update(artist);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Delete artist by id.
        /// </summary>
        /// <param name="id">Id of artist to delete.</param>
        /// <returns>Http response.</returns>
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
