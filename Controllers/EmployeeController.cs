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
    public class EmployeeController : Controller
    {
        private WarAppDBContext db = new WarAppDBContext();

        // GET: Employee
        public ActionResult Index()
        {
            var tblER_Employee = db.tblER_Employee.Include(t => t.lutER_Branch).Include(t => t.lutER_Directorate).Include(t => t.lutER_Division).Include(t => t.lutER_Location).Include(t => t.lutER_Organization).Include(t => t.lutER_Role).Include(t => t.lutWAR_Projects);
            return View(tblER_Employee.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            if (tblER_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tblER_Employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName");
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName");
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName");
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName");
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName");
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType");
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,RoleId,DirectorateId,DivisionId,LocationId,OrganizationalId,BranchId,ProjId,FirstName,LastName,EmailAddress,EmpArchive,Matrixed")] tblER_Employee tblER_Employee)
        {
            if (ModelState.IsValid)
            {
                db.tblER_Employee.Add(tblER_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName", tblER_Employee.BranchId);
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName", tblER_Employee.DirectorateId);
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName", tblER_Employee.DivisionId);
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName", tblER_Employee.LocationId);
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName", tblER_Employee.OrganizationalId);
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType", tblER_Employee.RoleId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblER_Employee.ProjId);
            return View(tblER_Employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            if (tblER_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName", tblER_Employee.BranchId);
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName", tblER_Employee.DirectorateId);
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName", tblER_Employee.DivisionId);
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName", tblER_Employee.LocationId);
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName", tblER_Employee.OrganizationalId);
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType", tblER_Employee.RoleId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblER_Employee.ProjId);
            return View(tblER_Employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,RoleId,DirectorateId,DivisionId,LocationId,OrganizationalId,BranchId,ProjId,FirstName,LastName,EmailAddress,EmpArchive,Matrixed")] tblER_Employee tblER_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblER_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName", tblER_Employee.BranchId);
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName", tblER_Employee.DirectorateId);
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName", tblER_Employee.DivisionId);
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName", tblER_Employee.LocationId);
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName", tblER_Employee.OrganizationalId);
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType", tblER_Employee.RoleId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblER_Employee.ProjId);
            return View(tblER_Employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            if (tblER_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tblER_Employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            db.tblER_Employee.Remove(tblER_Employee);
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
