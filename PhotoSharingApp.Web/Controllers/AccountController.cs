using PhotoSharingApp.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PhotoSharingApp.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    MembershipUser NewUser = Membership.CreateUser(model.UserName, model.Password);
                    //Log the user on with the new account
                   // FormsAuthentication.SetAuthCookie(model.UserName, false);

                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("Registration Error", "Registration error: " + e.StatusCode.ToString());
                }
            }

            return View(model);
        }

        public JsonResult CheckUserName(string UserName)
        {
            if (Membership.FindUsersByName(UserName).Count > 0)
                return Json(false, JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}