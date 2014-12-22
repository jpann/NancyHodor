using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace GroupMeHodor.Tests
{
    [TestFixture]
    public class HodorTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            
        }

        [Test]
        public void PostRequest_Question_OK()
        {
            string postJsonBody = @"{
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

            var bootstrapper = new FakeNinjectNancyBootstrapper();

            var browser = new Browser(
                bootstrapper);

            var response = browser.Post("/",
                with =>
                {
                    with.HttpRequest();
                    with.Body(postJsonBody);
                    with.Header("content-type", "application/json");
                });

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void PostRequest_Invalid()
        {
            string invalidBody = @"{
                ""notvalidparam"":""SOME_VALUE""
            }";

            var bootstrapper = new FakeNinjectNancyBootstrapper();

            var browser = new Browser(
                bootstrapper);

            var response = browser.Post("/",
                with =>
                {
                    with.HttpRequest();
                    with.Body(invalidBody);
                    with.Header("content-type", "application/json");
                });

            Assert.AreEqual(HttpStatusCode.NotAcceptable, response.StatusCode);
        }

        [Test]
        public void GetRequest_Question_NotImplemented()
        {
            string postJsonBody = @"{
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

            var bootstrapper = new FakeNinjectNancyBootstrapper();
            var browser = new Browser(
                bootstrapper);

            var response = browser.Get("/",
                with =>
                {
                    with.HttpRequest();
                    with.Body(postJsonBody);
                    with.Header("content-type", "application/json");
                });

            Assert.AreEqual(HttpStatusCode.NotImplemented, response.StatusCode);
        }
    }
}
