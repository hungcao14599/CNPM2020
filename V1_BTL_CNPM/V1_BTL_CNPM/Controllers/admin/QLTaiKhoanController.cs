using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers.admin
{
    public class QLTaiKhoanController : BaseController
    {
        // GET: QLTaiKhoan

        private db_cnpm_v2Entities db = new db_cnpm_v2Entities();

        public ActionResult QLTaiKhoan()
        {
            return View(db.taikhoans.ToList());
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
                    string FileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);

                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(user.ImageFile.FileName);

                    //Add Current Date To Attached File Name  
                    FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                    //Get Upload path from Web.Config file AppSettings.  
                    string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                    //Its Create complete path to store in server.  
                    user.HinhAnh = UploadPath + FileName;

                    //To copy and save file into server.  
                    user.ImageFile.SaveAs(user.HinhAnh);


                    taikhoan tk = new taikhoan();
                        
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
                                gv.SoDienThoai = user.SoDienThoai;
                                gv.HinhAnh = user.HinhAnh;
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
                                sv.SoDienThoai = user.SoDienThoai;
                                sv.HinhAnh = user.HinhAnh;
                                sv.MaTK = matk;
                                db.sinhviens.Add(sv);
                                db.SaveChanges();
                            }
                            

                    return RedirectToAction("QLTaiKhoan");
                }
            }
            ViewBag.MaKhoa = new SelectList(db.khoas, "MaKhoa", "TenKhoa");
            return View(user);


        }

        
    }
}