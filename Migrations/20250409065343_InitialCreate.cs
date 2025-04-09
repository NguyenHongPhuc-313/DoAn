using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKaraoke.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    MaDichVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDichVu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoSan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.MaDichVu);
                });

            migrationBuilder.CreateTable(
                name: "KhachHangs",
                columns: table => new
                {
                    MaKhachHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHangs", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NgayTuyenDung = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.MaNV);
                });

            migrationBuilder.CreateTable(
                name: "Phongs",
                columns: table => new
                {
                    MaPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoPhong = table.Column<int>(type: "int", nullable: false),
                    LoaiPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaMoiGio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongs", x => x.MaPhong);
                });

            migrationBuilder.CreateTable(
                name: "DatPhongs",
                columns: table => new
                {
                    MaDatPhong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhachHang = table.Column<int>(type: "int", nullable: false),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatPhongs", x => x.MaDatPhong);
                    table.ForeignKey(
                        name: "FK_DatPhongs_KhachHangs_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHangs",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatPhongs_NhanViens_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NhanViens",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatPhongs_Phongs_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phongs",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichBaoTris",
                columns: table => new
                {
                    MaBaoTri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichBaoTris", x => x.MaBaoTri);
                    table.ForeignKey(
                        name: "FK_LichBaoTris_Phongs_MaPhong",
                        column: x => x.MaPhong,
                        principalTable: "Phongs",
                        principalColumn: "MaPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDichVus",
                columns: table => new
                {
                    MaChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDatPhong = table.Column<int>(type: "int", nullable: false),
                    MaDichVu = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDichVus", x => x.MaChiTiet);
                    table.ForeignKey(
                        name: "FK_ChiTietDichVus_DatPhongs_MaDatPhong",
                        column: x => x.MaDatPhong,
                        principalTable: "DatPhongs",
                        principalColumn: "MaDatPhong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDichVus_DichVus_MaDichVu",
                        column: x => x.MaDichVu,
                        principalTable: "DichVus",
                        principalColumn: "MaDichVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHoaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDatPhong = table.Column<int>(type: "int", nullable: false),
                    TongSoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PhuongThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThaiThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayXuat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDons_DatPhongs_MaDatPhong",
                        column: x => x.MaDatPhong,
                        principalTable: "DatPhongs",
                        principalColumn: "MaDatPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVus_MaDatPhong",
                table: "ChiTietDichVus",
                column: "MaDatPhong");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVus_MaDichVu",
                table: "ChiTietDichVus",
                column: "MaDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_MaKhachHang",
                table: "DatPhongs",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_MaNV",
                table: "DatPhongs",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_MaPhong",
                table: "DatPhongs",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_MaDatPhong",
                table: "HoaDons",
                column: "MaDatPhong");

            migrationBuilder.CreateIndex(
                name: "IX_LichBaoTris_MaPhong",
                table: "LichBaoTris",
                column: "MaPhong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDichVus");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "LichBaoTris");

            migrationBuilder.DropTable(
                name: "DichVus");

            migrationBuilder.DropTable(
                name: "DatPhongs");

            migrationBuilder.DropTable(
                name: "KhachHangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "Phongs");
        }
    }
}
