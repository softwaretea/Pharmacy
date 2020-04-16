using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PahramcyOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [ActionName("Login")]
        [HttpGet]
        public ActionResult Login_get()
        {

            Session["Email"] = "admin@Pharmacy.com";

            return View();

        }

        [ActionName("Login")]

        [HttpPost]
        public ActionResult Login_post(String Email, String Password)
        {


            if (Email.Equals("admin@Pharmacy.com") && Password.Equals("123456"))
            { 
                //return RedirectToAction("Index", controllerName: "productsController");
                //return RedirectToAction("Index", "ProductsController");
                return RedirectToAction("AdminHome","Product");

               
                

            }
            else
            {
                ViewBag.Message = "not matched";


                return View();

            }


        }

    }
}