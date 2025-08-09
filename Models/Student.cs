using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace studentmanagement.Models;

public partial class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; } = null!;


    [Range(18, 100, ErrorMessage = "Age between 18 and 100")]
    public int Age { get; set; }

    public int? DepId { get; set; }

    public virtual Department? Dep { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(100)]
    public string? Email { get; set; } // nullable
}
