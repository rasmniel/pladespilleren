using System.Net.Http;
using BE;

namespace MVC.infrastructure
{
    public class GenresGateway : SuperGateway
    {
        private readonly HttpClient Client;

        public GenresGateway()
        {
            Client = GetClient();
        }
        public HttpResponseMessage Create(Genre genre)
        {
            return Client.PostAsJsonAsync("api/genres/", genre).Result;
        }

        public HttpResponseMessage ReadAll()
        {
            return Client.GetAsync("api/genres/").Result;
        }

        public HttpResponseMessage Read(int id)
        {
            return Client.GetAsync("api/genres/" + id).Result;
        }

        public HttpResponseMessage Update(Genre genre)
        {
            return Client.PutAsJsonAsync("api/genres", genre).Result;
        }

        public HttpResponseMessage Delete(int id)
        {
            return Client.DeleteAsync("api/genres/" + id).Result;
        }
    }
}