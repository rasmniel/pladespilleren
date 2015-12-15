using System.Net.Http;
using BE;

namespace MVC.Tnfrastructure
{
    public class VinylsGateway : SuperGateway
    {
        private readonly HttpClient Client;

        public VinylsGateway()
        {
            Client = GetClient();
        }
        public HttpResponseMessage Create(Vinyl vinyl)
        {
            return Client.PostAsJsonAsync("api/vinyls/", vinyl).Result;
        }

        public HttpResponseMessage ReadAll()
        {
            return Client.GetAsync("api/vinyls/").Result;
        }

        public HttpResponseMessage Read(int? id)
        {
            return Client.GetAsync("api/vinyls/" + id).Result;
        }

        public HttpResponseMessage Update(Vinyl vinyl)
        {
            return Client.PutAsJsonAsync("api/vinyls", vinyl).Result;
        }

        public HttpResponseMessage Delete(int id)
        {
            return Client.DeleteAsync("api/vinyls/" + id).Result;
        }
    }
}