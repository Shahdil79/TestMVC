using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class DepartmentController : Controller
    {
        private OfficeManagmentContext db = new OfficeManagmentContext();

        // GET: Department
        public ActionResult Index()
        {
            return View(db.Department_tb.ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_tb department_tb = db.Department_tb.Find(id);
            if (department_tb == null)
            {
                return HttpNotFound();
            }
            return View(department_tb);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Department_tb department_tb)
        {
            if (ModelState.IsValid)
            {
                db.Department_tb.Add(department_tb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department_tb);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_tb department_tb = db.Department_tb.Find(id);
            if (department_tb == null)
            {
                return HttpNotFound();
            }
            return View(department_tb);
        }

        // POST: Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Department_tb department_tb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department_tb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department_tb);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department_tb department_tb = db.Department_tb.Find(id);
            if (department_tb == null)
            {
                return HttpNotFound();
            }
            return View(department_tb);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department_tb department_tb = db.Department_tb.Find(id);
            db.Department_tb.Remove(department_tb);
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
