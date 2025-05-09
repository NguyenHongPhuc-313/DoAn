﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyKaraoke.Data;

#nullable disable

namespace QuanLyKaraoke.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LichBaoTri", b =>
                {
                    b.Property<int>("MaBaoTri")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaBaoTri"));

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("MaBaoTri");

                    b.HasIndex("MaPhong");

                    b.ToTable("LichBaoTris");
                });

            modelBuilder.Entity("NhanVien", b =>
                {
                    b.Property<int>("MaNV")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaNV"));

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("NgayTuyenDung")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("MaNV");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.ChiTietDichVu", b =>
                {
                    b.Property<int>("MaChiTietDichVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietDichVu"));

                    b.Property<decimal>("DonGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaDatPhong")
                        .HasColumnType("int");

                    b.Property<int>("MaDichVu")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietDichVu");

                    b.HasIndex("MaDatPhong");

                    b.HasIndex("MaDichVu");

                    b.ToTable("ChiTietDichVus");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.DatPhong", b =>
                {
                    b.Property<int>("MaDatPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDatPhong"));

                    b.Property<int>("MaKhachHang")
                        .HasColumnType("int");

                    b.Property<int>("MaNV")
                        .HasColumnType("int");

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<DateTime>("ThoiGianBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ThoiGianKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaDatPhong");

                    b.HasIndex("MaKhachHang");

                    b.HasIndex("MaNV");

                    b.HasIndex("MaPhong");

                    b.ToTable("DatPhongs");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.DichVu", b =>
                {
                    b.Property<int>("MaDichVu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDichVu"));

                    b.Property<bool>("CoSan")
                        .HasColumnType("bit");

                    b.Property<string>("DanhMuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonViTinh")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,0)");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDichVu")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaDichVu");

                    b.ToTable("DichVus");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.HoaDon", b =>
                {
                    b.Property<int>("MaHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHoaDon"));

                    b.Property<int>("MaDatPhong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayXuat")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongThucThanhToan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TongSoTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TrangThaiThanhToan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaDatPhong");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.KhachHang", b =>
                {
                    b.Property<int>("MaKhachHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKhachHang"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("MaKhachHang");

                    b.ToTable("KhachHangs");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.KhuyenMai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("HoaDonToiDa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("HoaDonToiThieu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhanTramGiam")
                        .HasColumnType("int");

                    b.Property<string>("TenKhuyenMai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.Phong", b =>
                {
                    b.Property<int>("MaPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhong"));

                    b.Property<decimal>("Gia18hDen24h")
                        .HasColumnType("decimal(18,0)");

                    b.Property<decimal>("Gia9hDen18h")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("LoaiPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoPhong")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("MaPhong");

                    b.ToTable("Phongs");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.TaiKhoan", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTaiKhoan"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("VaiTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaTaiKhoan");

                    b.ToTable("TaiKhoans");
                });

            modelBuilder.Entity("LichBaoTri", b =>
                {
                    b.HasOne("QuanLyKaraoke.Models.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.ChiTietDichVu", b =>
                {
                    b.HasOne("QuanLyKaraoke.Models.DatPhong", "DatPhong")
                        .WithMany("ChiTietDichVus")
                        .HasForeignKey("MaDatPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKaraoke.Models.DichVu", "DichVu")
                        .WithMany()
                        .HasForeignKey("MaDichVu")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DatPhong");

                    b.Navigation("DichVu");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.DatPhong", b =>
                {
                    b.HasOne("QuanLyKaraoke.Models.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("MaKhachHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("MaNV")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLyKaraoke.Models.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.HoaDon", b =>
                {
                    b.HasOne("QuanLyKaraoke.Models.DatPhong", "DatPhong")
                        .WithMany()
                        .HasForeignKey("MaDatPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DatPhong");
                });

            modelBuilder.Entity("QuanLyKaraoke.Models.DatPhong", b =>
                {
                    b.Navigation("ChiTietDichVus");
                });
#pragma warning restore 612, 618
        }
    }
}
