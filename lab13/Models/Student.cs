using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab13.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }

        // FK hacia Grade
        public int IdGrade { get; set; }

        [Required, StringLength(45)]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(45)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(45)]
        public string? Phone { get; set; }

        [StringLength(45)]
        public string? Email { get; set; }

        [ForeignKey("IdGrade")]
        public Grade? Grade { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}