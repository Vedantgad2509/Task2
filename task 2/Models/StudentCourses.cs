using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_2.Models
{
    public class StudentCourses
    {
        [Key]
        public int StudentCoursesID { get; set; }
        [Required]

        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
    }
}
