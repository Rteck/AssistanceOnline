using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssistanceOnlineBLL;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AssistanceOnlineUtilities;

namespace AssistanceOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login()
        {
            var response = Request["g-recaptcha-response"];
           
            if (Utilities.verifyReCapchat(response))
            {
                return RedirectToAction("Index", "Users");
            }

            return View("Index");
            
        }

        [HttpGet]
        public ActionResult createAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult createAcount()
        {
            return View("Index");
        }

        public ActionResult forgotPassword()
        {
            return RedirectToAction("","");
        }
    }
}