using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarApp.Models;

namespace WarApp.Controllers
{
    [Authorize]
    public class AccomplishmentsController : Controller
    {
        private WarAppDBContext db = new WarAppDBContext();

        // GET: Accomplishments
        public ActionResult Index(string sortOrder, string searchString)
        {

            //Receives sortOrder parameter from the query string in the URL. 
            //The query string value is provided by MVC as a parameter to the action method.
            //The parameter will be a string that's either "ProjectName" or "Date".
            //If optionally followed by an underscore and the string "desc" to specify descending order. 
            //The default sort order is ascending.

            //The first time the Index page is requested, there's no query string. 
            //The accomoplishments are displayed in ascending order by ProjectName, which is the default as established by the fall-through case in the switch statement. 
            //When the user clicks a column heading hyperlink, the appropriate sortOrder value is provided in the query string.

            //The two ViewBag variables are used so that the view can configure the column heading hyperlinks with the appropriate query string values:
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "ProjectName" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";

            //The method uses LINQ to Entities to specify the column to sort by.
            //The code creates an IQueryable variable before the switch statement, modifies it in the switch statement, and calls the ToList method after the switch statement.
            //When you create and modify IQueryable variables, no query is sent to the database.
            //The query is not executed until you convert the IQueryable object into a collection by calling a method such as ToList.
            //Therefore, this code results in a single query that is not executed until the return View statement.

            var tblWAR_Accomplishments = from model in db.tblWAR_Accomplishments.Include(t => t.lutWAR_AccStatus).Include(t => t.lutWAR_Projects).Include(t => t.tblER_Employee) select model;

            //FOR SEARCH BOX:
            //searchString parameter added to the Index method. 
            //LINQ statement added a where clausethat selects only projects that are contained the search string. 
            //The search string value is received from a text box that you'll add to the Index view. 
            //The statement that adds the where clause is executed only if there's a value to search for.
            if (!String.IsNullOrEmpty(searchString))
            {
                tblWAR_Accomplishments = tblWAR_Accomplishments.Where(model => model.lutWAR_Projects.ProjectName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "ProjectName":
                    tblWAR_Accomplishments = tblWAR_Accomplishments.OrderByDescending(model => model.lutWAR_Projects.ProjectName);
                    break;
                case "Date":
                    tblWAR_Accomplishments = tblWAR_Accomplishments.OrderBy(model => model.WeekEndingDate);
                    break;
                case "Date_desc":
                    tblWAR_Accomplishments = tblWAR_Accomplishments.OrderByDescending(model => model.WeekEndingDate);
                    break;
                default:
                    tblWAR_Accomplishments = tblWAR_Accomplishments.OrderBy(model => model.lutWAR_Projects.ProjectName);
                    break;
            }
            return View(tblWAR_Accomplishments.ToList());
        }

        // GET: Accomplishments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWAR_Accomplishments tblWAR_Accomplishments = db.tblWAR_Accomplishments.Find(id);
            if (tblWAR_Accomplishments == null)
            {
                return HttpNotFound();
            }
            return View(tblWAR_Accomplishments);
        }

        // GET: Accomplishments/Create
        public ActionResult Create()
        {
            ViewBag.AccStatusId = new SelectList(db.lutWAR_AccStatus, "AccStatusId", "Status");
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName");
            ViewBag.EmpId = new SelectList(db.tblER_Employee, "EmpId", "FirstName");
            return View();
        }

        // POST: Accomplishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccomoplishmentId,ProjId,AccStatusId,EmpId,Accomplishment,WeekEndingDate,AccArchieve")] tblWAR_Accomplishments tblWAR_Accomplishments)
        {
            if (ModelState.IsValid)
            {
                db.tblWAR_Accomplishments.Add(tblWAR_Accomplishments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccStatusId = new SelectList(db.lutWAR_AccStatus, "AccStatusId", "Status", tblWAR_Accomplishments.AccStatusId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblWAR_Accomplishments.ProjId);
            ViewBag.EmpId = new SelectList(db.tblER_Employee, "EmpId", "FirstName", tblWAR_Accomplishments.EmpId);
            return View(tblWAR_Accomplishments);
        }

        // GET: Accomplishments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWAR_Accomplishments tblWAR_Accomplishments = db.tblWAR_Accomplishments.Find(id);
            if (tblWAR_Accomplishments == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccStatusId = new SelectList(db.lutWAR_AccStatus, "AccStatusId", "Status", tblWAR_Accomplishments.AccStatusId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblWAR_Accomplishments.ProjId);
            ViewBag.EmpId = new SelectList(db.tblER_Employee, "EmpId", "FirstName", tblWAR_Accomplishments.EmpId);
            return View(tblWAR_Accomplishments);
        }

        // POST: Accomplishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccomoplishmentId,ProjId,AccStatusId,EmpId,Accomplishment,WeekEndingDate,AccArchieve")] tblWAR_Accomplishments tblWAR_Accomplishments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblWAR_Accomplishments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccStatusId = new SelectList(db.lutWAR_AccStatus, "AccStatusId", "Status", tblWAR_Accomplishments.AccStatusId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblWAR_Accomplishments.ProjId);
            ViewBag.EmpId = new SelectList(db.tblER_Employee, "EmpId", "FirstName", tblWAR_Accomplishments.EmpId);
            return View(tblWAR_Accomplishments);
        }

        // GET: Accomplishments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblWAR_Accomplishments tblWAR_Accomplishments = db.tblWAR_Accomplishments.Find(id);
            if (tblWAR_Accomplishments == null)
            {
                return HttpNotFound();
            }
            return View(tblWAR_Accomplishments);
        }

        // POST: Accomplishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblWAR_Accomplishments tblWAR_Accomplishments = db.tblWAR_Accomplishments.Find(id);
            db.tblWAR_Accomplishments.Remove(tblWAR_Accomplishments);
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
