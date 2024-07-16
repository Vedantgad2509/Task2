using System.ComponentModel.DataAnnotations;

namespace task_2.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DName { get; set; }
    }
}
