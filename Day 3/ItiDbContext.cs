using Lab3.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab3
{
    public sealed class ItiDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<InstructorCourse> InstructorCourses { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=ITI_Lab3;User=sa;Password=abcd1234$;TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TopicId);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Description)
                    .HasMaxLength(100);

                entity.Property(e => e.Location)
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId);
            });

            modelBuilder.Entity<InstructorCourse>(entity =>
            {
                entity.HasKey(e => new { e.InstructorId, e.CourseId });

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.InsCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.InstructorCourses)
                    .HasForeignKey(d => d.InstructorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Degree)
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.StudentId });

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudCourses)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Address)
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50);


                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.StudentSuper)
                    .WithMany(p => p.LeadingStudents)
                    .HasForeignKey(d => d.StudentSuperId);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
