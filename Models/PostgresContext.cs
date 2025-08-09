using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace studentmanagement.Models
{
    public partial class PostgresContext : DbContext
    {
        public PostgresContext()
        {
        }

        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Userss> Usersses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123456");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Department
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("departments_pkey");

                entity.ToTable("departments");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            // Student
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("students_pkey");

                entity.ToTable("students");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Age).HasColumnName("age");
                entity.Property(e => e.DepId).HasColumnName("dep_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Dep).WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("students_dep_id_fkey");
            });

            // Userss
            modelBuilder.Entity<Userss>(entity =>
            {
                entity.ToTable("Userss");

                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("fullName");
                entity.Property(e => e.Passwordhash).HasMaxLength(255);
            });

            modelBuilder.HasSequence("payments_payment_id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
