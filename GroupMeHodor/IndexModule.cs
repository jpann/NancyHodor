using System;
using System.Linq;
using GroupMeHodor.GroupMe;
using Nancy.Extensions;
using Nancy.ModelBinding;

namespace GroupMeHodor
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule(
            IGroupMeMessenger groupMeMessenger, 
            Hodor hodor,
            Random random)
        {
            Get["/"] = parameters =>
            {
                return HttpStatusCode.NotImplemented;
            };
             
            Post["/"] = parameters =>
            {
                var message = new GroupMeMessage();

                string request = this.Request.Body.AsString();

                // Bind the request to GroupMeMessage
                this.BindTo<GroupMeMessage>(message);

                // Don't respond to ourself
                if (message.name == groupMeMessenger.BotName)
                    return HttpStatusCode.OK;

                if (groupMeMessenger.IgnoreNames != null)
                    if (groupMeMessenger.IgnoreNames.Contains(message.name))
                        return HttpStatusCode.OK;

                if (message.text.EndsWith("?"))
                    if (random.Next(0, 1) <= 1)
                    {
                        string random_hodor = hodor.GetRandom();
                        if (!string.IsNullOrEmpty(random_hodor))
                            groupMeMessenger.SendMessage(random_hodor);
                    }

                return HttpStatusCode.OK;
            };
        }
    }
}