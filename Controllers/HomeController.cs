using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PahramcyOnline.Models;

namespace PahramcyOnline.Controllers
{
    public class HomeController : Controller
    {
        public int x;
        private pharmacyEntities db = new pharmacyEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {


            return View();
        }

      
        [ActionName("Login")]
        [HttpGet]
        public ActionResult Login_get()
        {


            return View();

        }

        [ActionName("Login")]

        [HttpPost]
        public ActionResult Login_post(String Email, String Password)
        {

            if (ModelState.IsValid)
            {
                {
                    var obj = db.Users.Where(a => a.User_Name.Equals(Email) && a.password.Equals(Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["user_id"] = (int)obj.Id_user;
                        Session["UserName"] = obj.User_Name.ToString();
                        this.x = obj.Id_user;
                        return RedirectToAction("UserHome", "Users");
                    }


                    var obj1 = db.Admins.Where(a => a.Email_Admin.Equals(Email) && a.Password_Admin.Equals(Password)).FirstOrDefault();
                    if (obj1 != null)
                    {
                        Session["admin_id"] = (int)obj1.Id_admin;
                        Session["UserName"] = obj1.Email_Admin.ToString();
                        this.x = obj1.Id_admin;
                        return RedirectToAction("AdminHome", "Admins");
                    }
                    else
                    {
                        ViewBag.Message = "User name OR password was wrong";
                        return View();
                    }
                }
            }
            return RedirectToAction("Login", "Home");


        }


        public ActionResult Log_out()
        {
            Session["Email"] = "";
            Session["user_id"] = "";
            Session["number"] ="";

            return RedirectToAction("Index","Home");
        }
        
        
    }
}