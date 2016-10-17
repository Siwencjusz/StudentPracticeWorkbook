using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentPracticeWorkbook.Startup))]
namespace StudentPracticeWorkbook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
