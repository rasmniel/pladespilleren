using BE;
using DAL;
using DAL.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class GenresController : ApiController
    {
        private readonly GenreRepository Repo = DALFacade.GetGenreRepository();

        // GET api/genres
        public HttpResponseMessage Get()
        {
            IEnumerable<Genre> genres = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, genres);
        }

        // GET api/genres/5
        public HttpResponseMessage Get(int id)
        {
            Genre genre = Repo.Read(id);
            if (genre != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, genre);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // POST api/genres
        public HttpResponseMessage Post([FromBody]Genre genre)
        {
            if (genre != null)
            {
                Genre newVinyl = Repo.Create(genre);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, genre);
        }

        // PUT api/genres/5
        public HttpResponseMessage Put([FromBody]Genre genre)
        {
            if (genre != null)
            {
                Repo.Update(genre);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE api/genres/5
        public HttpResponseMessage Delete(int id)
        {
            Genre toDelete = Repo.Read(id);
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
