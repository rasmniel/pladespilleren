using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;

namespace MVC.Tnfrastructure
{
    public class SuperGateway
    {
        // Instanciate a HttpClient
        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            string baseAddress = WebConfigurationManager.AppSettings["ApiBaseAddress"];
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}