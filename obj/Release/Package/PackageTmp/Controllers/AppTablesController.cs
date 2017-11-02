using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eClub.Models;
using eClub.Context;

namespace eClub.Controllers
{
    public class AppTablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppTables
        public ActionResult Index()
        {
            return View(db.AppTables.ToList());
        }

        // GET: AppTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppTables appTables = db.AppTables.Find(id);
            if (appTables == null)
            {
                return HttpNotFound();
            }
            string sTable = appTables.MasterTable_Name;
            Session["MTId"] = id;
            Session["MTName"] = sTable;
            Session["MTDesc"] = appTables.MasterTable_Description;
            DataTable DescTable = new DataTable();
            DescTable = GetLanguageGrid(sTable);

            var iQuery = from descriptor in DescTable.AsEnumerable()
                         select descriptor;
            IEnumerable<DescriptionTables> dt = (from sa in iQuery.AsEnumerable()
                                                 select new DescriptionTables
                                                 {
                                                     DescTableID = sa.Field<int>("Id"),
                                                     DescTableSpanish = sa.Field<string>("ESPAÑOL"),
                                                     DescTableEnglish = sa.Field<string>("INGLÉS"),
                                                 });
            return View(dt);
        }

        // GET: AppTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DescriptionTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DescriptionTables descriptionTables)
        {
           if (ModelState.IsValid)
           {
                //SqlDataAdapter adap = new SqlDataAdapter("spNewBaseTableRecord", db.Database.Connection.ConnectionString);
                //DataTable DescData = new DataTable();
                int rowsAffected = 0;
                try
                {
                    rowsAffected = db.Database.ExecuteSqlCommand("EXEC spNewBaseTableRecord @TableName, @DescriptionSpanish, @DescriptionEnglish",
                                                    new SqlParameter("@TableName", (string)Session["MTName"]),
                                                    new SqlParameter("@DescriptionSpanish", descriptionTables.DescTableSpanish.ToUpper()),
                                                    new SqlParameter("@DescriptionEnglish", descriptionTables.DescTableEnglish.ToUpper())
                                                    );

                }
                catch { }
                finally { }
                //return DescData;
            }

            return RedirectToAction("Details", new { id = (int)Session["MTId"] });
        }

        // GET: AppTables/Edit/5
        //[ValidateAntiForgeryToken]
        public ActionResult Edit()  //int? id)
        {
            /* if (descriptionTables.DescTableSpanish != null)
             {

                 int rowsAffected = 0;

                 try
                 {
                     rowsAffected = db.Database.ExecuteSqlCommand("EXEC spUpdateBaseTableRecord @TableName, @TableId, @DescriptionSpanish, @DescriptionEnglish",
                                                     new SqlParameter("@TableName", (string)Session["MTName"]),
                                                     new SqlParameter("@TableId", (int)Session["MTId"]),
                                                     new SqlParameter("@DescriptionSpanish", descriptionTables.DescTableSpanish.ToUpper()),
                                                     new SqlParameter("@DescriptionEnglish", descriptionTables.DescTableEnglish.ToUpper())
                                                     );
                 }
                 catch { }
                 finally { }
                 //return DescData;
             }
             return RedirectToAction("Details", new { id = (int)Session["MTId"] });

             /*if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             AppTables appTables = db.AppTables.Find(id);
             if (appTables == null)
             {
                 return HttpNotFound();
             }
             string sTable = appTables.MasterTable_Name;
             ViewBag.Title = appTables.MasterTable_Description;
             DataTable DescTable = new DataTable();
             DescTable = GetLanguageGrid(sTable);

             var iQuery = from descriptor in DescTable.AsEnumerable()
                                  select descriptor;
             IEnumerable<DescriptionTables> dt = (from sa in iQuery.AsEnumerable()
                                           select new DescriptionTables
                                           {
                                               DescTableID = sa.Field<int>("Id"),
                                               DescTableSpanish = sa.Field<string>("ESPAÑOL"),
                                               DescTableEnglish = sa.Field<string>("INGLÉS"),
                                           });
             return View(dt); */
            return View();
        }

        DataTable GetLanguageGrid(string sTable)
        {
            SqlDataAdapter adap = new SqlDataAdapter("spCreateLangGrid", db.Database.Connection.ConnectionString);
            DataTable DescData = new DataTable();
            try
            {
                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                adap.SelectCommand.Parameters.Add(new SqlParameter("@Table", SqlDbType.VarChar)).Value = sTable;
                adap.Fill(DescData);
            }
            catch { }
            finally { adap.Dispose(); }
            return DescData;
        }
        // POST: AppTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(DescriptionTables DescTable)
        {

            using (var dbtrx = db.Database.BeginTransaction())
            {
                if (DescTable.DescTableSpanish != null)
                {

                    int rowsAffected = 0;

                    try
                    {
                        rowsAffected = db.Database.ExecuteSqlCommand("EXEC spUpdateBaseTableRecord @TableName, @TableId, @DescriptionSpanish, @DescriptionEnglish",
                                                        new SqlParameter("@TableName", (string)Session["MTName"]),
                                                        new SqlParameter("@TableId", DescTable.DescTableID),
                                                        new SqlParameter("@DescriptionSpanish", DescTable.DescTableSpanish.ToUpper()),
                                                        new SqlParameter("@DescriptionEnglish", DescTable.DescTableEnglish.ToUpper())
                                                        );
                    }
                    catch { dbtrx.Rollback(); }
                    finally { dbtrx.Commit(); }
                    //return DescData;
                }
            }
            return Json(new { DescTable }, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Details", new { id = (int)Session["MTId"] });
        }

        // GET: AppTables/Delete/5
        public ActionResult Delete(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppTables appTables = db.AppTables.Find(id);
            if (appTables == null)
            {
                return HttpNotFound();
            }
            return View(appTables);*/
            return View();
        }

        // POST: AppTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(DescriptionTables DescTable)
        {
            if (DescTable.DescTableSpanish != null)
            {

                int rowsAffected = 0;

                using (var dbtrx = db.Database.BeginTransaction())
                {
                    try
                    {
                        rowsAffected = db.Database.ExecuteSqlCommand("EXEC spDeleteBaseTableRecord @TableName, @TableId, @DescriptionSpanish, @DescriptionEnglish",
                                                        new SqlParameter("@TableName", (string)Session["MTName"]),
                                                        new SqlParameter("@TableId", DescTable.DescTableID),
                                                        new SqlParameter("@DescriptionSpanish", DescTable.DescTableSpanish.ToUpper()),
                                                        new SqlParameter("@DescriptionEnglish", DescTable.DescTableEnglish.ToUpper())
                                                        );
                    }
                    catch
                    {
                        dbtrx.Rollback();
                    }
                    finally
                    {
                        dbtrx.Commit();
                    }
                }
                //return DescData;
            }
            return Json(new { DescTable }, JsonRequestBehavior.AllowGet);
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
