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
    public class AutofacConfigMvc : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SmsGroupService()).As<ISmsGroupService>().InstancePerRequest();
            builder.Register(c => new ApplicantService()).As<IApplicantService>().InstancePerRequest();
            base.Load(builder);

        }

    }
}