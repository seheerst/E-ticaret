using System.Reflection;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using PathString = Microsoft.Owin.PathString;


namespace EticaretWeb;
[Assembly: OwinStartup(typeof(EticaretWeb.Startup))]

public class Startup
{
    public void Configuration(IAppBuilder app)
    {
        app.UseCookieAuthentication(new CookieAuthenticationOptions()
        {
            AuthenticationType = "ApplicationCookie",
            LoginPath = new PathString("/Account/Login")

        });
    }
}