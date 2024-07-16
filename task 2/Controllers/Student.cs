using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2.Data;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Students : ControllerBase
    {
        private ApplicationDbContext _db;

        public Students(ApplicationDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public List<Student> Getallstudents()
        {
            return _db.Students.ToList();
        }
        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody] Student studentdetails)
        {
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _db.Students.Add(studentdetails);
                _db.SaveChanges();
                return Ok(studentdetails);

            }
        }

        [HttpPut]
        public ActionResult<Student> UpdateStudent(Int32 id, [FromBody] Student studentdetails)
        {
            if (studentdetails == null)
            {
                return BadRequest(ModelState);
            }
            var StudentDetails = _db.Students.FirstOrDefault(x => x.StudentID == id);
            if (StudentDetails == null)
            {
                return NotFound();
            }
            
            StudentDetails.StudentNum = studentdetails.StudentNum;
            StudentDetails.FName = studentdetails.FName;
            StudentDetails.LName = studentdetails.LName;
            StudentDetails.EnrolDate = studentdetails.EnrolDate;
            StudentDetails.GradDate = studentdetails.GradDate;

            _db.SaveChanges();
            return Ok(StudentDetails);
        }

        [HttpDelete]
        public ActionResult DeleteStudent(Int32 id)
        {
            var StudentDetails = _db.Students.FirstOrDefault(x => x.StudentID == id);
            if (StudentDetails == null)
            {
                return NotFound();
            }
            _db.Remove(StudentDetails);
            _db.SaveChanges();
            return NoContent();

        }

    }
}
