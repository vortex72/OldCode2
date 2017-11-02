using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eClub.Context;
using eClub.Models;

namespace eClub.Controllers
{
    public class LeadsModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LeadsModels
        public ActionResult Index()
        {
            return View(db.LeadsModels.ToList());
        }

        // GET: LeadsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadsModel leadsModel = db.LeadsModels.Find(id);
            if (leadsModel == null)
            {
                return HttpNotFound();
            }
            return View(leadsModel);
        }

        // GET: LeadsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeadsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mClient_ID,mReferred_ID,mReferred_FirstName,mReferred_LastName,mReferred_Phone1,mReferred_Phone2,mReferred_Phone3,mReferred_BirthDate,mReferred_Comments")] LeadsModel leadsModel)
        {
            if (ModelState.IsValid)
            {
                db.LeadsModels.Add(leadsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leadsModel);
        }

        // GET: LeadsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadsModel leadsModel = db.LeadsModels.Find(id);
            if (leadsModel == null)
            {
                return HttpNotFound();
            }
            return View(leadsModel);
        }

        // POST: LeadsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mClient_ID,mReferred_ID,mReferred_FirstName,mReferred_LastName,mReferred_Phone1,mReferred_Phone2,mReferred_Phone3,mReferred_BirthDate,mReferred_Comments")] LeadsModel leadsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leadsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leadsModel);
        }

        // GET: LeadsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeadsModel leadsModel = db.LeadsModels.Find(id);
            if (leadsModel == null)
            {
                return HttpNotFound();
            }
            return View(leadsModel);
        }

        // POST: LeadsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeadsModel leadsModel = db.LeadsModels.Find(id);
            db.LeadsModels.Remove(leadsModel);
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
