using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2.Data;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class instructor : ControllerBase
    {
        private ApplicationDbContext _db;
        public instructor(ApplicationDbContext context)
        {
            _db = context;

        }
        [HttpGet]
        public List<Instructors> GetAllInstructors()
        {
            return _db.Instructors.ToList();
        }

        [HttpPost]
        public ActionResult<Instructors> AddInstructor([FromBody] Instructors instructordetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Instructors.Add(instructordetails);
            _db.SaveChanges();
            return Ok(instructordetails);
        }
        [HttpPut]
        public ActionResult<Student> UpdateStudent(Int32 id, [FromBody] Instructors instructordetails)
        {
            if (instructordetails == null)
            {
                return BadRequest(ModelState);
            }
            var InstructorDetails = _db.Instructors.FirstOrDefault(x => x.InstructorsID == id);
            if (InstructorDetails == null)
            {
                return NotFound();
            }

           
            InstructorDetails.LName = instructordetails.FName;
            InstructorDetails.FName = instructordetails.LName;
            InstructorDetails.Status = instructordetails.Status;
            InstructorDetails.HireDate = instructordetails.HireDate;
            InstructorDetails.Salary = instructordetails.Salary;
            InstructorDetails.DepartmentID = instructordetails.DepartmentID;

            _db.SaveChanges();
            return Ok(InstructorDetails);
        }

        [HttpDelete]
        public ActionResult DeleteInstructor(Int32 id)
        {
            var InstructorDetails = _db.Instructors.FirstOrDefault(x => x.InstructorsID == id);
            if (InstructorDetails == null)
            {
                return NotFound();
            }
            _db.Remove(InstructorDetails);
            _db.SaveChanges();
            return NoContent();

        }


    }
}
