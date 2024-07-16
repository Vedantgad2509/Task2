using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace task_2.Models
{
    public class Instructors
    {
        [Key]
        public int InstructorsID { get; set; }
        public string? LName { get; set; }
        public string? FName { get; set; }
        public string? Status { get; set; }
        public string? HireDate { get; set; }
        public int Salary { get; set; }

        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }

    }
}
