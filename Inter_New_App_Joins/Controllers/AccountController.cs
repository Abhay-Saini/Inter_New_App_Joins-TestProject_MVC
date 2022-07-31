using Inter_New_App_Joins.DbConnection;
using Inter_New_App_Joins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inter_New_App_Joins.Controllers
{
    public class AccountController : Controller
    {
        NewSchoolDb290722Entities1 obj = new NewSchoolDb290722Entities1();
        // GET: Account
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(UserModel user)
        {
            tbl_UserInfo tbl = new tbl_UserInfo()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };

            obj.tbl_UserInfo.Add(tbl);
            obj.SaveChanges();

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserModel user)
        {
            var data = obj.tbl_UserInfo.Where(m => m.Email == user.Email).FirstOrDefault();

            if (data != null)
            {

                if (data.Email == user.Email && data.Password == user.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.Name, false);

                    return RedirectToAction( "Welcome", "Home");

                }
                else
                {
                    TempData["InvalidPass"] = "Invalid Password try Again";
                }
            }
            else
            {
                TempData["InvalidEmail"] = "Invalid Email try Again";
            }

            return View();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }



    }
}
