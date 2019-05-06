using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CloudMVC;

namespace CloudMVC.Controllers
{
    public class OrderNumbersController : Controller
    {
        private clouddbEntities db = new clouddbEntities();

        // GET: OrderNumbers
        public ActionResult Index()
        {
            return View(db.OrderNumbers.ToList());
        }

        // GET: OrderNumbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderNumbers orderNumbers = db.OrderNumbers.Find(id);
            if (orderNumbers == null)
            {
                return HttpNotFound();
            }
            return View(orderNumbers);
        }

        // GET: OrderNumbers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderNumbers/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderNumberID,OrderNumber")] OrderNumbers orderNumbers)
        {
            if (ModelState.IsValid)
            {
                db.OrderNumbers.Add(orderNumbers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderNumbers);
        }

        // GET: OrderNumbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderNumbers orderNumbers = db.OrderNumbers.Find(id);
            if (orderNumbers == null)
            {
                return HttpNotFound();
            }
            return View(orderNumbers);
        }

        // POST: OrderNumbers/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderNumberID,OrderNumber")] OrderNumbers orderNumbers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderNumbers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderNumbers);
        }

        // GET: OrderNumbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderNumbers orderNumbers = db.OrderNumbers.Find(id);
            if (orderNumbers == null)
            {
                return HttpNotFound();
            }
            return View(orderNumbers);
        }

        // POST: OrderNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderNumbers orderNumbers = db.OrderNumbers.Find(id);
            db.OrderNumbers.Remove(orderNumbers);
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
