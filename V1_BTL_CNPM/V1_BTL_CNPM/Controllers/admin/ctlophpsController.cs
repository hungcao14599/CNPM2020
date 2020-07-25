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
    public class ctlophpsController : Controller
    {
        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        // GET: ctlophps
        public ActionResult Index()
        {
            var ctlophps = db.ctlophps.Include(c => c.lophocphan).Include(c => c.lopmonhoc).Include(c => c.lophocphan1).Include(c => c.lopmonhoc1);
            return View(ctlophps.ToList());
        }

        // GET: ctlophps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctlophp ctlophp = db.ctlophps.Find(id);
            if (ctlophp == null)
            {
                return HttpNotFound();
            }
            return View(ctlophp);
        }

        // GET: ctlophps/Create
        public ActionResult Create()
        {
            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP");
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon");
            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP");
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon");
            ViewBag.MaTGH = new SelectList(db.thoigianhocs, "MaTGH", "NamHoc");
            return View();
        }

        // POST: ctlophps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLTM,MaLHP")] ctlophp ctlophp)
        {
            if (ModelState.IsValid)
            {
                db.ctlophps.Add(ctlophp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP", ctlophp.MaLHP);
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon", ctlophp.MaLTM);
            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP", ctlophp.MaLHP);
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon", ctlophp.MaLTM);
            ViewBag.MaTGH = new SelectList(db.thoigianhocs, "MaTGH", "NamHoc");
            return View(ctlophp);
        }

        // GET: ctlophps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctlophp ctlophp = db.ctlophps.Find(id);
            if (ctlophp == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP", ctlophp.MaLHP);
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon", ctlophp.MaLTM);
            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP", ctlophp.MaLHP);
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon", ctlophp.MaLTM);
            return View(ctlophp);
        }

        // POST: ctlophps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLTM,MaLHP")] ctlophp ctlophp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctlophp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP", ctlophp.MaLHP);
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon", ctlophp.MaLTM);
            ViewBag.MaLHP = new SelectList(db.lophocphans, "MaLHP", "TenLopHP", ctlophp.MaLHP);
            ViewBag.MaLTM = new SelectList(db.lopmonhocs, "MaLTM", "TenLopMon", ctlophp.MaLTM);
            return View(ctlophp);
        }

        // GET: ctlophps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ctlophp ctlophp = db.ctlophps.Find(id);
            if (ctlophp == null)
            {
                return HttpNotFound();
            }
            return View(ctlophp);
        }

        // POST: ctlophps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ctlophp ctlophp = db.ctlophps.Find(id);
            db.ctlophps.Remove(ctlophp);
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
