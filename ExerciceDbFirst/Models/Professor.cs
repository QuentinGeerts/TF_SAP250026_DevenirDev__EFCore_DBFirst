using System;
using System.Collections.Generic;

namespace ExerciceDbFirst.Models;

public partial class Professor
{
    public int ProfessorId { get; set; }

    public string ProfessorName { get; set; } = null!;

    public string ProfessorSurname { get; set; } = null!;

    public int SectionId { get; set; }

    public int ProfessorOffice { get; set; }

    public string ProfessorEmail { get; set; } = null!;

    public DateTime ProfessorHireDate { get; set; }

    public int ProfessorWage { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Section Section { get; set; } = null!;
}
