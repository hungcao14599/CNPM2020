using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using V1_BTL_CNPM.Common;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client

        private db_cnpm_v3_1Entities db = new db_cnpm_v3_1Entities();

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SV()
        {
            
            return View();
        }

        public ActionResult GV()
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
        public ActionResult Login(taikhoan model)
        {
           
            if (ModelState.IsValid)
            {

                var result = CheckLogin(model.TenTaiKhoan, model.MatKhau, true);
                if (result == 1)
                {

                    var user = GetById(model.TenTaiKhoan);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TenTaiKhoan;
                    userSession.UserID = user.MaTK;

                    //userSession.GroupID = user.GroupID;
                    //var listCredentials = dao.GetListCredential(model.UserName);

                    //Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    if(user.Quyen == 2)
                    {
                        return RedirectToAction("GV", "Client");
                    }
                    else if (user.Quyen == 3)
                    {
                        return RedirectToAction("SV", "Client");
                    }
                    else if(user.Quyen == 1)
                    {
                        return RedirectToAction("Main", "Client");
                    }
                    
                }
                else if (result == 0)
                {
                    //ModelState.AddModelError("", "Tài khoản không tồn tại.");
                    Response.Write("<script>alert('Tài khoản không tồn tại')</script>");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else if (result == -3)
                {
                    //ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
                    Response.Write("<script>alert('.......')</script>");

                }
                else
                {
                    //ModelState.AddModelError("", "Đăng nhập không đúng.");
                    Response.Write("<script>alert('Đăng nhập không đúng')</script>");
                }
            }
            else
            {
                ModelState.AddModelError("", "Đăng nhập không đúng.");
                //Response.Write("<script>alert('Đăng nhập không đúng')</script>");
            }
            return View("Index");

        }

        
        public ActionResult logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Main", "Client");
        }


        public taikhoan GetById(string userName)
        {
            return db.taikhoans.SingleOrDefault(x => x.TenTaiKhoan == userName);
        }
        public int CheckLogin(string userName, string passWord, bool isAminLogin = false)
        {
            var result = db.taikhoans.FirstOrDefault(x => x.TenTaiKhoan == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isAminLogin == true)
                {
                    if (result.Quyen == CommonConstants.GIANGVIEN || result.Quyen == CommonConstants.SINHVIEN || result.Quyen == CommonConstants.ADMIN)
                    {
                        if (result.MatKhau == passWord)
                            return 1;
                        else
                            return -2;
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.MatKhau == passWord)
                        return 1;
                    else
                        return -2;
                }



            }
        }



    }
}