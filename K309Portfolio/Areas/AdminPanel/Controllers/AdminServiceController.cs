using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K309Portfolio.Models;

namespace K309Portfolio.Areas.AdminPanel.Controllers
{
    [AdminFilter]
    public class AdminServiceController : Controller
    {
        private PortfolioDB db = new PortfolioDB();


        // GET: AdminPanel/AdminService
        public ActionResult Index()
        {
            return View(db.ServiceSections.ToList());
        }

        // GET: AdminPanel/AdminService/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSection serviceSection = db.ServiceSections.Find(id);
            if (serviceSection == null)
            {
                return HttpNotFound();
            }
            return View(serviceSection);
        }

        // GET: AdminPanel/AdminService/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/AdminService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,icon,header,deccription")] ServiceSection serviceSection)
        {
            if (ModelState.IsValid)
            {
                db.ServiceSections.Add(serviceSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceSection);
        }

        // GET: AdminPanel/AdminService/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSection serviceSection = db.ServiceSections.Find(id);
            if (serviceSection == null)
            {
                return HttpNotFound();
            }
            return View(serviceSection);
        }

        // POST: AdminPanel/AdminService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,icon,header,deccription")] ServiceSection serviceSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceSection);
        }

        // GET: AdminPanel/AdminService/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceSection serviceSection = db.ServiceSections.Find(id);
            if (serviceSection == null)
            {
                return HttpNotFound();
            }
            return View(serviceSection);
        }

        // POST: AdminPanel/AdminService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceSection serviceSection = db.ServiceSections.Find(id);
            db.ServiceSections.Remove(serviceSection);
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
