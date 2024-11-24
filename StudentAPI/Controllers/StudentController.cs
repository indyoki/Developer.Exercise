using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentAPI.Models;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        //Get Students
        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            try
            {
                return await _studentManager.GetStudents();
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while attempting to retreive students data, exception: {ex}", ex);
                throw;
            }
        }
        //Add Student
        [HttpPost("AddStudent")]
        public async Task<ActionResult<string>> Post([FromBody] Student newStudent)
        {
            try
            {
                var result = await _studentManager.AddStudent(newStudent);
                if (!result)
                    return $"Student with Student number '{newStudent.StudentNumber}' already exists.";

                return Ok($"Student added successfully, student number '{newStudent.StudentNumber}'");

            }
            catch (Exception ex)
            {
                Log.Error("An error occured while attempting to retreive students data, exception: {ex}", ex);
                throw;
            }
        }

        //Remove Student
        [HttpDelete("Delete/{studentNumber}")]
        public async Task<ActionResult<string>> Delete(string studentNumber)
        {
            try
            {
                var results = await _studentManager.DeleteStudent(studentNumber);
                
                if(results == true)
                    return Ok($"Student with student number: '{studentNumber}' has been removed.");

                return NotFound($"Student with student number '{studentNumber}' does not exist.");
            }
            catch (Exception ex)
            {
                Log.Error("An error occured while attempting to retreive students data, exception: {ex}", ex);
                throw;
            }
        }
    }
}
