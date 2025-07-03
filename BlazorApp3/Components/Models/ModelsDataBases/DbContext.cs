using Microsoft.EntityFrameworkCore;
using BlazorApp3.Models;

namespace BlazorApp3.Components.Models.ModelsDataBases
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<TestModel> Tests { get; set; }
        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связь: Вопрос принадлежит тесту
            modelBuilder.Entity<QuestionModel>()
                .HasOne(q => q.Test)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь: Результат ссылается на тест
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Test)
                .WithMany()
                .HasForeignKey(tr => tr.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь: Результат ссылается на студента
            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Student)
                .WithMany(s => s.TestResults)
                .HasForeignKey(tr => tr.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Уникальный индекс на пару TestId + StudentId (если нельзя проходить один тест дважды)
            modelBuilder.Entity<TestResult>()
                .HasIndex(tr => new { tr.TestId, tr.StudentId });
        }
    }
}