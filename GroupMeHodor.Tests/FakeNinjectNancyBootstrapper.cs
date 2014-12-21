using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using GroupMeHodor.GroupMe;
using GroupMeHodor.Http;
using Nancy.Bootstrappers.Ninject;
using Ninject;

namespace GroupMeHodor.Tests
{
    public class FakeNinjectNancyBootstrapper : NinjectNancyBootstrapper
    {
        public FakeNinjectNancyBootstrapper()
        {
            
        }

        protected override void ConfigureApplicationContainer(IKernel existingContainer)
        {
            // Perform registation that should have an application lifetime

            StringCollection ignoreNames = new StringCollection();

            existingContainer.Bind<IHttpClient>()
                .To<FakeHttpClient>();

            existingContainer.Bind<IGroupMeMessenger>()
                .To<FakeGroupMeMessenger>()
                .WithConstructorArgument("botId", "BOT_ID")
                .WithConstructorArgument("botName", "BOT_NAME")
                .WithConstructorArgument("ignoreNames", ignoreNames)
                .WithConstructorArgument("endPointUrl", "https://api.groupme.com/v3/bots/post");

            existingContainer.Bind<Hodor>().ToSelf();
        }
    }
}
