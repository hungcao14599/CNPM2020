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
    public class sinhviensController : BaseController
    {
        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        // GET: sinhviens
        public ActionResult Index()
        {
            var sinhviens = db.sinhviens.Include(s => s.nganh).Include(s => s.taikhoan);
            return View(sinhviens.ToList());
        }

        // GET: sinhviens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinhvien sinhvien = db.sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // GET: sinhviens/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa");
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan");
            return View();
        }

        // POST: sinhviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTK,MaSV,TenSV,NgaySinh,GioiTinh,QueQuan,SoDienThoai,Email,DiaChi,HinhAnh,MaKhoa")] sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.sinhviens.Add(sinhvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", sinhvien.MaNganh);
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan", sinhvien.MaTK);
            return View(sinhvien);
        }

        // GET: sinhviens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinhvien sinhvien = db.sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", sinhvien.MaNganh);
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan", sinhvien.MaTK);
            return View(sinhvien);
        }

        // POST: sinhviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTK,MaSV,TenSV,NgaySinh,GioiTinh,QueQuan,SoDienThoai,Email,DiaChi,HinhAnh,MaKhoa")] sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", sinhvien.MaNganh);
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan", sinhvien.MaTK);
            return View(sinhvien);
        }

        // GET: sinhviens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinhvien sinhvien = db.sinhviens.Find(id);
            if (sinhvien == null)
            {
                return HttpNotFound();
            }
            return View(sinhvien);
        }

        // POST: sinhviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            sinhvien sinhvien = db.sinhviens.Find(id);
            db.sinhviens.Remove(sinhvien);
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
