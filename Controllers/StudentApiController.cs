using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.DBFOLDER;
using workshop.Models;

namespace workshop.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
        {
        private readonly STUDENTDB db;

        public StudentApiController(STUDENTDB context)
            {
            db = context;
            }

        // GET: api/StudentApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents()
            {
            return await db.students.ToListAsync();
            }

        // GET: api/StudentApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
            {
            var student = await db.students.FindAsync(id);

            if (student == null)
                return NotFound();

            return student;
            }

        // POST: api/StudentApi
        [HttpPost]
        public async Task<ActionResult<StudentModel>> CreateStudent(StudentModel student)
            {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.students.Add(student);
            await db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent), new { id = student.student_id }, student);
            }

        // PUT: api/StudentApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentModel student)
            {
            if (id != student.student_id)
                return BadRequest();

            db.Entry(student).State = EntityState.Modified;

            try
                {
                await db.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!db.students.Any(e => e.student_id == id))
                    return NotFound();
                else
                    throw;
                }

            return NoContent(); // 204 success
            }

        // DELETE: api/StudentApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
            {
            var student = await db.students.FindAsync(id);

            if (student == null)
                return NotFound();

            db.students.Remove(student);
            await db.SaveChangesAsync();

            return NoContent();
            }
        }
    }