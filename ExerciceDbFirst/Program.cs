/*
 * Exercice DBFirst - Récupération de la base de données "DBSlide"
 * Importer la base de donnée "DBSlide" en tant que projet EFCore.
 * Afficher la liste des étudiants ainsi que le nom de la section dans laquelle ils sont.
 */

using ExerciceDbFirst.Data;
using Microsoft.EntityFrameworkCore;

using (DbslideContext context = new DbslideContext())
{
    var studentsWithSectionName = context.Students;

	foreach (var s in studentsWithSectionName)
	{
		// ...
	}

	foreach (var s in context.Students.Include(s => s.Section))
	{
        Console.WriteLine($"{s.LastName?.PadLeft(15, ' ')} {s.FirstName?.PadLeft(15, ' ')} {s.Section?.SectionName?.PadLeft(20, ' ')}");
	}

}

