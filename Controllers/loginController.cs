<<<<<<< HEAD
﻿/*
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
            
=======
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace PahramcyOnline.Controllers
//{
//    /*This Controller Is A Failed Controller You Must ReWrite This Controller In HomeController*/

//    public class loginController : Controller
//    {
//        // GET: login
//        [HttpGet]
//        public ActionResult Index()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult login( String Email, int Password)
//        {
//             if(Email==null)
//            {
//                ViewBag.message = "Email can't be null";
//            }
             
//            else if(Email=="admin@gmail.com"&&Password==123456)
//            {
//                return View(Home);         /*You Must Return Home Page Here*/

//            }
//            else
//            {
//                return View(login);         /*Return View doing Without But It In return function*/

//            }

>>>>>>> aea84cb29b66883d180b36de8f0f28ec68fab036

//        }

<<<<<<< HEAD
    }
}
*/
=======
//    }
//}  /*You Must Link This Function and it view*/
>>>>>>> aea84cb29b66883d180b36de8f0f28ec68fab036
