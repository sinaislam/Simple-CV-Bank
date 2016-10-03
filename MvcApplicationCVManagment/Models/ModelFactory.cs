using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Routing;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text.RegularExpressions;
using MvcApplicationCVManagment.Infrastructure;
using MvcApplicationCVManagment.Models;
using DataAccessLayer.DomainModel;

namespace MvcApplicationCVManagment.Models
{
    /// <summary>
    /// A cutdown version of <see cref="Session"/>
    /// with the minimal amount of Session information needed by a client
    /// </summary>
    /// <remarks>
    /// This is a DTO, not an entity backed by a database object
    /// although it derives from <see cref="Session"/>
    /// </remarks>
    public class ModelFactory
    {
        private UrlHelper _urlHelper;
        private ApplicationUserManager _AppUserManager;
        public ModelFactory(HttpRequestMessage request, ApplicationUserManager appUserManager)
        {
            _urlHelper = new UrlHelper(request);
            _AppUserManager = appUserManager;
        }

        public UserReturnModel Create(ApplicationUser appUser)
        {
            return new UserReturnModel
            {
                Url = _urlHelper.Link("GetUserById", new { id = appUser.Id }),
                Id = appUser.Id,
                UserName = appUser.UserName,
                FullName = string.Format("{0} {1}", appUser.FirstName, appUser.LastName),
                Email = appUser.Email,
                EmailConfirmed = appUser.EmailConfirmed,
                Level = appUser.Level,
                JoinDate = appUser.JoinDate,
                Roles = _AppUserManager.GetRolesAsync(appUser.Id).Result,
                Claims = _AppUserManager.GetClaimsAsync(appUser.Id).Result
            };
        }
    }


}
