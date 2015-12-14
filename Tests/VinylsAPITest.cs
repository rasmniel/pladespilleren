using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using BE;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VinylsApiTest
    {
        private HttpClient client;
        private Vinyl testVinyl;

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

            // Instantiate test vinyl.
            testVinyl = new Vinyl()
            {
                Id = 0,
                Name = "Test",
                Price = 100,
                Year = 1999
            };
            HttpResponseMessage response = client.PostAsJsonAsync("api/vinyls/", testVinyl).Result;
            testVinyl = response.Content.ReadAsAsync<Vinyl>().Result;
        }

        [Test]
        public void PostVinylTest()
        {
            Assert.AreNotEqual(0, testVinyl.Id);
        }

        // Read all vinyls test
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

        // Read 1 vinyl test
        [Test]
        public void ReadVinylTest()
        {
            HttpResponseMessage response = client.GetAsync("api/vinyls/" + testVinyl.Id).Result;
            Vinyl vinyl = response.Content.ReadAsAsync<Vinyl>().Result;

            // Test if there is a vinyl present
            Assert.NotNull(vinyl);
        }

        // Update vinyl test
        [Test]
        public void PutVinylTest()
        {
            HttpResponseMessage response = client.GetAsync("api/vinyls/" + testVinyl.Id).Result;
            Vinyl vinyl = response.Content.ReadAsAsync<Vinyl>().Result;

            // Change vinyl name
            vinyl.Name = "test";
            HttpResponseMessage putResponse = client.PutAsJsonAsync("api/vinyls/", vinyl).Result;
            Assert.AreEqual(HttpStatusCode.OK, putResponse.StatusCode);
        }

        [Test]
        public void DeleteVinylTest()
        {
            HttpResponseMessage deleteResponse = client.DeleteAsync("api/vinyls/" + testVinyl.Id).Result;
            Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);
        }
    }
}
