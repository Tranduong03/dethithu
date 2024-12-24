using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dethithu.Models
{
    [MetadataType(typeof(SanphamMetadata))]
    public partial class Sanpham
    {
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }

    public class SanphamMetadata
    {
        [Display(Name = "Mã sản phẩm")]
        public int SanphamID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống")]
        public string TenSanpham { get; set; }

        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Display(Name = "Giá bán")]
        [Required(ErrorMessage = "Giá bán không được bỏ trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải là số dương")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public decimal Gia { get; set; }

        [Display(Name = "Trạng thái sản phẩm")]
        public Nullable<byte> TrangThai { get; set; }

        [Display(Name = "Ảnh đại diện cho sản phẩm")]
        public string AnhDaiDien { get; set; }

        [Display(Name = "Nổi bật")]
        public Nullable<byte> NoiBat { get; set; }

        [Display(Name = "Phân loại sản phảm")]
        public Nullable<int> PhanLoaiSanPhamID { get; set; }

    }
}