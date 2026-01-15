using System;
using System.Collections.Generic;

namespace ExerciceDbFirst.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string? SectionName { get; set; }

    public int? DelegateId { get; set; }

    public virtual ICollection<Professor> Professors { get; set; } = new List<Professor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
