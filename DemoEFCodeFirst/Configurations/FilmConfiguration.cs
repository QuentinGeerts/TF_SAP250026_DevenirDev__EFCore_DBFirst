using DemoEFCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoEFCodeFirst.Configurations;

public class FilmConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
    {
        builder.ToTable("Film", schema =>
        {
            schema.HasCheckConstraint("CK_Film_ReleasedYear_Before1950", "ReleasedYear >= 1950");
        });

        // Configuration de la clef primaire
        builder.HasKey(f => f.Id);
        builder.Property(f => f.Id).UseIdentityColumn();

        // Configuration des colonnes
        builder.Property(f => f.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.ReleasedYear)
            .IsRequired()
            .HasComment("L'année de sortie du film");

        builder.HasOne(c => c.Creator).WithMany(f => f.Films)
            .HasForeignKey(f => f.CreatorId);

    }
}
