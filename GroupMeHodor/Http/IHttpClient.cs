using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupMeHodor.Http
{
    public interface IHttpClient
    {
        string Post(string url, string json);
    }
}
