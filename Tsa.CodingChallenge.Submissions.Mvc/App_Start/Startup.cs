using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Tsa.CodingChallenge.Submissions.Mvc;

[assembly: OwinStartup(typeof(Startup))]

namespace Tsa.CodingChallenge.Submissions.Mvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) { ConfigureAuth(app); }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    Provider = new CookieAuthenticationProvider()
                });
        }
    }
}