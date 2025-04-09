using Microsoft.EntityFrameworkCore;
using QuanLyKaraoke.Models;

namespace QuanLyKaraoke.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<DatPhong> DatPhongs { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<ChiTietDichVu> ChiTietDichVus { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<LichBaoTri> LichBaoTris { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Tùy chỉnh độ dài chuỗi hoặc khóa chính phức tạp nếu cần ở đây.
        }
    }
}
