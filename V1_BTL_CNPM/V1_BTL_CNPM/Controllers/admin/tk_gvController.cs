using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class tk_gvController : Controller
    {
      
        private db_cnpm_v1Entities db = new db_cnpm_v1Entities();

        public ActionResult QLGV()
        {
            var user = from a in db.taikhoans
                       join b in db.giangviens
                       on a.MaTK equals b.MaTK

                       select new tk_gv()
                       {
                           MaTK = a.MaTK,
                           TenTaiKhoan = a.TenTaiKhoan,
                           MatKhau = a.MatKhau,
                          
                           MaGV = b.MaGV,
                           HoTenGV = b.HoTenGV,
                           DiaChi = b.DiaChi,
                       };
            return View(user);
        }

        public ActionResult Create()
        {
            return View();
        }


        /*
        [HttpPost]
        public ActionResult Create(tk_gv user)
        {
            var user1 = from a in db.taikhoans
                       join b in db.giangviens
                       on a.MaTK equals b.MaTK

                       select new tk_gv()
                       {
                           MaTK = a.MaTK,
                           TenTaiKhoan = a.TenTaiKhoan,
                           MatKhau = a.MatKhau,

                           MaGV = b.MaGV,
                           HoTenGV = b.HoTenGV,
                           DiaChi = b.DiaChi,
                       };

            if (ModelState.IsValid)
            {
                db.tk_gv.Add(user1);
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult Create1()
        {
            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh");
            return View();
        }

        // POST: mons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMon,TenMon,MaNganh")] mon mon)
        {
            if (ModelState.IsValid)
            {
                db.mons.Add(mon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNganh = new SelectList(db.nganhs, "MaNganh", "TenNganh", mon.MaNganh);
            return View(mon);
        }*/

    }
}
 