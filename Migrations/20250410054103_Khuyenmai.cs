using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyKaraoke.Migrations
{
    /// <inheritdoc />
    public partial class Khuyenmai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HoaDonToiDa",
                table: "KhuyenMais",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "NoiDung",
                table: "KhuyenMais",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoaDonToiDa",
                table: "KhuyenMais");

            migrationBuilder.DropColumn(
                name: "NoiDung",
                table: "KhuyenMais");
        }
    }
}
