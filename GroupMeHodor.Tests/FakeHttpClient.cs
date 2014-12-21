using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupMeHodor.Http;

namespace GroupMeHodor.Tests
{
    class FakeHttpClient : IHttpClient
    {
        public FakeHttpClient()
        {
            
        }

        public string Post(string url, string json)
        {
            return "";
        }
    }
}
