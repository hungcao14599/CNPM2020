using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class qlsvController : Controller
    {
        private db_cnpm_v2Entities db = new db_cnpm_v2Entities();

        public ActionResult qlsv()
        {
            var user = from a in db.taikhoans
                       join b in db.sinhviens
                       on a.MaTK equals b.MaTK

                       select new qlsv()
                       {
                           MaTK = a.MaTK,
                           

                           MaSV = b.MaSV,
                           TenSV = b.TenSV,
                           MaKhoa = b.MaKhoa,
                           NgaySinh = b.NgaySinh,
                           DiaChi = b.DiaChi,
                           Email = b.Email,
                           SoDienThoai = b.SoDienThoai,
                           
                           HinhAnh = b.HinhAnh,


                       };
            return View(user);
        }

        



    }
}