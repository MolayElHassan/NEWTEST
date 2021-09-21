using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NEWTEST.Controllers
{
    public class USERSController : Controller
    {
        NEWTESTEntities db = new NEWTESTEntities();

        [Route("")]
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TBL_USERS objUser)
        {
            if (ModelState.IsValid)
            {
                using (db)
                {
                    var obj = db.TBL_USERS.Where(a => a.U_EMAIL.Equals(objUser.U_EMAIL) && a.U_PASSWORD.Equals(objUser.U_PASSWORD)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UID"] = obj.U_ID.ToString();
                        Session["UEmail"] = obj.U_EMAIL.ToString();
                        Session["URID"] = obj.U_TYPE.ToString();
                        return RedirectToAction("Desh");
                    }
                    else
                    {
                        ViewBag.error = "Email or Password is wrong!";
                        return View();
                    }
                }
            }
            return View(objUser);
        }

        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TBL_USERS user)
        {
            if (ModelState.IsValid)
            {
                var check = db.TBL_USERS.FirstOrDefault(s => s.U_EMAIL == user.U_EMAIL);
                if (check == null)
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    user.U_TYPE = 1;
                    db.TBL_USERS.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();


        }

        [Route("LogOut")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}