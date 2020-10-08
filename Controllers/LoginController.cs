using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_completion.Models;

namespace Task_completion.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome " + Session["username"];
            return View();
        }
        public ActionResult UserLogin()
        {           
            return View();
        }
        public JsonResult ValidateUser(string username,string password)
        {
            bool isRedirect = false;
            testEntities testEntities = new testEntities();
            var q = from p in testEntities.Users
                    where p.UserName == username && p.Password == password
                    select p;
                      
            if (q.Count() > 0)
            {               
                Session["username"] = username;
                // return Json(new{ redirectUrl = Url.Action("Index", "Home"), isRedirect = true });    
                return Json(new { isRedirect = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isRedirect = false }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult ValidateUserRegistration(UserRegistration LoginObject)
        {
            testEntities db = new testEntities();
            db.SaveChanges();
            //  return RedirectToAction("UserLogin");
            return Json(new { isRedirect = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UserRegistration()
        {
            return View();
        }
    }
}