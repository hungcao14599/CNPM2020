using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using V1_BTL_CNPM.Common;
using V1_BTL_CNPM.Models;

namespace V1_BTL_CNPM.Controllers
{
    public class LoginController : Controller
    {

        private db_cnpm_v3Entities db = new db_cnpm_v3Entities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(taikhoan model)
        {
            /*var ketqua = from s in db.taikhoans
                         where s.TenTaiKhoan == accounts.TenTaiKhoan
                         && s.MatKhau == accounts.MatKhau
                         select s;

            var userSession = new taikhoan();


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
                    /*FormsAuthentication.SetAuthCookie(accounts.TenTaiKhoan, CheckBox);*/
            //return Content("Bạn không phải admin, bạn không đủ quyền");*/
            /*  Response.Write("<script>alert('Bạn không phải admin, bạn không đủ quyền truy cập')</script>");
          }
          else
          {
              /*FormsAuthentication.SetAuthCookie(accounts.TenTaiKhoan, CheckBox);*/
            //return Content("Bạn không phải admin, bạn không đủ quyền");*/
            /*  Response.Write("<script>alert('Bạn không phải admin, bạn không đủ quyền truy cập')</script>");
          }
      }
      else
      {
          Response.Write("<script>alert('Tài khoản hoặc mật khẩu không đúng')</script>");

      }
      return View(accounts);*/

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
                    return RedirectToAction("Index", "MainAdmin");
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
                    Response.Write("<script>alert('Bạn không phải admin, bạn không đủ quyền truy cập')</script>");

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

        
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
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
                if(isAminLogin == true)
                {
                    if(result.Quyen == CommonConstants.ADMIN)
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