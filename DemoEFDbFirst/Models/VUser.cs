using System;
using System.Collections.Generic;

namespace DemoEFDbFirst.Models;

public partial class VUser
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Lastname { get; set; }

    public string? Firstname { get; set; }
}
