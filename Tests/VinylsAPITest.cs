﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using BE;
using NUnit.Framework;
using System.Net;

namespace Tests
{
    [TestFixture]
    public class VinylsApiTest
    {
        private HttpClient client;

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

        [Test]
        public void PostVinylTest()
        {
            Vinyl testVinyl = new Vinyl()
            {
                Id = 0,
                Name = "Test",
                Price = 100,
                Year = 1999
            };

            HttpResponseMessage response = client.PostAsJsonAsync("api/vinyls/", testVinyl).Result;
            Vinyl created = response.Content.ReadAsAsync<Vinyl>().Result;
            Assert.AreNotEqual(0, created.Id);
        }

        [Test]
        public void DeleteVinylTest()
        {
            Vinyl testVinyl = new Vinyl()
            {
                Id = 0,
                Name = "Test",
                Price = 100,
                Year = 1999
            };

            HttpResponseMessage postResponse = client.PostAsJsonAsync("api/vinyls/", testVinyl).Result;
            Vinyl created = postResponse.Content.ReadAsAsync<Vinyl>().Result;

            HttpResponseMessage deleteResponse = client.DeleteAsync("api/vinyls/" + created.Id).Result;
            Assert.AreEqual(HttpStatusCode.OK, deleteResponse.StatusCode);
        }

    }
}
