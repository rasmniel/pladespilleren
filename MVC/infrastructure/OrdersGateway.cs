using System.Net.Http;
using BE;

namespace MVC.Tnfrastructure
{
    public class OrdersGateway : SuperGateway
    {
        private readonly HttpClient Client;

        public OrdersGateway()
        {
            Client = GetClient();
        }
        public HttpResponseMessage Create(Order order)
        {
            return Client.PostAsJsonAsync("api/orders/", order).Result;
        }

        public HttpResponseMessage ReadAll()
        {
            return Client.GetAsync("api/orders/").Result;
        }

        public HttpResponseMessage Read(int? id)
        {
            return Client.GetAsync("api/orders/" + id).Result;
        }

        public HttpResponseMessage Update(Order order)
        {
            return Client.PutAsJsonAsync("api/orders", order).Result;
        }

        public HttpResponseMessage Delete(int id)
        {
            return Client.DeleteAsync("api/orders/" + id).Result;
        }
    }
}