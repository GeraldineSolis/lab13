using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab13.Models
{
    public class Enrollment
    {
        [Key]
        public int IdEnrollment { get; set; }

        // FK hacia Student
        public int IdStudent { get; set; }

        // FK hacia Course
        public int IdCourse { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("IdStudent")]
        public Student? Student { get; set; }

        [ForeignKey("IdCourse")]
        public Course? Course { get; set; }
    }
}