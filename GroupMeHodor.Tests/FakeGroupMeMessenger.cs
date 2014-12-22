using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupMeHodor.GroupMe;
using GroupMeHodor.Http;

namespace GroupMeHodor.Tests
{
    public class FakeGroupMeMessenger : IGroupMeMessenger
    {
        private readonly IHttpClient mHttpClient;
        private readonly string mBotId;
        private readonly string mBotName;
        private readonly string mEndpointUrl;
        private readonly string[] mIgnoreNames;

        public string BotId
        {
            get { return this.mBotId; }
        }

        public string BotName
        {
            get { return this.mBotName; }
        }

        public string[] IgnoreNames
        {
            get { return this.mIgnoreNames; }
        }

        public FakeGroupMeMessenger(
            string botId,
            string botName,
            string[] ignoreNames,
            string endPointUrl,
            IHttpClient httpClient)
        {
            if (string.IsNullOrEmpty(botId))
                throw new ArgumentException("botId");

            if (string.IsNullOrEmpty(botName))
                throw new ArgumentException("botName");

            if (string.IsNullOrEmpty(endPointUrl))
                throw new ArgumentException("endPointUrl");

            if (httpClient == null)
                throw new ArgumentNullException("httpClient");

            this.mBotId = botId;
            this.mBotName = botName;
            this.mIgnoreNames = ignoreNames;
            this.mEndpointUrl = endPointUrl;
            this.mHttpClient = httpClient;
        }

        public bool SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                throw new ArgumentException("message");

            return true;
        }
    }
}
