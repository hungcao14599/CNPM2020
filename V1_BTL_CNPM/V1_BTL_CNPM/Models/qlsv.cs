﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V1_BTL_CNPM.Models
{
    public class qlsv
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }

        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int MaTK { get; set; }
        public string MaNganh { get; set; }

        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }

        public string GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        //public HttpPostedFile ImageFile { get; set; }
        public string HinhAnh { get; set; }

        public string MaKhoa { get; set; }

        public virtual khoa khoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public int Quyen { get; set; }
    }
}