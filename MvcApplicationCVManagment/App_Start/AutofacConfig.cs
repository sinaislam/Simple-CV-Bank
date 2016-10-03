using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Cors;
using MvcApplicationCVManagment.Controllers;
using DataAccessLayer.Service;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace MvcApplicationCVManagment.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterComponents(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();
            //WebApiConfig.Register(config);
            var builder = new ContainerBuilder();
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.Register(c => new SmsGroupService()).As<ISmsGroupService>().InstancePerRequest();


            var container = builder.Build();

            //var resolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = resolver;

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
            //app.UseAutofacWebApi(config); 

        }

    }
}