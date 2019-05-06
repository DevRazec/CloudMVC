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
    public class AutorizationsController : Controller
    {
        private clouddbEntities db = new clouddbEntities();

        // GET: Autorizations
        public ActionResult Index()
        {
            var autorization = db.Autorization.Include(a => a.Customers).Include(a => a.Rules);
            return View(autorization.ToList());
        }

        // GET: Autorizations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorization autorization = db.Autorization.Find(id);
            if (autorization == null)
            {
                return HttpNotFound();
            }
            return View(autorization);
        }

        // GET: Autorizations/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "RuleName");
            return View();
        }

        // POST: Autorizations/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AutorizationID,RuleID,CustomerID")] Autorization autorization)
        {
            if (ModelState.IsValid)
            {
                db.Autorization.Add(autorization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", autorization.CustomerID);
            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "RuleName", autorization.RuleID);
            return View(autorization);
        }

        // GET: Autorizations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorization autorization = db.Autorization.Find(id);
            if (autorization == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", autorization.CustomerID);
            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "RuleName", autorization.RuleID);
            return View(autorization);
        }

        // POST: Autorizations/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AutorizationID,RuleID,CustomerID")] Autorization autorization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autorization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName", autorization.CustomerID);
            ViewBag.RuleID = new SelectList(db.Rules, "RuleID", "RuleName", autorization.RuleID);
            return View(autorization);
        }

        // GET: Autorizations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Autorization autorization = db.Autorization.Find(id);
            if (autorization == null)
            {
                return HttpNotFound();
            }
            return View(autorization);
        }

        // POST: Autorizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Autorization autorization = db.Autorization.Find(id);
            db.Autorization.Remove(autorization);
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
