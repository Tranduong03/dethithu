﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyBanQuanAoEntities : DbContext
    {
        public QuanLyBanQuanAoEntities()
            : base("name=QuanLyBanQuanAoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<ChiTietSanPhamMua> ChiTietSanPhamMuas { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<Khachhang> Khachhangs { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }
        public DbSet<PhanLoaiSanPham> PhanLoaiSanPhams { get; set; }
        public DbSet<Sanpham> Sanphams { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}