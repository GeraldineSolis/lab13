using lab13.Data;
using lab13.DTOs;
using lab13.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab13.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly Lab13Context _context;

        public CoursesController(Lab13Context context)
        {
            _context = context;
        }

        private static CourseDto ToDto(Course course)
        {
            return new CourseDto
            {
                IdCourse = course.IdCourse,
                Name = course.Name,
                Credit = course.Credit
            };
        }

        // GET api/courses
        [HttpGet]
        public ActionResult<List<CourseDto>> GetAll()
        {
            var list = _context.Courses
                .Where(c => c.Status)
                .ToList()
                .Select(ToDto)
                .ToList();
            return Ok(list);
        }

        // GET api/courses/1
        [HttpGet("{id}")]
        public ActionResult<CourseDto> GetById(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.IdCourse == id && c.Status);
            if (course == null) return NotFound();
            return Ok(ToDto(course));
        }

        // POST api/courses
        [HttpPost]
        public ActionResult<CourseDto> Create(CourseDto dto)
        {
            var course = new Course
            {
                Name = dto.Name,
                Credit = dto.Credit,
                Status = true
            };
            _context.Courses.Add(course);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = course.IdCourse }, ToDto(course));
        }

        // PUT api/courses/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, CourseDto dto)
        {
            var course = _context.Courses.FirstOrDefault(c => c.IdCourse == id && c.Status);
            if (course == null) return NotFound();

            course.Name = dto.Name;
            course.Credit = dto.Credit;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/courses/1  (eliminación lógica)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.IdCourse == id && c.Status);
            if (course == null) return NotFound();

            course.Status = false;
            _context.SaveChanges();
            return NoContent();
        }
    }
}