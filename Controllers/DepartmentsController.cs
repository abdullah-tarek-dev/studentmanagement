using System;
using Microsoft.AspNetCore.Mvc;
using studentmanagement.Models;
using studentmanagement.ViewModels;
using Microsoft.EntityFrameworkCore;
using studentmanagement.ViewModels;


namespace studentmanagement.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly PostgresContext _context;

        public DepartmentsController(PostgresContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
  

        public IActionResult All()
        {
            var departments = _context.Departments
                .Include(d => d.Students)
                .ToList();

            var viewModel = departments.Select(d => new DepartmentWithStudentsViewModel
            {
                DepartmentName = d.Name,
                Students = d.Students.Select(s => new StudentFormViewModel
                {
                    Name = s.Name,
                    Email = s.Email
                }).ToList()
            }).ToList();

            return View(viewModel);
        }
    }
}
