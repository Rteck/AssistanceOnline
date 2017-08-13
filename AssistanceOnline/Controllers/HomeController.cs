using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AssistanceOnlineBLL;
using AssistanceOnlineDAL;

namespace AssistanceOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string fk = null)
        {
            if (fk != null)
            {
                if (Session["user"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    Session["user"] = UserBLL.findUserByToken(fk);
                    return View();
                }
               
                
            }
            else
            {
                if (Session["user"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return View();
                }
               
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}