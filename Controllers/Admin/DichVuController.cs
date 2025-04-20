using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKaraoke.Data;
using QuanLyKaraoke.Models;
using System.Threading.Tasks;

namespace QuanLyKaraoke.Controllers.Admin
{
    [Route("Admin/[controller]")]
    public class DichVuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DichVuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DichVu
        [HttpGet]
        public IActionResult Index()
        {
            var services = _context.DichVus.ToList();
            return View(services);
        }

        // GET: Admin/DichVu/GetService/5
        [HttpGet("GetService/{id}")]
        public IActionResult GetService(int id)
        {
            var service = _context.DichVus.Find(id);
            if (service == null)
            {
                return NotFound();
            }
            return Json(service);
        }

        // POST: Admin/DichVu/Create
        [HttpPost("Create")]
        public IActionResult Create([FromBody] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                _context.DichVus.Add(dichVu);
                _context.SaveChanges();
                return Json(new { success = true, message = "Thêm dịch vụ thành công" });
            }
            return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
        }

        // POST: Admin/DichVu/Edit
        [HttpPost("Edit")]
        public IActionResult Edit([FromBody] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                _context.DichVus.Update(dichVu);
                _context.SaveChanges();
                return Json(new { success = true, message = "Cập nhật dịch vụ thành công" });
            }
            return Json(new { success = false, message = "Dữ liệu không hợp lệ" });
        }

        // POST: Admin/DichVu/Delete/5
        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var service = _context.DichVus.Find(id);
            if (service == null)
            {
                return Json(new { success = false, message = "Không tìm thấy dịch vụ" });
            }

            _context.DichVus.Remove(service);
            _context.SaveChanges();
            return Json(new { success = true, message = "Xóa dịch vụ thành công" });
        }
    }
} 