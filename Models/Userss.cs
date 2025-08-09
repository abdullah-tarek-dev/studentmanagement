using System;
using System.Collections.Generic;

namespace studentmanagement.Models;

public partial class Userss
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
