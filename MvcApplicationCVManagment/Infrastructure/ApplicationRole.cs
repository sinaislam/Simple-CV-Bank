using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MvcApplicationCVManagment.Infrastructure
{
    public class ApplicationRole : IdentityRole
    {
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        /*public async Task<ClaimsIdentity> GenerateRoleIdentityAsync(RoleManager<ApplicationRole> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }*/

    }
}