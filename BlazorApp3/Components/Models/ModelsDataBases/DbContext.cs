using BlazorApp3.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp3.Components.Models.ModelsDataBases
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<TestModel> Tests { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<StudentTest> StudentTests { get; set; }
        public async Task<List<string>> GetAllSubjects()
        {
            return await Tests
                .Select(t => t.Subject)
                .Distinct()
                .ToListAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.SubjectsString)
                .HasColumnName("subjects")
                .HasDefaultValue("[]");

            modelBuilder.Entity<Admin>()
                .Property(a => a.IsSuperAdmin)
                .HasDefaultValue(false);

            // Настройка связей
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Student)
                .WithMany(s => s.TestResults)
                .HasForeignKey(tr => tr.StudentId);

            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Test)
                .WithMany()
                .HasForeignKey(tr => tr.TestId);
        }
    }
}