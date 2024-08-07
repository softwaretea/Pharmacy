﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using PahramcyOnline.Models;

namespace PahramcyOnline.Controllers
{
    public class CartsController : Controller
    {
        private pharmacyEntities db = new pharmacyEntities();

        // GET: Carts
        public ActionResult Index()
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "home");

            }
            var carts = db.Carts.Include(c => c.product).Include(c => c.User);
            var model = db.Carts;
            float x = 0;
            foreach (var item in model)
            {
                if (item.user_id.Equals(Session["user_id"]))
                {
                   x= x+ (float)item.product.pro_prices;
                }
            }
            Session["sum"] = x;
            
            return View(carts.ToList());
        }

       
        public ActionResult Create([Bind(Include = "cart_id,product_id")] Cart cart)
        {
            
            if (Session["user_id"] != null)
            {
                var model = db.Carts;
                int x = 0;
                foreach (var item in model)
                {
                    if (item.user_id.Equals(Session["user_id"]))
                    {
                        x += 1;
                    }
                }
                Session["number"] = x;

                if (ModelState.IsValid)
                {
                    
                    cart.user_id = (int)Session["user_id"];
                    db.Carts.Add(cart);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Shop", "product");
                }

                ViewBag.product_id = new SelectList(db.products, "Id", "pro_TradName", cart.product_id);
                ViewBag.user_id = new SelectList(db.Users, "Id_user", "fisrt_name", cart.user_id);
                //return View(cart);
                return RedirectToAction("Shop", "product");
            }
            return RedirectToAction("Login", "home");
        }
        public void number()
        {

            var model = db.Carts;
            int x = 0;
            foreach (var item in model)
            {
                if (item.user_id.Equals(Session["user_id"]))
                {
                    x += 1;
                }
            }
            Session["number"] = x;

        }

      
        // GET: Carts/Delete/5
        

        // POST: Carts/Delete/5
        
        public ActionResult Delete(int id)
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            Cart cart = db.Carts.Find(id);
            int x = (int)Session["number"];
            x--;
            Session["number"] = x;
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index", "Carts");
        }
        public ActionResult CartDelete(int id)
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            var model = db.Carts;

            foreach (var item in model)
            {
                if (Session["user_id"].Equals(id))
                {
                    Cart cart = db.Carts.Find(item.cart_id);
                    db.Carts.Remove(cart);

                }

            }
            db.SaveChanges();
            DateTime now = DateTime.Now;
            return RedirectToAction("Create", "Bills" ,new { id_user= id, sum= Session["sum"] });
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
