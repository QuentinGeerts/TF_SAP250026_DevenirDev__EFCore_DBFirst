using System;
using System.Collections.Generic;

namespace ExerciceDbFirst.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Login { get; set; }

    public int? SectionId { get; set; }

    public int? YearResult { get; set; }

    public string CourseId { get; set; } = null!;

    public virtual Section? Section { get; set; }
}
