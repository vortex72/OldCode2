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
    public class AppModulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppModules
        public ActionResult Index()
        {
            DataTable DescTable = new DataTable();
            string culture = CultureHelper.GetCurrentCulture();
            DescTable = GetModulesList(culture);

            var iQuery = from descriptor in DescTable.AsEnumerable()
                         select descriptor;
            IEnumerable<ModulesViewModel> dt = (from sa in iQuery.AsEnumerable()
                                                 select new ModulesViewModel
                                                 {
                                                     ModuleID = sa.Field<int>("ModuleID"),
                                                     ModuleName = sa.Field<string>("ScreenName")
                                                 });
            return View(dt); 
        }

        DataTable GetModulesList(string culture)
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
            SqlDataAdapter adap = new SqlDataAdapter("spGetListedModules", db.Database.Connection.ConnectionString);
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
            AppModules appModule = db.AppModules.Find(id);
            if (appModule == null)
            {
                return HttpNotFound();
            }
            return View(appModule);
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
        public ActionResult Create([Bind(Include = "ModuleID,ModuleName,ScreenFile")] AppModules appModules)
        {
            if (ModelState.IsValid)
            {
                db.AppModules.Add(appModules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appModules);
        }

        // GET: AppScreens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppModules appScreen = db.AppModules.Find(id);
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
        public ActionResult Edit([Bind(Include = "ModuleID,ModuleName")] AppModules appModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appModule);
        }

        // GET: AppScreens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppModules appModule = db.AppModules.Find(id);
            if (appModule == null)
            {
                return HttpNotFound();
            }
            return View(appModule);
        }

        // POST: AppScreens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AppModules appModule = db.AppModules.Find(id);
            db.AppModules.Remove(appModule);
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
