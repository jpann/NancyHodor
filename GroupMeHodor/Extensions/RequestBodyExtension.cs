using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nancy.IO;

namespace GroupMeHodor.Extensions
{
    public static class RequestBodyExtensions
    {
        public static string ReadAsString(this RequestStream requestStream)
        {
            using (var reader = new StreamReader(requestStream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
