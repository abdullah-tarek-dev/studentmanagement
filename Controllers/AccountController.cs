using System.Text;
using Microsoft.AspNetCore.Mvc;
using studentmanagement.Models;
using studentmanagement.Models.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace studentmanagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly PostgresContext _context;

        public AccountController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                if (_context.Usersses.Any(u => u.Email == model.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(model);
                }

                var user = new Userss
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Passwordhash = HashPassword(model.Password),
                    // مبدئيًا من غير تشفير

                    CreatedAt = DateTime.UtcNow// بدلاً من DateTime.Now

                };

                _context.Usersses.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hashedPassword = HashPassword(model.Password); // شفّر الباسورد بنفس طريقة التخزين

                var user = _context.Usersses
                    .FirstOrDefault(u => u.Email == model.Email && u.Passwordhash == hashedPassword);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid email or password");
                    return View(model);
                }

                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserName", user.FullName);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // يحول البايتس لسلسلة هكس (hex string)
                }
                return builder.ToString();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
