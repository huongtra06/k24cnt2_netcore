using LHTraLesson07.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHTraLesson07.Controllers
{
    public class MemberController : Controller
    {
        
        private static readonly List<Member> members = new List<Member>
        {
            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "luonghuongtra",
                Fullname = "Lương Hương Trà",
                Password = "123456",
                Email = "luonghuongtra@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member2",
                Fullname = "Thành viên 2",
                Password = "123456",
                Email = "tv2@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member3",
                Fullname = "Thành viên 3",
                Password = "123456",
                Email = "tv3@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member4",
                Fullname = "Thành viên 4",
                Password = "123456",
                Email = "tv4@gmail.com"
            },

            new Member
            {
                MemberId = Guid.NewGuid().ToString(),
                Username = "member5",
                Fullname = "Thành viên 5",
                Password = "123456",
                Email = "tv5@gmail.com"
            }
        };

       
        public IActionResult Index()
        {
            var member = new Member();

            member.MemberId = Guid.NewGuid().ToString();
            member.Username = "luonghuongtra";
            member.Fullname = "Lương Hương Trà";
            member.Password = "123456";
            member.Email = "luonghuongtra@gmail.com";

            return View(member);
        }

      
        public IActionResult GetMembers()
        {
            ViewBag.members = members;

            return View();
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }

            member.MemberId = Guid.NewGuid().ToString();

            members.Add(member);

            return RedirectToAction("GetMembers");
        }
    }
}