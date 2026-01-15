using System;
using System.Collections.Generic;

namespace DemoEFDbFirst.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
