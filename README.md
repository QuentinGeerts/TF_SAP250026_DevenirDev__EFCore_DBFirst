# TF_SAP250026 - Entity Framework Core : Approche DB-First

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-10.0.2-512BD4?style=flat&logo=.net)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=flat&logo=microsoftsqlserver)
![License](https://img.shields.io/badge/License-MIT-green.svg?style=flat)
![Language](https://img.shields.io/badge/Language-C%23-239120?style=flat&logo=csharp)
![Approach](https://img.shields.io/badge/Approach-Database--First-blueviolet?style=flat)

## 📋 Description

Ce projet pédagogique est destiné à l'apprentissage d'**Entity Framework Core** avec l'**approche Database-First (DB-First)**. Il fait partie de la formation "Devenir Développeur" dispensée à Technofutur TIC.

L'approche DB-First permet de générer automatiquement les classes de modèles et le contexte EF Core à partir d'une base de données existante.

## 🎯 Objectifs pédagogiques

- Comprendre l'approche Database-First avec Entity Framework Core
- Maîtriser la génération automatique de modèles depuis une base de données existante
- Apprendre à manipuler des données avec EF Core (lectures, relations)
- Comprendre les différents types de relations (One-to-Many, Many-to-One)
- Utiliser les DbSet et les vues SQL dans EF Core
- Maîtriser le concept d'Eager Loading avec `.Include()`

## 🛠️ Prérequis

- **.NET 10.0 SDK** ou supérieur
- **Visual Studio 2022** ou **Visual Studio Code**
- **SQL Server** (LocalDB ou instance complète)
- Bases de données :
  - `DemoADO` (pour la démonstration)
  - `DBSlide` (pour l'exercice)

## 📦 Packages NuGet utilisés

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.2" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="10.0.2" />
```

### Rôle des packages :
- **Microsoft.EntityFrameworkCore** : Fonctionnalités principales d'EF Core
- **Microsoft.EntityFrameworkCore.SqlServer** : Fournisseur pour SQL Server
- **Microsoft.EntityFrameworkCore.Tools** : Outils de migration et gestion de la base de données
- **Microsoft.EntityFrameworkCore.Design** : Récupération d'une base de données existante (scaffolding)

## 📁 Structure du projet

```
TF_SAP250026_DevenirDev__EFCore_DBFirst/
│
├── DemoEFDbFirst/                    # Projet de démonstration
│   ├── Data/
│   │   └── DemoAdoContext.cs        # DbContext généré
│   ├── Models/
│   │   ├── User.cs                  # Entité User
│   │   ├── Todo.cs                  # Entité Todo
│   │   └── VUser.cs                 # Vue V_User
│   └── Program.cs                   # Point d'entrée avec démonstration
│
└── ExerciceDbFirst/                  # Exercice pratique
    ├── Data/
    │   └── DbslideContext.cs        # DbContext généré
    ├── Models/
    │   ├── Student.cs               # Entité Student
    │   ├── Section.cs               # Entité Section
    │   ├── Professor.cs             # Entité Professor
    │   ├── Course.cs                # Entité Course
    │   └── Grade.cs                 # Entité Grade
    └── Program.cs                   # Exercice à compléter
```

## 🚀 Étapes pour utiliser l'approche DB-First

### 1. Installation des packages NuGet

```bash
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Design
```

### 2. Récupération de la chaîne de connexion

1. Ouvrir **Server Explorer** dans Visual Studio
2. Clic droit sur la connexion à la base de données
3. **Propriétés**
4. Copier la **Connection String**

Exemple :
```
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoADO;Integrated Security=True;Encrypt=True;Trust Server Certificate=True
```

### 3. Génération du contexte et des modèles (Scaffolding)

Ouvrir la **Package Manager Console** :
- `Tools` → `NuGet Package Manager` → `Package Manager Console`

Exécuter la commande suivante :

```powershell
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoADO;Integrated Security=True;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models
```

#### Paramètres de la commande :
- **Chaîne de connexion** : Entre guillemets
- **Provider** : `Microsoft.EntityFrameworkCore.SqlServer`
- **-ContextDir** : Dossier de destination du DbContext
- **-OutputDir** : Dossier de destination des modèles

### 4. Options supplémentaires du Scaffold

```powershell
# Générer uniquement certaines tables
Scaffold-DbContext "..." Microsoft.EntityFrameworkCore.SqlServer -Tables User,Todo

# Forcer l'écrasement des fichiers existants
Scaffold-DbContext "..." Microsoft.EntityFrameworkCore.SqlServer -Force

# Utiliser des DataAnnotations au lieu de Fluent API
Scaffold-DbContext "..." Microsoft.EntityFrameworkCore.SqlServer -DataAnnotations

# Ne pas générer la connection string dans le DbContext
Scaffold-DbContext "..." Microsoft.EntityFrameworkCore.SqlServer -NoOnConfiguring
```

## 📚 Démonstration : DemoEFDbFirst

### Base de données DemoADO

Le projet de démonstration utilise la base de données `DemoADO` contenant :

**Tables :**
- `User` : Utilisateurs avec triggers pour IsActive et UpdatedAt
- `Todo` : Tâches liées aux utilisateurs avec triggers

**Vue :**
- `V_User` : Vue simplifiée des utilisateurs

### Concepts démontrés

1. **Génération automatique** des modèles et du contexte
2. **Utilisation d'un DbSet** pour interroger une vue SQL
3. **Relations One-to-Many** : Un User a plusieurs Todos
4. **Propriétés de navigation** : `User.Todos` et `Todo.User`
5. **Valeurs par défaut** en base de données (CreatedAt, IsActive)
6. **Triggers SQL** reconnus par EF Core

### Code de démonstration

```csharp
using (DemoAdoContext c = new DemoAdoContext())
{
    var users = c.VUsers.ToList();

    foreach (var u in users)
    {
        Console.WriteLine($"{u.Id} {u.Lastname} {u.Firstname} {u.Email}");
    }
}
```

## 🎓 Exercice : ExerciceDbFirst

### Base de données DBSlide

Le projet d'exercice utilise la base de données `DBSlide` d'une école contenant :

**Tables :**
- `Student` : Étudiants
- `Section` : Sections/Classes
- `Professor` : Professeurs
- `Course` : Cours
- `Grade` : Notes/Évaluations

### Objectif de l'exercice

**Afficher la liste des étudiants avec le nom de leur section**

### Solution attendue

```csharp
using (DbslideContext context = new DbslideContext())
{
    // Utilisation de Include pour charger la relation (Eager Loading)
    foreach (var s in context.Students.Include(s => s.Section))
    {
        Console.WriteLine($"{s.LastName?.PadLeft(15, ' ')} " +
                         $"{s.FirstName?.PadLeft(15, ' ')} " +
                         $"{s.Section?.SectionName?.PadLeft(20, ' ')}");
    }
}
```

### Concepts à maîtriser

- **Eager Loading** : Charger les données liées avec `.Include()`
- **Lazy Loading** : (Non activé par défaut) Chargement à la demande
- **Explicit Loading** : Chargement manuel des relations
- **Navigation Properties** : Propriétés qui permettent de naviguer entre entités liées

## 🔍 Points importants EF Core

### 1. DbContext

Le `DbContext` est la classe centrale d'EF Core qui :
- Gère la connexion à la base de données
- Expose les `DbSet<T>` pour chaque table/vue
- Configure le mapping objet-relationnel via `OnModelCreating()`

### 2. DbSet<T>

Représente une collection d'entités en mémoire et permet :
- Les opérations CRUD (Create, Read, Update, Delete)
- Les requêtes LINQ

### 3. OnModelCreating()

Méthode où EF Core configure :
- Les relations entre entités
- Les contraintes (clés primaires, étrangères)
- Les valeurs par défaut
- Les triggers
- Les index
- Le mapping des colonnes

### 4. Chargement des données liées

```csharp
// Eager Loading - Chargement immédiat
var students = context.Students.Include(s => s.Section).ToList();

// Explicit Loading - Chargement explicite
var student = context.Students.Find(1);
context.Entry(student).Reference(s => s.Section).Load();

// Lazy Loading - Nécessite Microsoft.EntityFrameworkCore.Proxies
// var section = student.Section; // Chargé automatiquement
```

## ⚠️ Avertissements importants

### Chaîne de connexion en dur

Les contextes générés contiennent un avertissement :

```csharp
#warning To protect potentially sensitive information in your connection string, 
// you should move it out of source code.
```

**En production**, il faut :
1. Stocker la connection string dans `appsettings.json`
2. Utiliser le pattern de configuration ASP.NET Core
3. Supprimer `OnConfiguring()` et injecter les options via le constructeur

### Relations et suppression

Dans les relations, faites attention au comportement de suppression :
- `DeleteBehavior.Cascade` : Suppression en cascade
- `DeleteBehavior.ClientSetNull` : Clé étrangère mise à null côté client
- `DeleteBehavior.Restrict` : Empêche la suppression si des entités liées existent

## 📖 Ressources complémentaires

- [Documentation officielle EF Core](https://learn.microsoft.com/fr-fr/ef/core/)
- [Scaffold-DbContext Documentation](https://learn.microsoft.com/fr-fr/ef/core/cli/powershell#scaffold-dbcontext)
- [Relations dans EF Core](https://learn.microsoft.com/fr-fr/ef/core/modeling/relationships)

## 👨‍🏫 Formateur

**Quentin Geerts** - Instructeur .NET  
Technofutur TIC - Formation "Devenir Développeur"

## 📝 Licence

MIT License - Voir le fichier [LICENSE.txt](LICENSE.txt)
