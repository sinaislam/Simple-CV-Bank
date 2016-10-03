using Microsoft.AspNet.Identity;
using MvcApplicationCVManagment.DBBoject;
using MvcApplicationCVManagment.Infrastructure;
using MvcApplicationCVManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Host.SystemWeb;
using System.Net.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace MvcApplicationCVManagment.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private JOBManageRepository _repo = null;
        private ApplicationUserManager _AppUserManager = null;
        private ApplicationRoleManager _AppRoleManager = null;
        protected ModelFactory _modelFactory { get; set; }
        public AccountController()
        {
            _repo = new JOBManageRepository();
        }


        public ActionResult Register()
        {
            CreateUserBindingModel model = new CreateUserBindingModel();
            return View(model);
        }
        // POST api/Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(CreateUserBindingModel createUserModel)
        {
            if (!ModelState.IsValid)
            {
                //return BadRequest(ModelState);
                return Json(new
                {
                    success = false,
                    errors = ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                    .Select(m => m.ErrorMessage).ToArray()
                });
            }

            var user = new ApplicationUser()
            {
                UserName = createUserModel.Username,
                Email = createUserModel.Email,
                FirstName = createUserModel.FirstName,
                LastName = createUserModel.LastName,
                Password= createUserModel.Password,
                ConfirmPassword=createUserModel.ConfirmPassword,
                EmailConfirmed = true, //This part will be removed later after email confirmation added
                Level = 3,
                JoinDate = DateTime.Now.Date,
            };

          IdentityResult addUserResult =   await this.AppUserManager.CreateAsync(user, createUserModel.Password);

            if (addUserResult.Succeeded)
            {
                await SignInAsync(user, isPersistent: false);

                return RedirectToAction("Login", "Admin", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "BAL");
            }

        }

        public ActionResult Login()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await this.AppUserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToAction("CVBank", "Admin", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);


            var identity = await this.AppUserManager.CreateIdentityAsync(
               user, DefaultAuthenticationTypes.ApplicationCookie);

            AuthenticationManager.SignIn(
               new AuthenticationProperties()
               {
                   IsPersistent = isPersistent
               }, identity);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        //private IHttpActionResult GetErrorResult(IdentityResult result)
        //{
        //    if (result == null)
        //    {
        //        return InternalServerError();
        //    }

        //    if (!result.Succeeded)
        //    {
        //        if (result.Errors != null)
        //        {
        //            foreach (string error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error);
        //            }
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            // No ModelState errors are available to send, so just return an empty BadRequest.
        //            return BadRequest();
        //        }

        //        return BadRequest(ModelState);
        //    }

        //    return null;
        //}

        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        //protected ModelFactory TheModelFactory
        //{
        //    get
        //    {
        //        if (_modelFactory == null)
        //        {
        //            _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
        //        }
        //        return _modelFactory;
        //    }
        //}

    }
}
