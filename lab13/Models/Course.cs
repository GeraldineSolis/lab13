using System.ComponentModel.DataAnnotations;

namespace lab13.Models
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }

        [Required, StringLength(45)]
        public string Name { get; set; } = string.Empty;

        public int Credit { get; set; }

        // Eliminación lógica
        public bool Status { get; set; } = true;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}