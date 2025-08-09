using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentmanagement.Models;
using studentmanagement.ViewModels;

namespace studentmanagement.Controllers
{
    public class StudentsController : Controller
    {
        public readonly PostgresContext db;

        public StudentsController(PostgresContext db) { this.db = db; }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            var student = db.Students.Include(s=> s.Dep).ToList();
            return View(student);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new StudentFormViewModel
            {
                Departments = db.Departments.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(StudentFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Departments = db.Departments.ToList(); // لإعادة عرض القائمة
                return View(model);
            }

            var student = new Student
            {
                Name = model.Name,
                Age = model.Age,
                Email = model.Email,
                DepId = model.DepId
            };

            db.Students.Add(student);
            db.SaveChanges();

            TempData["Success"] = "Student added successfully!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if (student == null) return NotFound();

            var viewModel = new StudentFormViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Email = student.Email,
                DepId = student.DepId,
                Departments = db.Departments.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(StudentFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Departments = db.Departments.ToList();
                return View(model);
            }

            var student = db.Students.Find(model.Id);
            if (student == null) return NotFound();

            student.Name = model.Name;
            student.Age = model.Age;
            student.Email = model.Email;
            student.DepId = model.DepId;

            db.SaveChanges();

            TempData["Success"] = "Student updated successfully!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = db.Students.Include(s => s.Dep).FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = db.Students.Find(id);
            if (student == null) return NotFound();

            db.Students.Remove(student);
            db.SaveChanges();

            TempData["Success"] = "Student deleted successfully!";
            return RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = db.Students.Include(s => s.Dep).FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound();

            return View(student);
        }




    }
}
