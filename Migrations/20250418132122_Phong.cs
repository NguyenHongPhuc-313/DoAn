using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKaraoke.Migrations
{
    /// <inheritdoc />
    public partial class Phong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatPhongs_BangGias_banggiaId",
                table: "DatPhongs");

            migrationBuilder.DropForeignKey(
                name: "FK_DatPhongs_KhachHangs_khachhangMaKhachHang",
                table: "DatPhongs");

            migrationBuilder.DropForeignKey(
                name: "FK_DatPhongs_Phongs_phongMaPhong",
                table: "DatPhongs");

            migrationBuilder.DropForeignKey(
                name: "FK_DichVus_BangGias_BangGiaId",
                table: "DichVus");

            migrationBuilder.DropTable(
                name: "BangGias");

            migrationBuilder.DropIndex(
                name: "IX_DichVus_BangGiaId",
                table: "DichVus");

            migrationBuilder.DropIndex(
                name: "IX_DatPhongs_banggiaId",
                table: "DatPhongs");

            migrationBuilder.DropIndex(
                name: "IX_DatPhongs_khachhangMaKhachHang",
                table: "DatPhongs");

            migrationBuilder.DropIndex(
                name: "IX_DatPhongs_phongMaPhong",
                table: "DatPhongs");

            migrationBuilder.DropColumn(
                name: "BangGiaId",
                table: "DichVus");

            migrationBuilder.DropColumn(
                name: "banggiaId",
                table: "DatPhongs");

            migrationBuilder.DropColumn(
                name: "khachhangMaKhachHang",
                table: "DatPhongs");

            migrationBuilder.DropColumn(
                name: "phongMaPhong",
                table: "DatPhongs");

            migrationBuilder.AddColumn<decimal>(
                name: "Gia18hDen24h",
                table: "Phongs",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Gia9hDen18h",
                table: "Phongs",
                type: "decimal(18,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "NgayCapNhat",
                table: "Phongs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gia18hDen24h",
                table: "Phongs");

            migrationBuilder.DropColumn(
                name: "Gia9hDen18h",
                table: "Phongs");

            migrationBuilder.DropColumn(
                name: "NgayCapNhat",
                table: "Phongs");

            migrationBuilder.AddColumn<int>(
                name: "BangGiaId",
                table: "DichVus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "banggiaId",
                table: "DatPhongs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "khachhangMaKhachHang",
                table: "DatPhongs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "phongMaPhong",
                table: "DatPhongs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BangGias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gia18hDen24h = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Gia9hDen18h = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    LoaiPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayApDung = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BangGias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DichVus_BangGiaId",
                table: "DichVus",
                column: "BangGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_banggiaId",
                table: "DatPhongs",
                column: "banggiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_khachhangMaKhachHang",
                table: "DatPhongs",
                column: "khachhangMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_phongMaPhong",
                table: "DatPhongs",
                column: "phongMaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_DatPhongs_BangGias_banggiaId",
                table: "DatPhongs",
                column: "banggiaId",
                principalTable: "BangGias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DatPhongs_KhachHangs_khachhangMaKhachHang",
                table: "DatPhongs",
                column: "khachhangMaKhachHang",
                principalTable: "KhachHangs",
                principalColumn: "MaKhachHang");

            migrationBuilder.AddForeignKey(
                name: "FK_DatPhongs_Phongs_phongMaPhong",
                table: "DatPhongs",
                column: "phongMaPhong",
                principalTable: "Phongs",
                principalColumn: "MaPhong");

            migrationBuilder.AddForeignKey(
                name: "FK_DichVus_BangGias_BangGiaId",
                table: "DichVus",
                column: "BangGiaId",
                principalTable: "BangGias",
                principalColumn: "Id");
        }
    }
}
