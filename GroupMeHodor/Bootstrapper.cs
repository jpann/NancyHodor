using System.Collections.Specialized;
using System.Net.Mime;
using GroupMeHodor.GroupMe;
using GroupMeHodor.Http;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Ninject;
using Ninject;

namespace GroupMeHodor
{
    using Nancy;

    //https://github.com/NancyFx/Nancy.Bootstrappers.Ninject
    public class Bootstrapper : NinjectNancyBootstrapper
    {
        protected override void ApplicationStartup(IKernel container, IPipelines pipelines)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during application startup.
        }

        protected override void ConfigureApplicationContainer(IKernel existingContainer)
        {
            // Perform registation that should have an application lifetime

            StringCollection ignoreNames = Properties.Settings.Default.IgnoreNames;

            existingContainer.Bind<IHttpClient>()
                .To<SimpleHttpClient>();

            existingContainer.Bind<IGroupMeMessenger>()
                .To<GroupMeMessenger>()
                .WithConstructorArgument("botId", Properties.Settings.Default.BotId)
                .WithConstructorArgument("botName", Properties.Settings.Default.BotName)
                .WithConstructorArgument("ignoreNames", ignoreNames)
                .WithConstructorArgument("endPointUrl", Properties.Settings.Default.EndPointUrl);

            existingContainer.Bind<Hodor>().ToSelf();
        }

        protected override void ConfigureRequestContainer(IKernel container, NancyContext context)
        {
            // Perform registrations that should have a request lifetime
        }

        protected override void RequestStartup(IKernel container, IPipelines pipelines, NancyContext context)
        {
            // No registrations should be performed in here, however you may
            // resolve things that are needed during request startup.
        }
    }
}