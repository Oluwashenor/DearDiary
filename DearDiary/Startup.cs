using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DearDiary.Startup))]
namespace DearDiary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
