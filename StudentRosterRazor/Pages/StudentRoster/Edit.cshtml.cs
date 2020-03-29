using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentRosterRazor.Model;

namespace StudentRosterRazor.Pages.StudentRoster
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Student Student { get; set; }
        
        public async Task OnGet(int ID)
        {
            Student = await _db.Student.FindAsync(ID);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var StudentFromDb = await _db.Student.FindAsync(Student.ID);
                StudentFromDb.StudentID = Student.StudentID;
                StudentFromDb.FirstName = Student.FirstName;
                StudentFromDb.MiddleName = Student.MiddleName;
                StudentFromDb.LastName = Student.LastName;
                StudentFromDb.Grade = Student.Grade;
                StudentFromDb.Gender = Student.Gender;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}