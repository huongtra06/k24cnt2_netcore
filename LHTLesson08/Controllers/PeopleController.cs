using LHTLesson08.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHTLesson08.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            var people = DataLocal.People;
            return View(people);
        }

        public IActionResult Details(int id)
        {
            var person = DataLocal.People.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(People person)
        {
            if (ModelState.IsValid)
            {
                person.Id = DataLocal.People.Count + 1;
                DataLocal.People.Add(person);

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Edit(int id)
        {
            var person = DataLocal.People.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost]
        public IActionResult Edit(People person)
        {
            var existingPerson = DataLocal.People
                .FirstOrDefault(x => x.Id == person.Id);

            if (existingPerson == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                existingPerson.Name = person.Name;
                existingPerson.Email = person.Email;
                existingPerson.Phone = person.Phone;
                existingPerson.Address = person.Address;
                existingPerson.Avatar = person.Avatar;
                existingPerson.Birthday = person.Birthday;
                existingPerson.Bio = person.Bio;
                existingPerson.Gender = person.Gender;

                return RedirectToAction(nameof(Index));
            }

            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = DataLocal.People.FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var person = DataLocal.People.FirstOrDefault(x => x.Id == id);

            if (person != null)
            {
                DataLocal.People.Remove(person);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}