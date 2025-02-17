using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearningManagmentSystem.Core.Data;

public partial class LmsdemoDbContext : DbContext
{
    public LmsdemoDbContext()
    {
    }

    public LmsdemoDbContext(DbContextOptions<LmsdemoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Stdcourse> Stdcourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-78KRV6N\\SQLEXPRESS;Database=LMSDemoDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("PK__CATEGORY__A50F9896441BD77F");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.Categoryid)
                .ValueGeneratedNever()
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CATEGORYNAME");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Courseid).HasName("PK__COURSE__CC214B4F2E67CDD9");

            entity.ToTable("COURSE");

            entity.Property(e => e.Courseid)
                .ValueGeneratedNever()
                .HasColumnName("COURSEID");
            entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");
            entity.Property(e => e.Coursename)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("COURSENAME");
            entity.Property(e => e.Imagename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("IMAGENAME");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("FK_CATEGORYID");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Loginid).HasName("PK__LOGIN__8CC3F3BB8D792F4A");

            entity.ToTable("LOGIN");

            entity.Property(e => e.Loginid)
                .ValueGeneratedNever()
                .HasColumnName("LOGINID");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roleid).HasColumnName("ROLEID");
            entity.Property(e => e.Studentid).HasColumnName("STUDENTID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Role).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("FK_ROLEID");

            entity.HasOne(d => d.Student).WithMany(p => p.Logins)
                .HasForeignKey(d => d.Studentid)
                .HasConstraintName("FK_STUDENTID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("PK__ROLE__006568E99B673375");

            entity.ToTable("ROLE");

            entity.Property(e => e.Roleid)
                .ValueGeneratedNever()
                .HasColumnName("ROLEID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Stdcourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STDCOURS__3214EC27164D73C4");

            entity.ToTable("STDCOURSE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Courseid).HasColumnName("COURSEID");
            entity.Property(e => e.Dateofregister).HasColumnName("DATEOFREGISTER");
            entity.Property(e => e.Markofstd).HasColumnName("MARKOFSTD");
            entity.Property(e => e.Studid).HasColumnName("STUDID");

            entity.HasOne(d => d.Course).WithMany(p => p.Stdcourses)
                .HasForeignKey(d => d.Courseid)
                .HasConstraintName("FK_STDCOURSE");

            entity.HasOne(d => d.Stud).WithMany(p => p.Stdcourses)
                .HasForeignKey(d => d.Studid)
                .HasConstraintName("FK_STDID");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Studentid).HasName("PK__STUDENT__495196F0BFBBD3E3");

            entity.ToTable("STUDENT");

            entity.Property(e => e.Studentid)
                .ValueGeneratedNever()
                .HasColumnName("STUDENTID");
            entity.Property(e => e.Dateofbirth).HasColumnName("DATEOFBIRTH");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRSTNAME");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LASTNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
