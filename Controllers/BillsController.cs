using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PahramcyOnline.Models;

namespace PahramcyOnline.Controllers
{
    public class BillsController : Controller
    {
        private pharmacyEntities db = new pharmacyEntities();

        // GET: Bills
        public ActionResult Index()
        {
            var bills = db.Bills.Include(b => b.User);
            return View(bills.ToList());
        }

        // GET: Bills/Details/5
        

        // GET: Bills/Create
       
        public ActionResult Create( int id_user, double sum)
        {
            Bill bill=new Bill();
            bill.id_user = id_user;
            DateTime now = DateTime.Now;
            DateTime date1 = DateTime.Now;
            TimeSpan value = date1.Subtract(now);
            bill.added_at = value;
            bill.sum = sum;
                db.Bills.Add(bill);
                db.SaveChanges();
                return RedirectToAction("UserHome","Users");
            
        }

      
        // GET: Bills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = db.Bills.Find(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill bill = db.Bills.Find(id);
            db.Bills.Remove(bill);
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
