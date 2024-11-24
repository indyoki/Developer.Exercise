using StudentAPI.Models;

namespace StudentAPI.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<bool> AddStudent(Student student);
        Task<bool> DeleteStudent(string studentNumber);
    }
}
