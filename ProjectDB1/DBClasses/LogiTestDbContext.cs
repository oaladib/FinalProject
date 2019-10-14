using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDB1.DBClasses
{
    class LogiTestDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)

           => options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=final_project;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Teacher>().HasBaseType<Person>();
            modelBuilder.Entity<Student>().HasBaseType<Person>();

            //Auto increment for primary key
            modelBuilder.Entity<Assignment>()
            .Property(f => f.AssignmentId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Department>()
            .Property(f => f.DepartmentId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Group>()
            .Property(f => f.GroupId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Person>()
            .Property(f => f.PersonId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Submission>()
            .Property(f => f.SubmissionId)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
            .Property(f => f.UserId)
            .ValueGeneratedOnAdd();

            //for foregin key



            modelBuilder.Entity<Group>()
            .HasOne(p => p.Teacher)
            .WithMany(b => b.Groups)
            .HasForeignKey(p => p.TeacherId)
            .HasConstraintName("ForeignKey_Group_Teacher")
            .IsRequired();

            modelBuilder.Entity<Person>()
               .HasOne(p => p.PersonUser)
               .WithMany(b => b.Persons)
               .HasForeignKey(p => p.UserId)
            .HasConstraintName("ForeignKey_Person_User")
               .IsRequired();



            modelBuilder.Entity<Student>()
            .HasOne(p => p.Department)
            .WithMany(b => b.Students)
            .HasForeignKey(p => p.DepartmentId)
            .HasConstraintName("ForeignKey_Student_Department")
            .IsRequired();

            modelBuilder.Entity<Student>()
            .HasOne(p => p.Group)
            .WithMany(b => b.Students)
            .HasForeignKey(p => p.GroupId)
            .HasConstraintName("ForeignKey_Student_Group");

            modelBuilder.Entity<Assignment>()
            .HasOne(p => p.Group)
            .WithMany(b => b.Assignments)
            .HasForeignKey(p => p.GroupId)
            .HasConstraintName("ForeignKey_Assignment_Group")
            .IsRequired();

            modelBuilder.Entity<Submission>()
            .HasOne(p => p.Assignment)
            .WithMany(b => b.Submissions)
            .HasForeignKey(p => p.AssId)
            .HasConstraintName("ForeignKey_Submission_Assignment")
            .IsRequired();

            modelBuilder.Entity<Submission>()
            .HasOne(p => p.Student)
            .WithMany(b => b.Submissions)
            .HasForeignKey(p => p.StudentId)
            .HasConstraintName("ForeignKey_Submission_Student")
            .IsRequired();

            /////////////////////

            // delete cascade Restrict

            modelBuilder.Entity<Group>()
            .HasOne(p => p.Teacher)
            .WithMany(b => b.Groups)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>()
               .HasOne(p => p.PersonUser)
               .WithMany(b => b.Persons)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
            .HasOne(p => p.Department)
            .WithMany(b => b.Students)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
            .HasOne(p => p.Group)
            .WithMany(b => b.Students)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Assignment>()
            .HasOne(p => p.Group)
            .WithMany(b => b.Assignments)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Submission>()
            .HasOne(p => p.Assignment)
            .WithMany(b => b.Submissions)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Submission>()
            .HasOne(p => p.Student)
            .WithMany(b => b.Submissions)
            .OnDelete(DeleteBehavior.Restrict);

            //Unique

            modelBuilder.Entity<Student>()
           .HasIndex(b => b.UnNum)
           .IsUnique();

            modelBuilder.Entity<Person>()
           .HasIndex(b => b.Email)
           .IsUnique();

            modelBuilder.Entity<Person>()
           .HasIndex(b => b.Mobile)
           .IsUnique();

            modelBuilder.Entity<Department>()
           .HasIndex(b => b.DeptName)
           .IsUnique();

            modelBuilder.Entity<Person>()
           .HasIndex(b => b.UserId)
           .IsUnique();

            modelBuilder.Entity<User>()
           .HasIndex(b => b.UserName)
           .IsUnique();




            //defult

            modelBuilder.Entity<Assignment>()
            .Property(b => b.PublishDate)
            .HasDefaultValueSql("getdate()");


            //notes

            //Computed column
            //modelBuilder.Entity<Person>()
            //.Property(p => p.DisplayName)
            //.HasComputedColumnSql("[FirstName] + ', ' + [SurName]");

            //modelBuilder.Entity<Student>()
            //.HasAlternateKey(c => c.UnNum)
            //.HasName("AlternateKey_UniversityNumber");

            //modelBuilder.Entity<Teacher>()
            //   .HasOne(p => p.TeaUser)
            //   .WithMany(b => b.Teachers)
            //   .IsRequired();

            //modelBuilder.Entity<Student>()
            //.HasOne(p => p.StuUser)
            //.WithMany(b => b.Students)
            //.IsRequired();

        }


    }
}
