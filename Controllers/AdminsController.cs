using System;
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
    public class AdminsController : Controller
    {
        private pharmacyEntities db = new pharmacyEntities();

        // GET: Admins
        
        public ActionResult AdminHome()
        {
            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
                return View();
        }


        // GET: Admins/Details/5
        public ActionResult Details()
        {

            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            
                var id = Session["admin_id"];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: Admins/Create
     

        // GET: Admins/Edit/5
        public ActionResult Edit()
        {
            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            var id = Session["admin_id"];

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_admin,Email_Admin,Password_Admin,First_Name,Last_Name")] Admin admin)
        {
            if (Session["admin_id"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdminHome");
            }
            return View(admin);
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
