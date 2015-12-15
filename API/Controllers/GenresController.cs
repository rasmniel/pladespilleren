using BE;
using DAL;
using DAL.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    /// <summary>
    /// Controller to manage genres.
    /// </summary>
    public class GenresController : ApiController
    {
        private readonly GenreRepository Repo = DALFacade.GetGenreRepository();

        /// <summary>
        /// Get all genres.
        /// </summary>
        /// <returns>Http response containing all genres.</returns>
        public HttpResponseMessage Get()
        {
            IEnumerable<Genre> genres = Repo.ReadAll();
            return Request.CreateResponse(HttpStatusCode.OK, genres);
        }

        /// <summary>
        /// Get a specified genre.
        /// </summary>
        /// <param name="id">Id of genre.</param>
        /// <returns>Http response containing the specified genre.</returns>
        public HttpResponseMessage Get(int id)
        {
            Genre genre = Repo.Read(id);
            if (genre != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, genre);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Create a genre.
        /// </summary>
        /// <param name="genre">Genre to create.</param>
        /// <returns>Http response containing the newly created genre.</returns>
        public HttpResponseMessage Post([FromBody]Genre genre)
        {
            if (genre != null)
            {
                Genre newVinyl = Repo.Create(genre);
                return Request.CreateResponse(HttpStatusCode.OK, newVinyl);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, genre);
        }

        /// <summary>
        /// Update an existing genre.
        /// </summary>
        /// <param name="genre">Genre to update.</param>
        /// <returns>Http response.</returns>
        public HttpResponseMessage Put([FromBody]Genre genre)
        {
            if (genre != null)
            {
                Repo.Update(genre);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Delete genre by id.
        /// </summary>
        /// <param name="id">Id of genre to delete.</param>
        /// <returns>Http response.</returns>
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
