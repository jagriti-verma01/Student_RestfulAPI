using interviewpractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace interviewpractice.Services
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentModel>> StudentList();

        public Task<StudentModel> FindStudent(int id);
        public Task<StudentModel> FindStudentByCourse(string course);
        public Task<StudentModel> AddStudentService(StudentModel student);
    }
}
