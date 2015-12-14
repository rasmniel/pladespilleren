using System.Net.Http;
using BE;

namespace MVC.infrastructure
{
    public class ArtistsGateway : SuperGateway
    {
        private readonly HttpClient Client;

        public ArtistsGateway()
        {
            Client = GetClient();
        }
        public HttpResponseMessage Create(Artist artist)
        {
            return Client.PostAsJsonAsync("api/artists/", artist).Result;
        }

        public HttpResponseMessage ReadAll()
        {
            return Client.GetAsync("api/artists/").Result;
        }

        public HttpResponseMessage Read(int id)
        {
            return Client.GetAsync("api/artists/" + id).Result;
        }

        public HttpResponseMessage Update(Artist artist)
        {
            return Client.PutAsJsonAsync("api/artists", artist).Result;
        }

        public HttpResponseMessage Delete(int id)
        {
            return Client.DeleteAsync("api/artists/" + id).Result;
        }
    }
}