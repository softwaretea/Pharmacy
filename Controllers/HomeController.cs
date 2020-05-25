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
            Session["Email"] = "";
            return View();
        }

        public ActionResult About()
        {

            Session["Email"] = "";

            return View();
        }

        public ActionResult Contact()
        {
            Session["Email"] = "";

            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ActionName("Login")]
        [HttpGet]
        public ActionResult Login_get()
        {
            Session["Email"] = "";


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
                }
            }
         

            if (Email.Equals("admin@Pharmacy.com") && Password.Equals("123456"))
            {
                //return RedirectToAction("Index", controllerName: "productsController");
                //return RedirectToAction("Index", "ProductsController");
                Session["Email"] = "admin@Pharmacy.com";

                return RedirectToAction("AdminHome","Product");

               
                

            }
            else
            {
                ViewBag.Message = "User name OR password was wrong";


                return View();

            }


        }
        public ActionResult Log_out()
        {
            Session["Email"] = "";
            Session["user_id"] = "";


            return RedirectToAction("Index","Home");
        }
        
        
    }
}