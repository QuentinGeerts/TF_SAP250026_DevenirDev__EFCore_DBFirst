using System;
using System.Collections.Generic;

namespace DemoEFDbFirst.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Lastname { get; set; }

    public string? Firstname { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Todo> Todos { get; set; } = new List<Todo>();
}
