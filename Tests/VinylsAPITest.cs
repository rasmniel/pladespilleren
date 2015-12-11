using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using BE;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VinylsApiTest
    {
        HttpClient client;

        [SetUp]
        public void Setup()
        {
            // Get the base address value from App.config
            string baseAddress = ConfigurationManager.AppSettings["ApiBaseAddress"];

            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        [Test]
        public void ReadAllVinylsTest()
        {
            HttpResponseMessage response = client.GetAsync("api/vinyls/").Result;
            var vinyls = response.Content.ReadAsAsync<IEnumerable<Vinyl>>().Result;

            // Test if any vinyls exsists, if not, fail test
            if (!vinyls.Any())
            {
                Assert.Fail();
            }
            else
            {
                // Test if artist and genre are not null, if not, test successful
                Vinyl vinyl = vinyls.First();
                Assert.False(vinyl.Artist == null || vinyl.Genre == null);
            }
        }
    }
}
