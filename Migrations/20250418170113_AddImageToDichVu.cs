using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKaraoke.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToDichVu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDichVus_DichVus_MaDichVu",
                table: "ChiTietDichVus");

            migrationBuilder.RenameColumn(
                name: "ThanhTien",
                table: "ChiTietDichVus",
                newName: "DonGia");

            migrationBuilder.RenameColumn(
                name: "MaChiTiet",
                table: "ChiTietDichVus",
                newName: "MaChiTietDichVu");

            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "DichVus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDichVus_DichVus_MaDichVu",
                table: "ChiTietDichVus",
                column: "MaDichVu",
                principalTable: "DichVus",
                principalColumn: "MaDichVu",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietDichVus_DichVus_MaDichVu",
                table: "ChiTietDichVus");

            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "DichVus");

            migrationBuilder.RenameColumn(
                name: "DonGia",
                table: "ChiTietDichVus",
                newName: "ThanhTien");

            migrationBuilder.RenameColumn(
                name: "MaChiTietDichVu",
                table: "ChiTietDichVus",
                newName: "MaChiTiet");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietDichVus_DichVus_MaDichVu",
                table: "ChiTietDichVus",
                column: "MaDichVu",
                principalTable: "DichVus",
                principalColumn: "MaDichVu",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
