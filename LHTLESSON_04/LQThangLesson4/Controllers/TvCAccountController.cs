using LQThangLesson4.Models;
using Microsoft.AspNetCore.Mvc;

namespace LQThangLesson4.Controllers
{
    public class TvCAccountController : Controller
    {
        // Du lieu mau
        private static readonly List<TvCAccount> TvCAccounts = new()
        {
            new TvCAccount
            {
                Id = 1,
                Name = "Nguyen Van An",
                Email = "nguyenvanan@gmail.com",
                Phone = "0987654321",
                Avatar = "https://i.pravatar.cc/300?img=12",
                Address = "Ha Noi",
                Bio = "Sinh vien Cong nghe thong tin",
                Gender = "Nam",
                Birthday = new DateTime(2004, 5, 10)
            },

            new TvCAccount
            {
                Id = 2,
                Name = "Tran Thi Binh",
                Email = "tranthibinh@gmail.com",
                Phone = "0977123456",
                Avatar = "https://i.pravatar.cc/300?img=47",
                Address = "Hai Phong",
                Bio = "Sinh vien Dai hoc",
                Gender = "Nu",
                Birthday = new DateTime(2005, 8, 15)
            },

            new TvCAccount
            {
                Id = 3,
                Name = "Le Quang Thang",
                Email = "lequangthang@gmail.com",
                Phone = "0968123456",
                Avatar = "https://i.pravatar.cc/300?img=11",
                Address = "Ha Noi",
                Bio = "Lap trinh vien .NET",
                Gender = "Nam",
                Birthday = new DateTime(2004, 10, 20)
            },

            new TvCAccount
            {
                Id = 4,
                Name = "Pham Minh Duc",
                Email = "phamminhduc@gmail.com",
                Phone = "0912345678",
                Avatar = "https://i.pravatar.cc/300?img=33",
                Address = "Nam Dinh",
                Bio = "Sinh vien CNTT",
                Gender = "Nam",
                Birthday = new DateTime(2003, 12, 5)
            },

            new TvCAccount
            {
                Id = 5,
                Name = "Hoang Thu Ha",
                Email = "hoangthuha@gmail.com",
                Phone = "0909876543",
                Avatar = "https://i.pravatar.cc/300?img=44",
                Address = "Bac Ninh",
                Bio = "Web Developer",
                Gender = "Nu",
                Birthday = new DateTime(2005, 3, 25)
            },

            new TvCAccount
            {
                Id = 6,
                Name = "Do Van Nam",
                Email = "dovannam@gmail.com",
                Phone = "0981234567",
                Avatar = "https://i.pravatar.cc/300?img=68",
                Address = "Thai Binh",
                Bio = "Sinh vien",
                Gender = "Nam",
                Birthday = new DateTime(2004, 7, 18)
            }
        };


        // =========================================
        // INDEX - DANH SACH
        // =========================================

        public IActionResult Index(string search, string gender)
        {
            var accounts = TvCAccounts.AsEnumerable();

            // Tim kiem
            if (!string.IsNullOrWhiteSpace(search))
            {
                accounts = accounts.Where(x =>
                    x.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    x.Email.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    x.Phone.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            // Loc gioi tinh
            if (!string.IsNullOrWhiteSpace(gender))
            {
                accounts = accounts.Where(x =>
                    x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.Search = search;
            ViewBag.Gender = gender;

            return View(accounts.ToList());
        }


        // =========================================
        // DETAILS
        // =========================================

        public IActionResult Details(int id)
        {
            var account = TvCAccounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }


        // =========================================
        // CREATE - GET
        // =========================================

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // =========================================
        // CREATE - POST
        // =========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TvCAccount account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }

            account.Id = TvCAccounts.Count == 0
                ? 1
                : TvCAccounts.Max(x => x.Id) + 1;

            if (string.IsNullOrWhiteSpace(account.Avatar))
            {
                account.Avatar = "https://i.pravatar.cc/300?img=1";
            }

            TvCAccounts.Add(account);

            TempData["Success"] = "Them tai khoan thanh cong!";

            return RedirectToAction(nameof(Index));
        }


        // =========================================
        // EDIT - GET
        // =========================================

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var account = TvCAccounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }


        // =========================================
        // EDIT - POST
        // =========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TvCAccount account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(account);
            }

            var oldAccount = TvCAccounts.FirstOrDefault(x => x.Id == id);

            if (oldAccount == null)
            {
                return NotFound();
            }

            oldAccount.Name = account.Name;
            oldAccount.Email = account.Email;
            oldAccount.Phone = account.Phone;
            oldAccount.Avatar = account.Avatar;
            oldAccount.Address = account.Address;
            oldAccount.Bio = account.Bio;
            oldAccount.Gender = account.Gender;
            oldAccount.Birthday = account.Birthday;

            TempData["Success"] = "Cap nhat tai khoan thanh cong!";

            return RedirectToAction(nameof(Index));
        }


        // =========================================
        // DELETE - GET
        // =========================================

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var account = TvCAccounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }


        // =========================================
        // DELETE - POST
        // =========================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var account = TvCAccounts.FirstOrDefault(x => x.Id == id);

            if (account == null)
            {
                return NotFound();
            }

            TvCAccounts.Remove(account);

            TempData["Success"] = "Xoa tai khoan thanh cong!";

            return RedirectToAction(nameof(Index));
        }
    }
}