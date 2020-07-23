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
    public class lophocphansController : BaseController
    {
        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();

        // GET: lophocphans
        public ActionResult Index()
        {
            var lophocphans = db.lophocphans.Include(l => l.thoigianhoc);
            return View(lophocphans.ToList());
        }

        // GET: lophocphans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lophocphan lophocphan = db.lophocphans.Find(id);
            if (lophocphan == null)
            {
                return HttpNotFound();
            }
            return View(lophocphan);
        }

        // GET: lophocphans/Create


        public bool CheckMaLHP(string malhp)
        {
            return db.lophocphans.Count(x => x.MaLHP == malhp) > 0;
        }


        public ActionResult Create()
        {
            ViewBag.MaTGH = new SelectList(db.thoigianhocs, "MaTGH", "NamHoc");
            return View();
        }

        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLHP,TenLopHP,MaTGH")] lophocphan lophocphan)
        {
            if (ModelState.IsValid)
            {
                if (CheckMaLHP(lophocphan.MaLHP))
                {
                    Response.Write("<script>alert('Lớp học phần này đã tồn tại')</script>");
                }
                else
                {
                    db.lophocphans.Add(lophocphan);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.MaTGH = new SelectList(db.thoigianhocs, "MaTGH", "NamHoc", lophocphan.MaTGH);
            return View(lophocphan);
        }

        // GET: lophocphans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lophocphan lophocphan = db.lophocphans.Find(id);
            if (lophocphan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaTGH = new SelectList(db.thoigianhocs, "MaTGH", "NamHoc", lophocphan.MaTGH);
            return View(lophocphan);
        }

        // POST: lophocphans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLHP,TenLopHP,MaTGH")] lophocphan lophocphan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lophocphan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTGH = new SelectList(db.thoigianhocs, "MaTGH", "NamHoc", lophocphan.MaTGH);
            return View(lophocphan);
        }

        // GET: lophocphans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lophocphan lophocphan = db.lophocphans.Find(id);
            if (lophocphan == null)
            {
                return HttpNotFound();
            }
            return View(lophocphan);
        }

        // POST: lophocphans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            lophocphan lophocphan = db.lophocphans.Find(id);
            db.lophocphans.Remove(lophocphan);
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
