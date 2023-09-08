using Microsoft.EntityFrameworkCore;
using OES.Core.Models;

namespace OES.EF
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //**************************************
            modelBuilder.Entity<Course_Department>().HasKey(c => new {c.CourseId,c.DepartmentId });
            modelBuilder.Entity<Course_Department>()
                .HasOne(cd => cd.courses).WithMany(c => c.course_departments).HasForeignKey(cd=>cd.CourseId);
            modelBuilder.Entity<Course_Department>()
                .HasOne(cd => cd.departments).WithMany(c => c.course_departments).HasForeignKey(cd => cd.DepartmentId);
            //**************************************
            modelBuilder.Entity<Lecturer_Room>().HasKey(c => new { c.RoomId, c.LecturerId });
            modelBuilder.Entity<Lecturer_Room>()
                .HasOne(l=>l.lecturer).WithMany(lr=>lr.lecturers_rooms).HasForeignKey(l=>l.LecturerId);
            modelBuilder.Entity<Lecturer_Room>()
               .HasOne(l => l.room).WithMany(lr => lr.lecturers_rooms).HasForeignKey(l => l.RoomId);
            //**************************************
            modelBuilder.Entity<Lecturer>()
                .HasOne(c => c.course).WithMany(l => l.lecturers).HasForeignKey(c=>c.CourseId);
            //**************************************
            modelBuilder.Entity<C_Exam>()
                .HasOne(c => c.course).WithMany(ce => ce.c_Exams).HasForeignKey(c => c.CourseId);
            modelBuilder.Entity<C_Exam>()
              .HasOne(c => c.lecturer).WithMany(ce => ce.c_Exams).HasForeignKey(c => c.LecturerId);
            //**************************************
            modelBuilder.Entity<S_Exam>()
                .HasOne(s => s.c_exam).WithMany(c => c.s_exams).HasForeignKey(s => s.C_ExamId);
            modelBuilder.Entity<S_Exam>()
                .HasOne(s => s.student).WithMany(c => c.s_exams).HasForeignKey(s => s.StudentId);
            //**************************************
            modelBuilder.Entity<Question>()
                .HasOne(l => l.lecturer).WithMany(q => q.questions).HasForeignKey(l => l.LecturerId);
            modelBuilder.Entity<Question>()
               .HasOne(c=>c.course).WithMany(q => q.questions).HasForeignKey(c=>c.CourseId);
            //**************************************
            modelBuilder.Entity<Student>()
                .HasOne(r => r.room).WithMany(s => s.students).HasForeignKey(r => r.RoomId);
            //**************************************
            modelBuilder.Entity<Room>()
                .HasOne(d => d.department).WithMany(r => r.rooms).HasForeignKey(d => d.DepartmentId);

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course_Department> Courses_Departments { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Lecturer_Room> Lecturers_Rooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<C_Exam> C_Exams { get; set; }
        public DbSet<S_Exam> S_Exams { get; set; }
        public DbSet<Student> Students { get; set; }
        
    }
}
