using KgisReports.BO;
using KgisReports.Models;
using KgisReports.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KgisReports.Controllers
{
    public class AccountController : Controller
    {
        private UserService userService = new UserService();

        public ActionResult LoginPage()
        {
            return View();
        }

        public ActionResult LoginAuthorization(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("LoginPage", model);
            }
            if (Utils.IsExtraAccess(model.LoginOrEmail, model.Password))
            {
                Utils.SetExtraAccessUser();
                return RedirectToAction("Index", "Home");
            }
            if (userService.AuthorizeUser(model.LoginOrEmail, model.Password))
            {
                Utils.SetApplicationUser(model.LoginOrEmail);
                return RedirectToAction("Index", "Home");
            }

            ViewData["error"] = "Niepoprawne dane logowania.";
            return View("LoginPage", model);
        }

        public ActionResult LogOff()
        {
            Utils.SetApplicationUser(null);
            return RedirectToAction("Index", "Home");
        }
    }
}