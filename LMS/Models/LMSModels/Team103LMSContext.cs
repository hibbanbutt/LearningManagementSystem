using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LMS.Models.LMSModels
{
    public partial class Team103LMSContext : DbContext
    {
        public Team103LMSContext()
        {
        }

        public Team103LMSContext(DbContextOptions<Team103LMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrators> Administrators { get; set; }
        public virtual DbSet<AssignmentCategories> AssignmentCategories { get; set; }
        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Enrolled> Enrolled { get; set; }
        public virtual DbSet<Professors> Professors { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Submissions> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=atr.eng.utah.edu;User Id=u1053351;Password=M@8150172;Database=Team103LMS");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LName)
                    .HasColumnName("lName")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<AssignmentCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ClassId)
                    .HasName("classID");

                entity.HasIndex(e => new { e.Name, e.ClassId })
                    .HasName("real_Key")
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.AssignmentCategories)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("AssignmentCategories_ibfk_1");
            });

            modelBuilder.Entity<Assignments>(entity =>
            {
                entity.HasKey(e => e.AssignId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("categoryID");

                entity.HasIndex(e => new { e.Name, e.CategoryId })
                    .HasName("real_key_assign")
                    .IsUnique();

                entity.Property(e => e.AssignId)
                    .HasColumnName("assignID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("categoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contents)
                    .HasColumnName("contents")
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Due)
                    .HasColumnName("due")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("Assignments_ibfk_1");
            });

            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CourseId)
                    .HasName("courseID");

                entity.HasIndex(e => e.Teacher)
                    .HasName("teacher");

                entity.HasIndex(e => new { e.SemesterYear, e.SemesterSeason, e.CourseId })
                    .HasName("key_class")
                    .IsUnique();

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("endTime")
                    .HasColumnType("time");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SemesterSeason)
                    .HasColumnName("semesterSeason")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.SemesterYear)
                    .HasColumnName("semesterYear")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("time");

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasColumnName("teacher")
                    .HasColumnType("varchar(8)");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("Classes_ibfk_2");

                entity.HasOne(d => d.TeacherNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.Teacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Classes_ibfk_1");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Subject)
                    .HasName("subject");

                entity.HasIndex(e => new { e.Number, e.Subject })
                    .HasName("real_key")
                    .IsUnique();

                entity.Property(e => e.CourseId)
                    .HasColumnName("courseID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasColumnName("subject")
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.SubjectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Subject)
                    .HasConstraintName("Courses_ibfk_1");
            });

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.Subject)
                    .HasName("PRIMARY");

                entity.Property(e => e.Subject)
                    .HasColumnName("subject")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");
            });

            modelBuilder.Entity<Enrolled>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.UId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UId)
                    .HasName("Enrolled_ibfk_3");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Grade)
                    .HasColumnName("grade")
                    .HasColumnType("varchar(2)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Enrolled)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("Enrolled_ibfk_2");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Enrolled)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrolled_ibfk_3");
            });

            modelBuilder.Entity<Professors>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.WorksIn)
                    .HasName("worksIn");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LName)
                    .HasColumnName("lName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.WorksIn)
                    .IsRequired()
                    .HasColumnName("worksIn")
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.WorksInNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.WorksIn)
                    .HasConstraintName("Professors_ibfk_1");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.Major)
                    .HasName("major");

                entity.Property(e => e.UId)
                    .HasColumnName("uID")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FName)
                    .HasColumnName("fName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LName)
                    .HasColumnName("lName")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Major)
                    .IsRequired()
                    .HasColumnName("major")
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.MajorNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Major)
                    .HasConstraintName("Students_ibfk_1");
            });

            modelBuilder.Entity<Submissions>(entity =>
            {
                entity.HasKey(e => e.SubmitId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UId)
                    .HasName("uID");

                entity.HasIndex(e => new { e.AssignId, e.UId })
                    .HasName("real_uniqueness_key")
                    .IsUnique();

                entity.Property(e => e.SubmitId)
                    .HasColumnName("submitID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AssignId)
                    .HasColumnName("assignID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Contents)
                    .HasColumnName("contents")
                    .HasColumnType("varchar(8192)");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SubmitTime)
                    .HasColumnName("submitTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UId)
                    .IsRequired()
                    .HasColumnName("uID")
                    .HasColumnType("varchar(8)");

                entity.HasOne(d => d.Assign)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.AssignId)
                    .HasConstraintName("Submissions_ibfk_1");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("Submissions_ibfk_2");
            });
        }
    }
}
