using Microsoft.EntityFrameworkCore;
using BlazorApp3.Models;
using BlazorApp3.Components.Models.ModelsDataBases;

namespace BlazorApp3.Models
{
    public class TestAccessService
    {
        private readonly DataBaseContext _dbContext;

        public TestAccessService(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CanStudentTakeTest(int studentId, int testId)
        {
            return await _dbContext.StudentTests
                .AnyAsync(st => st.StudentId == studentId && st.TestId == testId);
        }

        public async Task GrantAccess(int studentId, int testId)
        {
            if (!await CanStudentTakeTest(studentId, testId))
            {
                _dbContext.StudentTests.Add(new StudentTest
                {
                    StudentId = studentId,
                    TestId = testId
                });
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task RevokeAccess(int studentId, int testId)
        {
            var access = await _dbContext.StudentTests
                .FirstOrDefaultAsync(st => st.StudentId == studentId && st.TestId == testId);
            
            if (access != null)
            {
                _dbContext.StudentTests.Remove(access);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}