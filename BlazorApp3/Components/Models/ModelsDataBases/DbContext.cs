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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionModel>()
                .HasOne(q => q.Test)
                .WithMany(t => t.QuestionModels)
                .HasForeignKey(q => q.TestModelId);

            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Test)
                .WithMany()
                .HasForeignKey(tr => tr.TestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Student)
                .WithMany(s => s.TestResults)
                .HasForeignKey(tr => tr.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Добавляем индекс для быстрого поиска дубликатов
            modelBuilder.Entity<TestResult>()
                .HasIndex(tr => new { tr.TestId, tr.StudentId });
        }
    }
}