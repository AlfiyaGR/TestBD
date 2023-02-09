using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestBD.Data;
using TestBD.Models;

namespace TestBD.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly TestBD.Data.SchoolContext _context;

        public CreateModel(TestBD.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                _context.Student.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }


        //todo: 1. Add genre type. 2. Add lazy load. 3. Return type MovieDto (Id, Title, GenreName, Price, Date)
        // https://learn.microsoft.com/ru-ru/aspnet/core/tutorials/razor-pages/sql?view=aspnetcore-7.0&tabs=visual-studio - работа с базой данных
    }
}
