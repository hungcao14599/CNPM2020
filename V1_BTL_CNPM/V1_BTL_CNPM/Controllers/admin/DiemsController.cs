using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class DiemsController : BaseController
    {
        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();

        // GET: Diems
        public ActionResult Index()
        {
            var diems = db.Diems.Include(d => d.mon).Include(d => d.sinhvien);
            return View(diems.ToList());
        }

        // GET: Diems/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diems/Create



        public ActionResult Create()
        {
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon");
            ViewBag.MaSV = new SelectList(db.sinhviens, "MaSV", "TenSV");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,Diem1,MaMon")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", diem.MaMon);
            ViewBag.MaSV = new SelectList(db.sinhviens, "MaSV", "TenSV", diem.MaSV);
            return View(diem);
        }

        // GET: Diems/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", diem.MaMon);
            ViewBag.MaSV = new SelectList(db.sinhviens, "MaSV", "TenSV", diem.MaSV);
            return View(diem);
        }

        // POST: Diems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,Diem1,MaMon")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMon = new SelectList(db.mons, "MaMon", "TenMon", diem.MaMon);
            ViewBag.MaSV = new SelectList(db.sinhviens, "MaSV", "TenSV", diem.MaSV);
            return View(diem);
        }

        // GET: Diems/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            Diem diem = db.Diems.Find(id);
            db.Diems.Remove(diem);
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
