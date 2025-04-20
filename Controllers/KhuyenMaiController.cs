using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyKaraoke.Data;
using QuanLyKaraoke.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Linq;

public class KhuyenMaiController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public KhuyenMaiController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.KhuyenMais.OrderByDescending(x => x.NgayBatDau).ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(KhuyenMai khuyenMai, IFormFile HinhAnhFile)
    {
        if (ModelState.IsValid)
        {
            if (HinhAnhFile != null && HinhAnhFile.Length > 0)
            {
                // Tạo tên file duy nhất
                string fileName = Path.GetFileName(HinhAnhFile.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/khuyenmai", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await HinhAnhFile.CopyToAsync(stream);
                }

                khuyenMai.HinhAnh = fileName;
            }

            _context.Add(khuyenMai);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Thêm khuyến mãi thành công!";
            return RedirectToAction(nameof(Index));
        }

        return View(khuyenMai);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var khuyenMai = await _context.KhuyenMais.FindAsync(id);
        if (khuyenMai == null) return NotFound();
        return View(khuyenMai);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, KhuyenMai khuyenMai)
    {
        if (ModelState.IsValid)
        {
            try
            {
                if (khuyenMai.HinhAnhFile != null)
                {
                    string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images/khuyenmai");
                    Directory.CreateDirectory(folder);

                    string fileName = Guid.NewGuid() + "_" + khuyenMai.HinhAnhFile.FileName;
                    string filePath = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await khuyenMai.HinhAnhFile.CopyToAsync(stream);
                    }

                    khuyenMai.HinhAnh = "/images/khuyenmai/" + fileName;
                }

                _context.Update(khuyenMai);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã cập nhật khuyến mãi thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.KhuyenMais.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }
        }
        return View(khuyenMai);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var khuyenMai = await _context.KhuyenMais.FindAsync(id);
        if (khuyenMai == null) return NotFound();
        return View(khuyenMai);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var khuyenMai = await _context.KhuyenMais.FindAsync(id);
        if (khuyenMai != null)
        {
            _context.KhuyenMais.Remove(khuyenMai);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Đã xóa khuyến mãi thành công!";
        }

        return RedirectToAction(nameof(Index));
    }
}
