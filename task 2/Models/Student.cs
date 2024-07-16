using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace task_2.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required]

        public int StudentNum { get; set; }
        [Required]
        public string? FName { get; set; }
        [Required]
        public string? LName { get; set; }
        [Required]
        public string? EnrolDate { get; set; }
        [Required]

        public string? GradDate { get; set; }
        



    }
    
}
