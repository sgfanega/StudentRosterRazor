using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRosterRazor.Model;

namespace StudentRosterRazor.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Student.ToList() } );
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int ID)
        {
            var studentFromDb = await _db.Student.FirstOrDefaultAsync(b => b.ID == ID);
            if (studentFromDb == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error While Deleting"
                });
            }
            _db.Student.Remove(studentFromDb);
            await _db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Delete Completed"
            });
        }
    }
}