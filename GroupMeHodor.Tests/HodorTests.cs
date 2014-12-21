using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace GroupMeHodor.Tests
{
    [TestFixture]
    public class HodorTests
    {
        // Sample message posted to the application from a GroupMe group.
        private string postJsonBody = @"{
    ""id"":""141909488216484256"",
    ""source_guid"":""b4182bb58a18ba162b29434"",
    ""created_at"":1419094882,
    ""user_id"":""111111"",
    ""group_id"":""9999999"",
    ""name"":""User Name"",
    ""avatar_url"":""https://i.groupme.com/668x401.jpeg"",
    ""text"":""This is a test message?"",
    ""system"":false,
    ""attachments"":[
    ]
}";
        
        [SetUp]
        public void SetUp()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void Post_Question_OK()
        {
            var bootstrapper = new FakeNinjectNancyBootstrapper();
            var browser = new Browser(
                bootstrapper,
                defaults: to => to.Accept("application/json"));

            var response = browser.Post("/",
                with =>
                {
                    with.HttpRequest();
                    with.Body(postJsonBody);
                });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void Get_Question_NotImplemented()
        {
            var bootstrapper = new FakeNinjectNancyBootstrapper();
            var browser = new Browser(
                bootstrapper,
                defaults: to => to.Accept("application/json"));

            var response = browser.Get("/",
                with =>
                {
                    with.HttpRequest();
                    with.Body(postJsonBody);
                });

            Assert.AreEqual(HttpStatusCode.NotImplemented, response.StatusCode);
        }
    }
}
