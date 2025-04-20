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
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<KhuyenMai> KhuyenMais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ giữa DatPhong và ChiTietDichVu
            modelBuilder.Entity<ChiTietDichVu>()
                .HasOne(ctdv => ctdv.DatPhong)
                .WithMany(dp => dp.ChiTietDichVus)
                .HasForeignKey(ctdv => ctdv.MaDatPhong)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChiTietDichVu>()
                .HasOne(ctdv => ctdv.DichVu)
                .WithMany()
                .HasForeignKey(ctdv => ctdv.MaDichVu)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
