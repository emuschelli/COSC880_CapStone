using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarApp.Models;

namespace WarApp.Controllers
{
    public class AccomplishmentsController : Controller
    {
        private WarAppDBContext db = new WarAppDBContext();

        // GET: Accomplishments
        public ActionResult Index()
        {
            var tblWAR_Accomplishments = db.tblWAR_Accomplishments.Include(t => t.lutWAR_AccStatus).Include(t => t.lutWAR_Projects).Include(t => t.tblER_Employee);
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
