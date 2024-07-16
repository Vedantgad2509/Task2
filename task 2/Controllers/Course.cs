using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2.Data;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Course : ControllerBase
    {
        private ApplicationDbContext _db;
        public Course(ApplicationDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public List<Courses> GetAllCourses()
        {
            return _db.Courses.ToList();
        }
        [HttpPost]
        public ActionResult<Courses> AddCourse([FromBody] Courses course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Courses.Add(course);
            _db.SaveChanges();
            return Ok(course);

        }
        [HttpPut]
        public ActionResult<Courses> UpdateCourse(Int32 id, [FromBody] Courses coursedetails)
        {
            if (coursedetails == null)
            {
                return BadRequest(ModelState);
            }
            var CourseDetails = _db.Courses.FirstOrDefault(x => x.CoursesID == id);
            if (CourseDetails == null)
            {
                return NotFound();
            }

            
            CourseDetails.CName = coursedetails.CName;
            CourseDetails.CDescription = coursedetails.CDescription;
            CourseDetails.CoursesUnit = coursedetails.CoursesUnit;
            CourseDetails.DepartmentID = coursedetails.DepartmentID;
            CourseDetails.InstructorID = coursedetails.InstructorID;

            _db.SaveChanges();
            return Ok(CourseDetails);
        }
        [HttpDelete]
        public ActionResult DeleteCourse(Int32 id, [FromBody] Courses coursedetails)
        {
            if (coursedetails == null)
            {
                return NotFound();
            }
            _db.Remove(coursedetails);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
