using System.ComponentModel.DataAnnotations;
using studentmanagement.Models;

namespace studentmanagement.ViewModels
{
    public class StudentFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int? DepId { get; set; }

        public List<Department>? Departments { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

    }
}
