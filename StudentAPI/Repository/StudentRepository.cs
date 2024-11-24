using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StudentAPI.Models;
using StudentAPI.Repository.Interfaces;

namespace StudentAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementDBContext _dbContext;
        public StudentRepository(StudentManagementDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<bool> AddStudent(Student newStudent)
        {
            try
            {
                var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentNumber == newStudent.StudentNumber);
                if (student != null)
                    return false;

                await _dbContext.Students.AddAsync(newStudent);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (SqlException ex)
            {
                Log.Error("An error occured: {ex}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteStudent(string studentNumber)
        {
            try
            {
                var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.StudentNumber == studentNumber);
                if (student == null)
                    return false;

                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (SqlException ex)
            {
                Log.Error("An error occured: {ex}", ex);
                throw;
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await _dbContext.Students.ToListAsync();
            }
            catch (SqlException ex)
            {
                Log.Error("An error occured: {ex}", ex);
                throw;
            }
        }
    }
}
