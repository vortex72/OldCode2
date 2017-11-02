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

namespace eClub.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            SelectList slCardType = new SelectList(db.CardType, "mCardType_Id", "mCardType_Name");
            ViewBag.CardType = slCardType;
            SelectList slIssuerBank = new SelectList(db.IssuerBank, "mIssuerBank_Id", "mIssuerBank_Name");
            ViewBag.IssuerBank = slIssuerBank;

            System.Web.HttpContext.Current.Items["dMaritalStatus"] = LoadList("dMaritalStatus");
            System.Web.HttpContext.Current.Items["dGender"] = LoadList("dGender");
            System.Web.HttpContext.Current.Items["dCitizenship"] = LoadList("dCitizenship");
            System.Web.HttpContext.Current.Items["dClientIncomeRange"] = LoadList("dClientIncomeRange");
            System.Web.HttpContext.Current.Items["dOccupation"] = LoadList("dOccupation");
            System.Web.HttpContext.Current.Items["dClientSource"] = LoadList("dClientSource");

            Client t_Client = new Client();

            return View(t_Client);
        }

        IEnumerable<DescriptionTables> LoadList(string sTable)
        {
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
            return (dt);
        }

        DataTable GetLanguageGrid(string sTable)
        {
            ApplicationDbContext db1 = new ApplicationDbContext();
            string dbConnString = db1.Database.Connection.ConnectionString;
            SqlDataAdapter adap = new SqlDataAdapter("spCreateLangGrid", dbConnString);
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

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mClient_ID,mClient_IdentityCardNumber,mClient_FirstName,mClient_MidleName,mClient_LastName,mClient_MaidenName,mClient_BornDate,mClient_ChildrenNumber,mClient_SendSMS,mClient_SendEMail,dGender_ID,dClientStatus_ID,dCitizenship_ID,dMaritalStatus_ID,dOccupation_ID,dClientIncomeRange_ID,dClientSource_ID,mClient_FirstContactDate,dClientOriginalContact_ID,SECUser_ID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mClient_ID,mClient_IdentityCardNumber,mClient_FirstName,mClient_MidleName,mClient_LastName,mClient_MaidenName,mClient_BornDate,mClient_ChildrenNumber,mClient_SendSMS,mClient_SendEMail,dGender_ID,dClientStatus_ID,dCitizenship_ID,dMaritalStatus_ID,dOccupation_ID,dClientIncomeRange_ID,dClientSource_ID,mClient_FirstContactDate,dClientOriginalContact_ID,SECUser_ID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
