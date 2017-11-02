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
    public class BenefitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Benefits
        public ActionResult Index()
        {
            return View(db.Benefits.ToList());
        }

        // GET: Benefits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benefit benefit = db.Benefits.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        // GET: Benefits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Benefits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mBenefit_ID,mBenefit_Name,mProvider_ID,mBenefit_CreationDate,mBenefit_StartPeriod,mBenefit_TopBenefitByPeriod,mBenefit_BenefitUseFrequency,mBenefit_EarnedDividends,mBenefit_DividendsDuration,mBenefit_DividendsMax,mBenefit_DividendsMin,dBenefitsStatus_ID,SECUser_ID")] Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                db.Benefits.Add(benefit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benefit);
        }

        // GET: Benefits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benefit benefit = db.Benefits.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        // POST: Benefits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mBenefit_ID,mBenefit_Name,mProvider_ID,mBenefit_CreationDate,mBenefit_StartPeriod,mBenefit_TopBenefitByPeriod,mBenefit_BenefitUseFrequency,mBenefit_EarnedDividends,mBenefit_DividendsDuration,mBenefit_DividendsMax,mBenefit_DividendsMin,dBenefitsStatus_ID,SECUser_ID")] Benefit benefit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benefit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benefit);
        }

        // GET: Benefits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Benefit benefit = db.Benefits.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        // POST: Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Benefit benefit = db.Benefits.Find(id);
            db.Benefits.Remove(benefit);
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
