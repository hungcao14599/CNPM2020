using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers
{
    public class LoginController : Controller
    {

        private db_cnpm_v1Entities db = new db_cnpm_v1Entities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public bool CheckBox { set; get; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(taikhoan accounts)
        {
            var ketqua = from s in db.taikhoans
                         where s.TenTaiKhoan == accounts.TenTaiKhoan
                         && s.MatKhau == accounts.MatKhau
                         select s;


            if (ketqua.Any())
            {
                var quyen = from s in db.taikhoans
                            where s.TenTaiKhoan == accounts.TenTaiKhoan
                            && s.MatKhau == accounts.MatKhau && s.Quyen == 1
                            select s;

                var quyen1 = from s in db.taikhoans
                            where s.TenTaiKhoan == accounts.TenTaiKhoan
                            && s.MatKhau == accounts.MatKhau && s.Quyen == 2
                            select s;


                if (quyen.Any())
                {
                    FormsAuthentication.SetAuthCookie(accounts.TenTaiKhoan, CheckBox);
                    return RedirectToAction("Khoa", "khoas");
                }
                else if (quyen1.Any())
                {
                    FormsAuthentication.SetAuthCookie(accounts.TenTaiKhoan, CheckBox);
                    return RedirectToAction("Index", "nganhs");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(accounts.TenTaiKhoan, CheckBox);
                    return RedirectToAction("Index", "mons");
                }
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");

            }
            return View(accounts);

        }

        [Authorize]
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("", "");
        }


    }
}