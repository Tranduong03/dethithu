//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dethithu.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Khachhang
    {
        public Khachhang()
        {
            this.DonHangs = new HashSet<DonHang>();
        }
    
        public int KhachhangID { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public System.DateTime NgayDangKy { get; set; }
    
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
