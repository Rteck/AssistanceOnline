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
using AssistanceOnlineDAL;

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
        [ValidateAntiForgeryToken]
        public ActionResult createAccount([Bind(Include = "idUser,name,lastName,email,password")] User user)
        {
            var response = Request["g-recaptcha-response"];

            if (Utilities.verifyReCapchat(response))
            {
                user.creationDate       =   DateTime.UtcNow;
                user.modificationDate   =   DateTime.UtcNow;
                user.active             =   false;

                if (UserBLL.AddUser(user))
                {
                    Utilities.sendEmailVerification(user);

                    return View("Index");
                }
                else
                {
                    return View();
                }
            }
            return View();        
        }

        public ActionResult forgotPassword()
        {
            return RedirectToAction("","");
        }
    }
}