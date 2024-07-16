using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_2.Models
{
    public class Courses
    {
        [Key]
        public int CoursesID { get; set; }
        public string? CName { get; set; }
        public string? CDescription { get; set; }
        public int CoursesUnit { get;
            set; }

        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }

        [ForeignKey("InstructorID")]
        public int InstructorID { get; set; }




    }
}
