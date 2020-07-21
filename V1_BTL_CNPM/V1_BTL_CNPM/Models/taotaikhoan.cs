using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace V1_BTL_CNPM.Models
{
    public class taotaikhoan
    {
        [Required(ErrorMessage = "Chưa nhập mã nhân sự")]
        public string MaNS { get; set; }

        [Required(ErrorMessage = "Chưa nhập họ tên")]
        public string HoTen { get; set; }
        [Required(ErrorMessage = "Chưa nhập ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [Required(ErrorMessage = "Chưa nhập địa chỉ")]
        public string DiaChi { get; set; }
        public int MaTK { get; set; }

        
        public DateTime NgayTao { get; set; }

        [Required(ErrorMessage = "Chưa nhập mã khoa")]
        public string MaKhoa { get; set; }

        [Required(ErrorMessage = "Chưa nhập tài khoản")]
        public string TenTaiKhoan { get; set; }

        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string MatKhau { get; set; }
        [Required(ErrorMessage = "Chưa chọn quyền truy cập")]
        public int Quyen { get; set; }
        [Required(ErrorMessage = "Chưa nhập giới tính")]
        public string GioiTinh { get; set; }
        [Required(ErrorMessage = "Chưa nhập quê quán")]
        public string QueQuan { get; set; }
        [Required(ErrorMessage = "Chưa nhập số điện thoại")]
        public string SoDienThoai { get; set; }
        [Required(ErrorMessage = "Chưa nhập email")]
        public string Email { get; set; }

        [DisplayName("Upload File")]
        public string HinhAnh { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}