using System.ComponentModel.DataAnnotations;

namespace lab13.DTOs
{
    public class GradeDto
    {
        public int IdGrade { get; set; }

        [Required, StringLength(45)]
        public string Name { get; set; } = string.Empty;

        [StringLength(45)]
        public string? Description { get; set; }
    }
}