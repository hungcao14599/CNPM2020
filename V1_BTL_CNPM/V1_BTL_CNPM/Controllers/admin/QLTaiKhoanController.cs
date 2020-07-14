using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class QLTaiKhoanController : Controller
    {
        // GET: QLTaiKhoan

        private db_cnpm_v2Entities db = new db_cnpm_v2Entities();

        public ActionResult Index()
        {
            return View();
        }


        public bool CheckUser(string taikhoan)
        {
            return db.taikhoans.Count(x => x.TenTaiKhoan == taikhoan) > 0;
        }
        
        public ActionResult create_taikhoan()
        {
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa");
            return View();
        }

        [HttpPost]
        public ActionResult create_taikhoan(taotaikhoan user)
        {

            if (ModelState.IsValid)
            {
                if (CheckUser(user.TenTaiKhoan))
                {
                    //ModelState.AddModelError("", "Da co tai khoan nay");
                    Response.Write("<script>alert('Tài khoản đã tồn tại')</script>");
                }
                else
                {
                    /*try
                    {
                        //ViewBag.MaTK = new SelectList(db.taikhoans, "MaTK", "TenTaiKhoan");
                    */

                        taikhoan tk = new taikhoan();
                        /*if(tk.Quyen == 2)
                        {*/
                            tk.MaTK = user.MaTK;
                            tk.TenTaiKhoan = user.TenTaiKhoan;
                            tk.MatKhau = user.MatKhau;
                            tk.Quyen = user.Quyen;
                            db.taikhoans.Add(tk);
                            db.SaveChanges();
                            if (tk.Quyen == 2)
                            {
                                int matk = tk.MaTK;
                                giangvien gv = new giangvien();
                                gv.MaGV = user.MaNS;
                                gv.HoTenGV = user.HoTen;
                                gv.NgaySinh = user.NgaySinh;
                                gv.DiaChi = user.DiaChi;
                                gv.MaKhoa = user.MaKhoa;
                                gv.Email = user.Email;
                                gv.GioiTinh = user.GioiTinh;
                                gv.QueQuan = user.QueQuan;
                                gv.HinhAnh = user.HinhAnh;
                                gv.SoDienThoai = user.SoDienThoai;
                                gv.MaTK = matk;
                                db.giangviens.Add(gv);
                                db.SaveChanges();
                            }
                            else if(tk.Quyen == 3)
                            {
                                int matk = tk.MaTK;
                                sinhvien sv = new sinhvien();
                                sv.MaSV = user.MaNS;
                                sv.TenSV = user.HoTen;
                                sv.NgaySinh = user.NgaySinh;
                                sv.DiaChi = user.DiaChi;
                                sv.MaKhoa = user.MaKhoa;
                                sv.Email = user.Email;
                                sv.GioiTinh = user.GioiTinh;
                                sv.QueQuan = user.QueQuan;
                                sv.HinhAnh = user.HinhAnh;
                                sv.SoDienThoai = user.SoDienThoai;
                                sv.MaTK = matk;
                                db.sinhviens.Add(sv);
                                db.SaveChanges();
                            }
                            
                       /* }
                        else if(tk.Quyen == 3)
                        {
                            tk.MaTK = user.MaTK;
                            tk.TenTaiKhoan = user.TenTaiKhoan;
                            tk.MatKhau = user.MatKhau;
                            tk.Quyen = user.Quyen;
                            db.taikhoans.Add(tk);
                            db.SaveChanges();
                            int matk = tk.MaTK;
                            sinhvien sv = new sinhvien();
                            sv.MaSV = user.MaNS;
                            sv.TenSV = user.HoTen;
                            sv.NgaySinh = user.NgaySinh;
                            sv.DiaChi = user.DiaChi;
                            sv.MaKhoa = user.MaKhoa;
                            sv.Email = user.Email;
                            sv.GioiTinh = user.GioiTinh;
                            sv.QueQuan = user.QueQuan;
                            sv.HinhAnh = user.HinhAnh;
                            sv.SoDienThoai = user.SoDienThoai;
                            sv.MaTK = matk;
                            db.sinhviens.Add(sv);
                            db.SaveChanges();
                        }
                        else
                        {
                            Response.Write("<script>alert('Chọn lại quyền đi bạn')</script>");
                        }*/
                    /*}
                    catch (Exception ex)
                    {

                        throw ex;
                    }*/

                    return RedirectToAction("Index");
                }
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa");
            return View(user);


        }
    }
}