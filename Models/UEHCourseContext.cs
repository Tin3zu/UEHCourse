using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UEHCourse.Models
{
    public partial class UEHCourseContext : DbContext
    {
        public UEHCourseContext()
        {
        }

        public UEHCourseContext(DbContextOptions<UEHCourseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminModel> AdminModels { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Field> Fields { get; set; } = null!;
        public virtual DbSet<ImageName> ImageNames { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4M435OF\\SQLEXPRESS;Initial Catalog=UEHCourse;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminModel>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AdminID");

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.CourseName).HasMaxLength(255);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.Discount).HasMaxLength(50);

                entity.Property(e => e.EndDay).HasColumnType("date");

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.StartDay).HasColumnType("date");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

                entity.HasOne(d => d.CourseNavigation)
                    .WithOne(p => p.Course)
                    .HasForeignKey<Course>(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_ImageName");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.FieldId)
                    .HasConstraintName("FK_Courses_Fields");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Courses_Suppliers");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasMaxLength(50)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Avatar).HasMaxLength(200);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.CcreateDate)
                    .HasColumnType("date")
                    .HasColumnName("CCreateDate");

                entity.Property(e => e.Cemail)
                    .HasMaxLength(100)
                    .HasColumnName("CEmail");

                entity.Property(e => e.Clogin)
                    .HasMaxLength(50)
                    .HasColumnName("CLogin");

                entity.Property(e => e.Cname)
                    .HasMaxLength(100)
                    .HasColumnName("CName");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Cpassword)
                    .HasMaxLength(50)
                    .HasColumnName("CPassword");

                entity.Property(e => e.Cphone)
                    .HasMaxLength(20)
                    .HasColumnName("CPhone");

                entity.Property(e => e.LastLogin).HasColumnType("date");

                entity.Property(e => e.Mssv)
                    .HasMaxLength(50)
                    .HasColumnName("MSSV");

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Customers_Courses");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Customers_Payments");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(e => e.FieldId)
                    .ValueGeneratedNever()
                    .HasColumnName("FieldID");

                entity.Property(e => e.FieldName).HasMaxLength(100);
            });

            modelBuilder.Entity<ImageName>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("ImageName");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.ImageName1).HasColumnName("ImageName");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .HasColumnName("PaymentID");

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever()
                    .HasColumnName("SupplierID");

                entity.Property(e => e.SupplierName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
