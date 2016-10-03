using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.OAuth;
using MvcApplicationCVManagment.App_Start;
using MvcApplicationCVManagment.Controllers;
using MvcApplicationCVManagment.DBBoject;
using MvcApplicationCVManagment.Infrastructure;
using MvcApplicationCVManagment.Providers;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;

[assembly: OwinStartup(typeof(MvcApplicationCVManagment.Startup))]
namespace MvcApplicationCVManagment
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);
            AutofacConfig.RegisterComponents(app);
        }


        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(JOBManageContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                ExpireTimeSpan = TimeSpan.FromDays(2)
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}