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
    public class mProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: mProducts
        public ActionResult Index()
        {
            return View(db.mProducts.ToList());
        }

        // GET: mProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mProduct mProduct = db.mProducts.Find(id);
            if (mProduct == null)
            {
                return HttpNotFound();
            }
            return View(mProduct);
        }

        // GET: mProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mProduct_ID,mProduct_Name,mProduct_MembershipUniqueFee,mProduct_MembershipUniqueFeeExoneration,mProduct_PaymentFrequency,mProduct_PaymentAmount,mProduct_PaymentAmountExoneration,mProduct_CreationDate,mProduct_StartDate,mProduct_EndDate,mProduct_MaxProductAmount,mProduct_EarnedDividends,mProduct_Status,SECUSer_ID")] mProduct mProduct)
        {
            if (ModelState.IsValid)
            {
                db.mProducts.Add(mProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mProduct);
        }

        // GET: mProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mProduct mProduct = db.mProducts.Find(id);
            if (mProduct == null)
            {
                return HttpNotFound();
            }
            return View(mProduct);
        }

        // POST: mProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mProduct_ID,mProduct_Name,mProduct_MembershipUniqueFee,mProduct_MembershipUniqueFeeExoneration,mProduct_PaymentFrequency,mProduct_PaymentAmount,mProduct_PaymentAmountExoneration,mProduct_CreationDate,mProduct_StartDate,mProduct_EndDate,mProduct_MaxProductAmount,mProduct_EarnedDividends,mProduct_Status,SECUSer_ID")] mProduct mProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mProduct);
        }

        // GET: mProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mProduct mProduct = db.mProducts.Find(id);
            if (mProduct == null)
            {
                return HttpNotFound();
            }
            return View(mProduct);
        }

        // POST: mProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mProduct mProduct = db.mProducts.Find(id);
            using (var dbtrx = db.Database.BeginTransaction())
            {
                try
                {
                    db.mProducts.Remove(mProduct);
                }
                catch { dbtrx.Rollback(); }
                finally
                {
                    db.SaveChanges();
                    dbtrx.Commit();
                }
            }
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
