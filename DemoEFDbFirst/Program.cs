/*
 * Démonstration Entity Framework Core - Approche DB First
 */

using DemoEFDbFirst.Data;

Console.WriteLine("Démonstration EFCore");

// 1.  Package à installer
// Microsoft.EntityFrameworkCore:
// → pour toutes les fonctionnalités de EFCore

// Microsoft.EntityFrameworkCore.SqlServer:
// → pour le fournisseur de SQL Server

// Microsoft.EntityFrameworkCore.Tools:
// → pour les outils de migration et de gestion de la base de données

// Microsoft.EntityFrameworkCore.Design:
// → pour la récupération d'une DB existante


// 2.  Ouvrir la console des packages nuget
// Tools =>  NuGet Package Manager => Package Manager Console
// Bien sélectionner le projet par défaut (plus tard: DAL)

// 3.  Récupération de la connection string pour s'y connecter
// Server Explorer => Clic droit sur la connexion => Propriétés => Copier la CS

// Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoADO;Integrated Security=True;Encrypt=True;Trust Server Certificate=True

// 4. Dans la console des packages nuget
// NuGet: Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoADO;Integrated Security=True;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models


using (DemoAdoContext c = new DemoAdoContext())
{
    var users = c.VUsers.ToList();

    foreach (var u in users)
    {
        Console.WriteLine($"{u.Id} {u.Lastname} {u.Firstname} {u.Email}");
    }
}