using FluentValidation;
using interviewpractice.Context;
using interviewpractice.Models;
using Microsoft.EntityFrameworkCore;

namespace interviewpractice.Services
{
    public class StudentService : IStudentService
    {
        public readonly AppDbContext _appDbContext;
        private readonly IValidator<StudentModel> _validator;
        public StudentService(AppDbContext appDbContext, IValidator<StudentModel> validator)
        {
            _appDbContext = appDbContext;
            _validator = validator;
        }

        public async Task<IEnumerable<StudentModel>> StudentList()
        {
            var student = await _appDbContext.StudentModel.ToListAsync();
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

        public async Task<StudentModel> FindStudentByCourse(string course)
        {
            var student = await _appDbContext.StudentModel
                .Where(s => s.course == course)
                .FirstOrDefaultAsync();
            if (student == null)
            {
                return null;
            }
            return student;
        }
        public async Task<StudentModel> AddStudentService(StudentModel student)

        {
            var validationResult = await _validator.ValidateAsync(student);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            await _appDbContext.StudentModel.AddAsync(student); // Add student to the DbSet
                await _appDbContext.SaveChangesAsync(); // Save changes to the database
                return student;
            }
        }
    }
