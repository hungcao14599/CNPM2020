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
    public class giangviensController : BaseController
    {
        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        // GET: giangviens
        public ActionResult Index()
        {
            var giangviens = db.giangviens.Include(g => g.nganh).Include(g => g.taikhoan);
            return View(giangviens.ToList());
        }

        // GET: giangviens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giangvien giangvien = db.giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        // GET: giangviens/Create
        public ActionResult Create()
        {
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa");
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan");
            return View();
        }

        // POST: giangviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,HoTenGV,NgaySinh,GioiTinh,QueQuan,SoDienThoai,Email,DiaChi,HinhAnh,MaTK,MaKhoa")] giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.giangviens.Add(giangvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", giangvien.MaNganh);
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan", giangvien.MaTK);
            return View(giangvien);
        }

        // GET: giangviens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giangvien giangvien = db.giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", giangvien.MaNganh);
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan", giangvien.MaTK);
            return View(giangvien);
        }

        // POST: giangviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,HoTenGV,NgaySinh,GioiTinh,QueQuan,SoDienThoai,Email,DiaChi,HinhAnh,MaTK,MaKhoa")] giangvien giangvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giangvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa", giangvien.MaNganh);
            ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan", giangvien.MaTK);
            return View(giangvien);
        }

        // GET: giangviens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giangvien giangvien = db.giangviens.Find(id);
            if (giangvien == null)
            {
                return HttpNotFound();
            }
            return View(giangvien);
        }

        // POST: giangviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            giangvien giangvien = db.giangviens.Find(id);
            db.giangviens.Remove(giangvien);
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
