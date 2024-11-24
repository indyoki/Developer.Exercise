using StudentAPI.Models;

namespace StudentAPI.Services.Interfaces
{
    public interface IStudentManager
    {
        Task<List<Student>> GetStudents();
        Task<bool> AddStudent(Student newStudent);
        Task<bool> DeleteStudent(string studentNumber);
    }
}
