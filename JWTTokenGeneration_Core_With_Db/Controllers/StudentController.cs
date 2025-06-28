using JWTTokenGeneration_Core_With_Db.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Text;

namespace JWTTokenGeneration_Core_With_Db.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext db;

        public StudentController(StudentDbContext context)
        {
            db = context;
        }

        [Authorize]
        [HttpGet]
        [Route("api/Student")]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var lst = await db.Students.ToListAsync();
            return Ok(lst);
        }

        [HttpPost]
        [Route("api/Student")]
        public async Task<string> AddStudents(Student st)
        {
           await db.Students.AddAsync(st);
            await db.SaveChangesAsync();
            return "Student Added Successfully";
        }

        [HttpGet]
        [Route("api/Student/{id}")]
        public Student GetStudent(int id)
        {
            return db.Students.FirstOrDefault(x => x.Id == id);

        }

        [HttpPut]
        [Route("api/Student")]
        public string UpdateStudent(Student st)
        {
            db.Entry<Student>(st).State= EntityState.Modified;
            db.SaveChanges();
            return "Student Updated Successfully";
        }

        [HttpDelete]
        [Route("api/Student")]
        public string DeleteStudent(int id)
        {
            var std = db.Students.FirstOrDefault(x => x.Id == id);
            db.Students.Remove(std);
            db.SaveChanges();
            return "Student Deleted Successfully";
        }
    }
}
