using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(iPayment.Core.Services.AppEntry.Startup))]

namespace iPayment.Core.Services.AppEntry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
