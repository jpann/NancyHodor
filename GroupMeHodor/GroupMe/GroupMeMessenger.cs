using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using GroupMeHodor.Http;
using Nancy.Json;

namespace GroupMeHodor.GroupMe
{
    public class GroupMeMessenger : IGroupMeMessenger
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
            get { return this.mBotName;  }
        }

        public string[] IgnoreNames
        {
            get { return this.mIgnoreNames; }
        }

        public GroupMeMessenger(
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
            string json = new JavaScriptSerializer().Serialize(new
            {
                text = message,
                bot_id = this.mBotId
            });

            string result = this.mHttpClient.Post(this.mEndpointUrl, json);

            return true;
        }
    }
}
