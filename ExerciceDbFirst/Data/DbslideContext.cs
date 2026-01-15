using System;
using System.Collections.Generic;
using ExerciceDbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciceDbFirst.Data;

public partial class DbslideContext : DbContext
{
    public DbslideContext()
    {
    }

    public DbslideContext(DbContextOptions<DbslideContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBSlide;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("course");

            entity.Property(e => e.CourseId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("course_id");
            entity.Property(e => e.CourseEcts)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("course_ects");
            entity.Property(e => e.CourseName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("course_name");
            entity.Property(e => e.ProfessorId).HasColumnName("professor_id");

            entity.HasOne(d => d.Professor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_course_professor");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Grade1);

            entity.ToTable("grade");

            entity.Property(e => e.Grade1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("grade");
            entity.Property(e => e.LowerBound).HasColumnName("lower_bound");
            entity.Property(e => e.UpperBound).HasColumnName("upper_bound");
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.ToTable("professor");

            entity.Property(e => e.ProfessorId)
                .ValueGeneratedNever()
                .HasColumnName("professor_id");
            entity.Property(e => e.ProfessorEmail)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("professor_email");
            entity.Property(e => e.ProfessorHireDate)
                .HasColumnType("datetime")
                .HasColumnName("professor_hire_date");
            entity.Property(e => e.ProfessorName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("professor_name");
            entity.Property(e => e.ProfessorOffice).HasColumnName("professor_office");
            entity.Property(e => e.ProfessorSurname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("professor_surname");
            entity.Property(e => e.ProfessorWage).HasColumnName("professor_wage");
            entity.Property(e => e.SectionId).HasColumnName("section_id");

            entity.HasOne(d => d.Section).WithMany(p => p.Professors)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_professor_section");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("section");

            entity.Property(e => e.SectionId)
                .ValueGeneratedNever()
                .HasColumnName("section_id");
            entity.Property(e => e.DelegateId).HasColumnName("delegate_id");
            entity.Property(e => e.SectionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("section_name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birth_date");
            entity.Property(e => e.CourseId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("course_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.SectionId).HasColumnName("section_id");
            entity.Property(e => e.YearResult).HasColumnName("year_result");

            entity.HasOne(d => d.Section).WithMany(p => p.Students)
                .HasForeignKey(d => d.SectionId)
                .HasConstraintName("FK_student_section");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
