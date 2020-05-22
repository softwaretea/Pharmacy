﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
            var carts = db.Carts.Include(c => c.product).Include(c => c.User);
            return View(carts.ToList());
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        //// GET: Carts/Create
        //public ActionResult Create()
        //{
        //    ViewBag.product_id = new SelectList(db.products, "Id", "pro_TradName");
        //    ViewBag.user_id = new SelectList(db.Users, "Id_user", "fisrt_name");
        //    return View();
        //}

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cart_id,product_id")] Cart cart)
        {
            if (Session["user_id"] != null)
            {
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

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.products, "Id", "pro_TradName", cart.product_id);
            ViewBag.user_id = new SelectList(db.Users, "Id_user", "fisrt_name", cart.user_id);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cart_id,user_id,product_id")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.products, "Id", "pro_TradName", cart.product_id);
            ViewBag.user_id = new SelectList(db.Users, "Id_user", "fisrt_name", cart.user_id);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
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
