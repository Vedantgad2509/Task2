using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2.Data;
using task_2.Models;

namespace task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Departments : ControllerBase
    {
        private ApplicationDbContext _db;

        public Departments(ApplicationDbContext context)
        {
            _db = context;
        }
        [HttpGet]

        public List<Department>GetAllDepartments() 

        {
            return _db.Departments.ToList();

        }
    }
}
