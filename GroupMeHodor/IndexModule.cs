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
        private string[] mHodors = new string[]
        {
            "Hodor",
            "Hodor!",
            "HODOR",
            "Hodor?",
            "Hodooorrr",
            "HODOR!!!"
        };

        public IndexModule(IGroupMeMessenger groupMeMessenger, Random random)
        {
            Get["/"] = parameters =>
            {
                return "NOPE";
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
                    if (random.Next(0, 1000) <= 10)
                    {
                        string hodor = this.GetRandomHodor(random);
                        groupMeMessenger.SendMessage(hodor);
                    }

                return HttpStatusCode.OK;
            };
        }

        private string GetRandomHodor(Random rand)
        {
            int index = rand.Next(0, this.mHodors.Length);

            return this.mHodors[index];
        }
    }
}