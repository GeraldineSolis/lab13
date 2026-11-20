using System.ComponentModel.DataAnnotations;

namespace lab13.DTOs
{
    public class CourseDto
    {
        public int IdCourse { get; set; }

        [Required, StringLength(45)]
        public string Name { get; set; } = string.Empty;

        public int Credit { get; set; }
    }
}