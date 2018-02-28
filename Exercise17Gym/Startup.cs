using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exercise17Gym.Startup))]
namespace Exercise17Gym
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
