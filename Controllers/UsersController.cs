﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PahramcyOnline.Models;

namespace PahramcyOnline.Controllers
{
    public class UsersController : Controller
    {
        private pharmacyEntities db = new pharmacyEntities();

        // GET: Users
        public ActionResult Index()
        {
            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            return View(db.Users.ToList());
        }
        

        public ActionResult UserHome()
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            number();
            return View(); 
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

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_user,fisrt_name,last_name,User_Name,address,phone_number,email_user,password")] User user)
        {
            var phone  = 0;
            int newphone;
            var obj = db.Users.Where(a => a.User_Name.Equals(user.User_Name)).FirstOrDefault();
            if (ModelState.IsValid )
            {
                {
                    
                    if (obj == null)
                    {
                        
                        db.Users.Add(user);
                        db.SaveChanges();
                        
                        return RedirectToAction("Login", "Home");
                    }
                    if (obj!=null) {

                        ViewBag.Message = "User name is not valid";
                        return View();

                    }
                }
            }
            if (!ModelState.IsValid)
                return View();

            return View();



        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_user,fisrt_name,last_name,email_user,password,address,phone_number,User_Name")] User user)
        {

            var obj = db.Users.Where(a => a.User_Name.Equals(user.User_Name)).FirstOrDefault();

            if (Session["user_id"] == null)
            {
                return RedirectToAction("Login", "Home");

            }
            if (!ModelState.IsValid && obj != null)
            {
                ViewBag.Message = "Username Not Valid";
                return View(user);
            }
            if (ModelState.IsValid && obj == null)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserHome");
            }
            return View(user);

        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

