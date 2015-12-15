using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace MVC.Infrastructure
{
    public class GenericGateway<T>
    {
        private readonly HttpClient Client;
        private readonly string ExtensionAddress;

        public GenericGateway()
        {
            Client = new HttpClient();
            string baseAddress = WebConfigurationManager.AppSettings["ApiBaseAddress"];
            Client.BaseAddress = new Uri(baseAddress);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            ExtensionAddress = "api/" + typeof(T).Name.ToLower() + "s/";
        }

        public HttpResponseMessage Create(T entity)
        {
            return Client.PostAsJsonAsync(ExtensionAddress, entity).Result;
        }

        public HttpResponseMessage Read(int? id)
        {
            return Client.GetAsync(ExtensionAddress + id).Result;
        }
        
        public HttpResponseMessage ReadAll()
        {
            return Client.GetAsync(ExtensionAddress).Result;
        }

        public HttpResponseMessage Update(T entity)
        {
            return Client.PutAsJsonAsync(ExtensionAddress, entity).Result;
        }

        public HttpResponseMessage Delete(int id)
        {
            return Client.DeleteAsync(ExtensionAddress + id).Result;
        }
    }
}