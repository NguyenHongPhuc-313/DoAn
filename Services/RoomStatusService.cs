using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using QuanLyKaraoke.Data;
using QuanLyKaraoke.Models;
using Microsoft.EntityFrameworkCore;

namespace QuanLyKaraoke.Services
{
    public class RoomStatusService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public RoomStatusService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    // Lấy tất cả các phòng
                    var rooms = await dbContext.Phongs.ToListAsync();

                    // Lấy tất cả các đặt phòng đang hoạt động
                    var currentTime = DateTime.Now;
                    var activeBookings = await dbContext.DatPhongs
                        .Where(b => b.ThoiGianBatDau <= currentTime && b.ThoiGianKetThuc >= currentTime)
                        .ToListAsync();

                    // Cập nhật trạng thái cho từng phòng
                    foreach (var room in rooms)
                    {
                        var isBooked = activeBookings.Any(b => b.MaPhong == room.MaPhong);
                        
                        if (isBooked)
                        {
                            room.TrangThai = TrangThaiPhong.DangSuDung;
                        }
                        else
                        {
                            // Kiểm tra xem phòng có đặt trước không
                            var futureBookings = await dbContext.DatPhongs
                                .Where(b => b.MaPhong == room.MaPhong && b.ThoiGianBatDau > currentTime)
                                .AnyAsync();

                            room.TrangThai = futureBookings ? TrangThaiPhong.DaDat : TrangThaiPhong.Trong;
                        }

                        dbContext.Phongs.Update(room);
                    }

                    await dbContext.SaveChangesAsync();
                }

                // Chờ 1 phút trước khi cập nhật lại
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
} 