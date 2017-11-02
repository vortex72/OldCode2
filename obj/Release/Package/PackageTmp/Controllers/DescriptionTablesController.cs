using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eClub.Models;
using eClub.Context;

namespace eClub.Controllers
{
    public class DescriptionTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DescriptionTables
        public ActionResult Index()
        {
            var MTablesList = new List<mTablesViewModel>();
            foreach (var mtable in db.AppTables)
            {
                var MTableModel = new mTablesViewModel(mtable);
                MTablesList.Add(MTableModel);
            }
            return View(MTablesList);
            //return View(db.DescriptionTables.ToList());
        }

        // GET: DescriptionTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionTables descriptionTables = db.DescriptionTables.Find(id);
            if (descriptionTables == null)
            {
                return HttpNotFound();
            }
            return View(descriptionTables);
        }

        // GET: DescriptionTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DescriptionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DescTableID,DescTableSpanish,DescTableEnglish")] DescriptionTables descriptionTables)
        {
            if (ModelState.IsValid)
            {
                db.DescriptionTables.Add(descriptionTables);
                db.SaveChanges();
                return RedirectToAction("Detail", "AppTables");
            }

            return View(descriptionTables);
        }

        // GET: DescriptionTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionTables descriptionTables = db.DescriptionTables.Find(id);
            if (descriptionTables == null)
            {
                return HttpNotFound();
            }
            return View(descriptionTables);
        }

        // POST: DescriptionTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DescTableID,DescTableSpanish,DescTableEnglish")] DescriptionTables descriptionTables)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descriptionTables).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(descriptionTables);
        }

        // GET: DescriptionTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DescriptionTables descriptionTables = db.DescriptionTables.Find(id);
            if (descriptionTables == null)
            {
                return HttpNotFound();
            }
            return View(descriptionTables);
        }

        // POST: DescriptionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DescriptionTables descriptionTables = db.DescriptionTables.Find(id);
            db.DescriptionTables.Remove(descriptionTables);
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
