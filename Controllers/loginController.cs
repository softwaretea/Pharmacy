/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PahramcyOnline.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult login( String Email, int Password)
        {
             if(Email==null)
            {
                ViewBag.message = "Email can't be null";
            }
             
            else if(Email=="admin@gmail.com"&&Password==123456)
            {
                return View(Home);
            }
            else
            {
                return View(login);
            }
            

        }

    }
}
*/