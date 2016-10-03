using DataAccessLayer.DomainModel;
using Microsoft.AspNet.Identity.EntityFramework;
using MvcApplicationCVManagment.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplicationCVManagment.DBBoject
{
    public class JOBManageContext : IdentityDbContext<ApplicationUser>
    {
        public JOBManageContext()
            : base("JobManageContext")
        {

        }

        public static JOBManageContext Create()
        {
            return new JOBManageContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}