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
    [Authorize(Roles = "Admin")] //PREVENTS ANONYMOUS ACCESS
    public class AdminBranchController : Controller
    {
        private WarAppDBContext db = new WarAppDBContext();

        // GET: AdminBranch
        public ActionResult Index()
        {
            return View(db.lutER_Branch.ToList());
        }

        // GET: AdminBranch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            if (lutER_Branch == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Branch);
        }

        // GET: AdminBranch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminBranch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchId,BranchName")] lutER_Branch lutER_Branch)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Branch.Add(lutER_Branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Branch);
        }

        // GET: AdminBranch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            if (lutER_Branch == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Branch);
        }

        // POST: AdminBranch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchId,BranchName")] lutER_Branch lutER_Branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Branch);
        }

        // GET: AdminBranch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            if (lutER_Branch == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Branch);
        }

        // POST: AdminBranch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            db.lutER_Branch.Remove(lutER_Branch);
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
