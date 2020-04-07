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
            ViewBag.Message = "Login";

            return View();

        }

        [ActionName("Login")]

        [HttpPost]
        public ActionResult Login_post(String Email, int Password)
        {


            if (Email == "admin@Pharmacy.com" && Password == 123456)
            {
                //return RedirectToAction("Index", controllerName: "productsController");
                //return RedirectToAction("Index", "ProductsController");
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index");

            }


        }

    }
}