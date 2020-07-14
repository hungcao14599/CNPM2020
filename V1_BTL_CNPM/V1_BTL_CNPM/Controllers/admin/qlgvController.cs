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

        private db_cnpm_v2Entities db = new db_cnpm_v2Entities();

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

                           MaGV = b.MaGV,
                           HoTenGV = b.HoTenGV,
                           MaKhoa = b.MaKhoa,
                           NgaySinh = b.NgaySinh,
                           DiaChi = b.DiaChi,
                           Email = b.Email,
                           SoDienThoai = b.SoDienThoai,
                           QueQuan = b.QueQuan,
                           HinhAnh = b.HinhAnh,
                           

                       };
            return View(user);
        }

  

        
    }
}