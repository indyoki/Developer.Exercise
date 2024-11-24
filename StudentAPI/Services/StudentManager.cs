using Serilog;
using StudentAPI.Models;
using StudentAPI.Repository.Interfaces;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Services
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepository;
        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> AddStudent(Student newStudent)
        {
            try
            {
                return await _studentRepository.AddStudent(newStudent);
            }
            catch (Exception ex)
            {
                Log.Error("An error occured: {ex}",ex);
                throw;
            }
        }

        public async Task<bool> DeleteStudent(string studentNumber)
        {
            try
            {
                return await _studentRepository.DeleteStudent(studentNumber);
            }
            catch (Exception ex)
            {
                Log.Error("An error occured: {ex}", ex);
                throw;
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await _studentRepository.GetStudents();
            }
            catch (Exception ex)
            {
                Log.Error("An error occured: {ex}", ex);
                throw;
            }
        }
    }
}
