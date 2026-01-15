using DemoEFCodeFirst.Configurations;
using DemoEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCodeFirst.Data;

public class DataContext : DbContext
{

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Creator> Creators { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<FilmActor> FilmActors { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDB;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FilmActor>()
            .HasNoKey();

        //modelBuilder.ApplyConfiguration(new FilmConfiguration());

        // Permet de fournir le projet où le DataContext est
        // pour ajouter automatiquement les fichiers qui implémentent l'interface
        // IEntityTypeConfiguration<T>
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
