using LHTRALesson09.Models;
using LHTRALesson09.Services;
using Microsoft.AspNetCore.Mvc;

namespace LHTRALesson09.Controllers;

public class AccountController : Controller
{
    private readonly AccountService _service;
    private readonly IWebHostEnvironment _env;

    public AccountController(AccountService service, IWebHostEnvironment env)
    {
        _service = service;
        _env = env;
    }

    public IActionResult Index(string? keyword, string? gender)
    {
        var accounts = _service.GetAll();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.Trim();
            accounts = accounts.Where(x =>
                x.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                x.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                x.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        if (!string.IsNullOrWhiteSpace(gender) && gender != "Tất cả")
            accounts = accounts.Where(x => x.Gender == gender).ToList();

        ViewBag.Keyword = keyword;
        ViewBag.Gender = gender ?? "Tất cả";
        ViewBag.Total = _service.GetAll().Count;
        ViewBag.Male = _service.GetAll().Count(x => x.Gender == "Nam");
        ViewBag.Female = _service.GetAll().Count(x => x.Gender == "Nữ");

        return View(accounts.OrderBy(x => x.Id));
    }

    public IActionResult Details(int id)
    {
        var account = _service.GetById(id);
        return account == null ? NotFound() : View(account);
    }

    [HttpGet]
    public IActionResult Create() => View(new Account());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Account account, IFormFile? AvatarFile)
    {
        if (await SaveAvatar(account, AvatarFile) is string error)
            ModelState.AddModelError("Avatar", error);

        if (!ModelState.IsValid) return View(account);

        _service.Add(account);
        TempData["Success"] = "Tạo tài khoản thành công!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var account = _service.GetById(id);
        return account == null ? NotFound() : View(account);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Account account, IFormFile? AvatarFile)
    {
        var old = _service.GetById(account.Id);
        if (old == null) return NotFound();

        if (string.IsNullOrWhiteSpace(account.Password))
            account.Password = old.Password;

        if (await SaveAvatar(account, AvatarFile) is string error)
            ModelState.AddModelError("Avatar", error);

        if (!ModelState.IsValid) return View(account);

        _service.Update(account);
        TempData["Success"] = "Cập nhật tài khoản thành công!";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var account = _service.GetById(id);
        return account == null ? NotFound() : View(account);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        if (_service.Delete(id))
        {
            TempData["Success"] = "Đã xóa tài khoản.";
        }
        return RedirectToAction(nameof(Index));
    }

    private async Task<string?> SaveAvatar(Account account, IFormFile? file)
    {
        if (file == null || file.Length == 0) return null;

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp" };

        if (!allowed.Contains(extension))
            return "Ảnh chỉ được dùng JPG, JPEG, PNG hoặc WEBP.";

        if (file.Length > 2 * 1024 * 1024)
            return "Ảnh không được vượt quá 2MB.";

        var folder = Path.Combine(_env.WebRootPath, "uploads");
        Directory.CreateDirectory(folder);

        var fileName = $"{Guid.NewGuid():N}{extension}";
        var path = Path.Combine(folder, fileName);

        await using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        account.Avatar = $"/uploads/{fileName}";
        return null;
    }

    public IActionResult Error() => View("Error");
}
