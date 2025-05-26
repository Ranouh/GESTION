using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using GESTION.Dto.Student;
using GESTION.Services;

namespace GESTION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(CreateStudentRequestDto dto)
        {
            var createdStudent = await _studentService.CreateStudentAsync(dto);
            return CreatedAtAction(nameof(GetStudent), new { id = createdStudent.IdStudent }, createdStudent);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> UpdateStudent(int id, CreateStudentRequestDto dto)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(id, dto);
            if (updatedStudent == null)
                return NotFound();

            return Ok(updatedStudent);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
