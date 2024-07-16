using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2.Data;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Studentcourses : ControllerBase
    {
        private ApplicationDbContext _db;
        public Studentcourses(ApplicationDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public List<StudentCourses> GetAllStCourses()
        {
            return _db.StudentCourses.ToList();
        }
        [HttpPost]
        public ActionResult<StudentCourses> AddSCourse([FromBody]StudentCourses studentCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.StudentCourses.Add(studentCourses);
            _db.SaveChanges();
            return Ok(studentCourses);
        }
        [HttpPut]
        public ActionResult<StudentCourses> UpdateStCourses(Int32 id, [FromBody] StudentCourses studentcourses)
        {
            if (studentcourses == null)
            {
                return BadRequest(ModelState);
            }
            var StudentCDetails = _db.StudentCourses.FirstOrDefault(x => x.StudentID == id);
            if (StudentCDetails == null)
            {
                return NotFound();
            }

            StudentCDetails.StudentID = studentcourses.StudentID;
            StudentCDetails.CourseID = studentcourses.CourseID;
           

            _db.SaveChanges();
            return Ok(StudentCDetails);
        }

        [HttpDelete]
        public ActionResult DeleteStudentCourse(Int32 id)
        {
            var StudentCDetails = _db.StudentCourses.FirstOrDefault(x => x.StudentID == id);
            if (StudentCDetails == null)
            {
                return NotFound();
            }
            _db.Remove(StudentCDetails);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
