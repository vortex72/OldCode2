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
    public class mSubProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: mSubProducts
        public ActionResult Index()
        {
            return View(db.mSubProducts.ToList());
        }

        // GET: mSubProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mSubProduct mSubProduct = db.mSubProducts.Find(id);
            if (mSubProduct == null)
            {
                return HttpNotFound();
            }
            return View(mSubProduct);
        }

        // GET: mSubProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mSubProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mSubProduct_ID,mSubProduct_Name,mSubProduct_PaymentAmount,mSubProduct_PaymentAmountExoneration,mSubProduct_CreationDate,mSubProduct_StartDate,mSubProduct_EndDate,mSubProduct_MaxProductAmount,mSubProduct_EarnedDividends,mSubProduct_BeneficiariesAllowed,mSubProduct_MinAgeAllowed,mSubProduct_MaxAgeAllowed,mSubProduct_Status,SECUSer_ID")] mSubProduct mSubProduct)
        {
            if (ModelState.IsValid)
            {
                db.mSubProducts.Add(mSubProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mSubProduct);
        }

        // GET: mSubProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mSubProduct mSubProduct = db.mSubProducts.Find(id);
            if (mSubProduct == null)
            {
                return HttpNotFound();
            }
            return View(mSubProduct);
        }

        // POST: mSubProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mSubProduct_ID,mSubProduct_Name,mSubProduct_PaymentAmount,mSubProduct_PaymentAmountExoneration,mSubProduct_CreationDate,mSubProduct_StartDate,mSubProduct_EndDate,mSubProduct_MaxProductAmount,mSubProduct_EarnedDividends,mSubProduct_BeneficiariesAllowed,mSubProduct_MinAgeAllowed,mSubProduct_MaxAgeAllowed,mSubProduct_Status,SECUSer_ID")] mSubProduct mSubProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mSubProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mSubProduct);
        }

        // GET: mSubProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mSubProduct mSubProduct = db.mSubProducts.Find(id);
            if (mSubProduct == null)
            {
                return HttpNotFound();
            }
            return View(mSubProduct);
        }

        // POST: mSubProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mSubProduct mSubProduct = db.mSubProducts.Find(id);
            db.mSubProducts.Remove(mSubProduct);
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
