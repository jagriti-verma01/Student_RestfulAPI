using interviewpractice.Context;
using interviewpractice.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interviewpractice.Services
{
    public class StudentService : IStudentService
    {
        public readonly AppDbContext _appDbContext;
        public StudentService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<StudentModel>> StudentList()
        {
            var student =  await _appDbContext.StudentModel.ToListAsync();
            return student;
        }

        public async Task<StudentModel> FindStudent(int id)
        {
            var getStudent = await _appDbContext.StudentModel.FindAsync(id);
            if (getStudent == null)
            {
                return null;
            }
            
            return getStudent;
        }
        public async Task<StudentModel> AddStudentService(StudentModel student)

        {
            await _appDbContext.StudentModel.AddAsync(student); // Add student to the DbSet
            await _appDbContext.SaveChangesAsync(); // Save changes to the database
            return student;
        }
    }
}
