using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PahramcyOnline.Models;
using System.IO;
using PahramcyOnline.Controllers;

namespace PahramcyOnline.Controllers
{
    public class ProductController : Controller
    {
        private  pharmacyEntities db = new pharmacyEntities();

        // GET: products
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                return View(db.products.ToList());

            }
            else
            {
                return RedirectToAction("Index", "Home");
                
            }
        }

        // GET: products/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
          if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            if (Session["Email"] != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            

        }

        // POST: products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,pro_TradName,pro_prices,pro_quantity,pro_company,pro_pharmacology,pro_type,pro_GenericName,pro_image")] product product,HttpPostedFileBase proImage)
        {
            if (ModelState.IsValid)
            {
                string path="";
                if(proImage.FileName.Length>0)
                {
                    path = "~/images/" + Path.GetFileName(proImage.FileName);
                    proImage.SaveAs(Server.MapPath(path));
                }
                product.pro_image = path;
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,pro_TradName,pro_prices,pro_quantity,pro_company,pro_pharmacology,pro_type,pro_GenericName,pro_image")] product product, HttpPostedFileBase proImage)
        {
            if (proImage != null)
            {
                string path = "";
                if (proImage.FileName.Length > 0)
                {
                    path = "~/images/" + Path.GetFileName(proImage.FileName);
                    proImage.SaveAs(Server.MapPath(path));
                }
                product.pro_image = path;
            }
          //  var before = db.products.AsNoTracking().Where(x => x.Id == product.Id).ToList().FirstOrDefault();

            
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Email"] == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
        
        
        public ActionResult Shop(string search)
        {
            var Product = from p in db.products
                          select p;
            if(search == "Tablets" || search == "Capsule" || search == "Syrup" || search == "vial" || search == "Ampoule" || search == "Suppository" || search == "Effervescent")
            {
                Product = db.products.Where(p => p.pro_type.Equals(search));
                return View(Product.ToList());
            }

            else 
            {
                Product = db.products.Where(p => p.pro_TradName.Equals(search));
                return View(Product.ToList());
            }

            
        }
        
        /*
        [HttpPost]
        public ActionResult Shop(product product)
        {


            return RedirectToAction("Index");
        }
        */
    }

}
