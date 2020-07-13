using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;


namespace V1_BTL_CNPM.Controllers.admin
{
    public class qlgvController : BaseController
    {
        // GET: qlgv

        private db_cnpm_v1Entities1 db = new db_cnpm_v1Entities1();

        public ActionResult qlgv()
        {
            var user = from a in db.taikhoans
                       join b in db.giangviens
                       on a.MaTK equals b.MaTK

                       select new qlgv()
                       {
                           MaTK = a.MaTK,
                           TenTaiKhoan = a.TenTaiKhoan,
                           MatKhau = a.MatKhau,
                           Quyen = a.Quyen,
                           MaGV = b.MaGV,
                           HoTenGV = b.HoTenGV,
                           MaKhoa = b.MaKhoa,
                           NgaySinh = b.NgaySinh,
                           DiaChi = b.DiaChi,
                           

                       };
            return View(user);
        }

        public ActionResult create_qlgv()
        {
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa");
            return View();
        }


        [HttpPost]
        public ActionResult create_qlgv(qlgv user)
        {
            try
            {
                //ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan");


                taikhoan tk = new taikhoan();
                /*if(tk.Quyen == 2)
                {*/
                    tk.MaTK = user.MaTK;
                    tk.TenTaiKhoan = user.TenTaiKhoan;
                    tk.MatKhau = user.MatKhau;
                    tk.Quyen = user.Quyen;
                    db.taikhoans.Add(tk);
                    db.SaveChanges();
                    int matk = tk.MaTK;
                    giangvien gv = new giangvien();
                    gv.MaGV = user.MaGV;
                    gv.HoTenGV = user.HoTenGV;
                    gv.NgaySinh = user.NgaySinh;
                    gv.DiaChi = user.DiaChi;
                    gv.MaKhoa = user.MaKhoa;
                    gv.MaTK = matk;
                    db.giangviens.Add(gv);
                    db.SaveChanges();
                /*}
                else
                {

                }*/
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return RedirectToAction("qlsv");


        }
    }
}