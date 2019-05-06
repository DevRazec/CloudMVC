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
    public class RulesController : Controller
    {
        private clouddbEntities db = new clouddbEntities();

        // GET: Rules
        public ActionResult Index()
        {
            var rules = db.Rules.Include(r => r.Pages);
            return View(rules.ToList());
        }

        // GET: Rules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rules rules = db.Rules.Find(id);
            if (rules == null)
            {
                return HttpNotFound();
            }
            return View(rules);
        }

        // GET: Rules/Create
        public ActionResult Create()
        {
            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Url");
            return View();
        }

        // POST: Rules/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RuleID,PageID,RuleName")] Rules rules)
        {
            if (ModelState.IsValid)
            {
                db.Rules.Add(rules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Url", rules.PageID);
            return View(rules);
        }

        // GET: Rules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rules rules = db.Rules.Find(id);
            if (rules == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Url", rules.PageID);
            return View(rules);
        }

        // POST: Rules/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RuleID,PageID,RuleName")] Rules rules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Url", rules.PageID);
            return View(rules);
        }

        // GET: Rules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rules rules = db.Rules.Find(id);
            if (rules == null)
            {
                return HttpNotFound();
            }
            return View(rules);
        }

        // POST: Rules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rules rules = db.Rules.Find(id);
            db.Rules.Remove(rules);
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
