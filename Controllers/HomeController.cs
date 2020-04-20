﻿using System;
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


            if (Email.Equals("admin@Pharmacy.com") && Password.Equals("123456"))
            {
                //return RedirectToAction("Index", controllerName: "productsController");
                //return RedirectToAction("Index", "ProductsController");
                Session["Email"] = "admin@Pharmacy.com";

                return RedirectToAction("AdminHome","Product");

               
                

            }
            else
            {
                ViewBag.Message = "not matched";


                return View();

            }


        }
        public ActionResult Log_out()
        {
            Session["Email"] = "";

            return RedirectToAction("index","Home");
        }

    }
}