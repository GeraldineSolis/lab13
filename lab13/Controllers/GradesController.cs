using lab13.Data;
using lab13.DTOs;
using lab13.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        private readonly Lab13Context _context;

        public GradesController(Lab13Context context)
        {
            _context = context;
        }

        private static GradeDto ToDto(Grade grade)
        {
            return new GradeDto
            {
                IdGrade = grade.IdGrade,
                Name = grade.Name,
                Description = grade.Description
            };
        }

        // GET api/grades
        [HttpGet]
        public ActionResult<List<GradeDto>> GetAll()
        {
            var list = _context.Grades
                .Where(g => g.Status)
                .ToList()
                .Select(ToDto)
                .ToList();
            return Ok(list);
        }

        // GET api/grades/1
        [HttpGet("{id}")]
        public ActionResult<GradeDto> GetById(int id)
        {
            var grade = _context.Grades.FirstOrDefault(g => g.IdGrade == id && g.Status);
            if (grade == null) return NotFound();
            return Ok(ToDto(grade));
        }

        // POST api/grades
        [HttpPost]
        public ActionResult<GradeDto> Create(GradeDto dto)
        {
            var grade = new Grade
            {
                Name = dto.Name,
                Description = dto.Description,
                Status = true
            };
            _context.Grades.Add(grade);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = grade.IdGrade }, ToDto(grade));
        }

        // PUT api/grades/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, GradeDto dto)
        {
            var grade = _context.Grades.FirstOrDefault(g => g.IdGrade == id && g.Status);
            if (grade == null) return NotFound();

            grade.Name = dto.Name;
            grade.Description = dto.Description;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/grades/1  (eliminación lógica)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var grade = _context.Grades.FirstOrDefault(g => g.IdGrade == id && g.Status);
            if (grade == null) return NotFound();

            grade.Status = false;
            _context.SaveChanges();
            return NoContent();
        }
    }
}