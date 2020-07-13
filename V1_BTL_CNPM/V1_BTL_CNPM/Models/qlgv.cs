using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace V1_BTL_CNPM.Models
{
    public class qlgv
    {
        public string MaGV { get; set; }
        public string HoTenGV { get; set; }

        public bool CheckBox { get; set; }

        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int MaTK { get; set; }
        public string MaNganh { get; set; }

        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        
       

        public string MaKhoa { get; set; }

        public virtual khoa khoa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public int Quyen { get; set; }

        //public Nullable<System.DateTime> NgayTao { get; set; }
        //public int MaTK { get; set; }
    }
}