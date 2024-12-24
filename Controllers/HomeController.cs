using dethithu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dethithu.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanQuanAoEntities data = new QuanLyBanQuanAoEntities();

        // GET: Home
        public ActionResult Index()
        {
            var allProducts = data.Sanphams.ToList();
            ViewData["AllProducts"] = allProducts;
            return View();
        }

        public ActionResult Phanloai() 
        { 
            var phanloai = from pl in data.PhanLoaiSanPhams select pl;
            return PartialView(phanloai);
        }

        public ActionResult SanPhamTheoPhanLoai(int id) 
        {
            var Sanpham = id == 0 
                ? data.Sanphams.ToList()
                : data.Sanphams.Where(sp => sp.PhanLoaiSanPhamID == id).ToList();

            //var Sanpham = from sp in data.Sanphams where sp.PhanLoaiSanPhamID == id select sp;

            return PartialView(Sanpham);
        }

        public ActionResult ThemSanPham()
        {
            var phanloai = data.PhanLoaiSanPhams.ToList();
            ViewBag.PhanLoaiSanPhamList = new SelectList(phanloai, "PhanLoaiSanPhamID", "TenPhanLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSanPham(Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.ImageFile != null && sanpham.ImageFile.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg" };
                    var fileExtension = Path.GetExtension(sanpham.ImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("ImageFile", "Only .jpg files are allowed.");
                    }
                    else
                    {
                        try
                        {
                            var fileName = Path.GetFileName(sanpham.ImageFile.FileName);
                            var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                            sanpham.ImageFile.SaveAs(path);
                            sanpham.AnhDaiDien = fileName;
                        }
                        catch (Exception ex)
                        {
                            ModelState.AddModelError("", $"Error saving file: {ex.Message}");
                        }
                    }
                }

                if (ModelState.IsValid)
                {
                    data.Sanphams.Add(sanpham); 
                    data.SaveChanges();        

                    return RedirectToAction("Index"); 
                }
            }

            // Nếu có lỗi, trả về form cùng với danh sách phân loại sản phẩm
            ViewBag.PhanLoaiSanPhamList = new SelectList(data.PhanLoaiSanPhams, "PhanLoaiSanPhamID", "TenPhanLoai");
            return View(sanpham);
        }

    }
}