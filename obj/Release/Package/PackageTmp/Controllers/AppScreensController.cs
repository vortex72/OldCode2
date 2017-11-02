using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eClub.Context;
using eClub.Models;
using eClub.Helpers;

namespace eClub.Controllers
{
    public class AppScreensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppScreens
        public ActionResult Index()
        {
            DataTable DescTable = new DataTable();
            string culture = CultureHelper.GetCurrentCulture();
            DescTable = GetScreenList(culture);

            var iQuery = from descriptor in DescTable.AsEnumerable()
                         select descriptor;
            IEnumerable<ScreenViewModel> dt = (from sa in iQuery.AsEnumerable()
                                                 select new ScreenViewModel
                                                 {
                                                     ScreenID = sa.Field<int>("SECScreen_ID"),
                                                     ScreenName= sa.Field<string>("SECScreen_Name")
                                                 });
            return View(dt); 
        }

        DataTable GetScreenList(string culture)
        {
            int inLanguage = 0;
            string cult = culture.Substring(0, 2);
            switch (cult)
            {
                case "es":
                    inLanguage = 1;
                    break;
                case "en":
                    inLanguage = 2;
                    break;
            }
            SqlDataAdapter adap = new SqlDataAdapter("spGetScreens", db.Database.Connection.ConnectionString);
            DataTable DescData = new DataTable();
            try
            {
                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                adap.SelectCommand.Parameters.Add(new SqlParameter("@inLanguage", SqlDbType.Int)).Value = inLanguage;
                adap.Fill(DescData);
            }
            catch { }
            finally { adap.Dispose(); }
            return DescData;
        }

        // GET: AppScreens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppScreen appScreen = db.AppScreens.Find(id);
            if (appScreen == null)
            {
                return HttpNotFound();
            }
            return View(appScreen);
        }

        // GET: AppScreens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppScreens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScreenID,ScreenName,ScreenFile")] AppScreen appScreen)
        {
            if (ModelState.IsValid)
            {
                db.AppScreens.Add(appScreen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appScreen);
        }

        // GET: AppScreens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppScreen appScreen = db.AppScreens.Find(id);
            if (appScreen == null)
            {
                return HttpNotFound();
            }
            return View(appScreen);
        }

        // POST: AppScreens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScreenID,ScreenName,ScreenFile")] AppScreen appScreen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appScreen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appScreen);
        }

        // GET: AppScreens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppScreen appScreen = db.AppScreens.Find(id);
            if (appScreen == null)
            {
                return HttpNotFound();
            }
            return View(appScreen);
        }

        // POST: AppScreens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppScreen appScreen = db.AppScreens.Find(id);
            db.AppScreens.Remove(appScreen);
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
