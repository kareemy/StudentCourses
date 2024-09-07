using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourses.Models;

namespace StudentCourses.Pages_Students
{
    public class DetailsModel : PageModel
    {
        private readonly StudentCourses.Models.AppDbContext _context;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(ILogger<DetailsModel> logger, StudentCourses.Models.AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public Student Student { get; set; } = default!;
        
        [BindProperty]
        [Display(Name = "Add Course")]
        [Required(ErrorMessage = "Invalid Course")]
        public int CourseIDToAdd {get; set;}
        public SelectList CoursesDropDown {get; set;} = default!;

        [BindProperty]
        public int CourseIDToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.Include(s => s.StudentCourses!).ThenInclude(sc => sc.Course).FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }

            CoursesDropDown = new SelectList(_context.Courses.ToList(), "CourseID", "Description");
            return Page();
        }

        public IActionResult OnPostAddCourse(int? id)
        {
            _logger.LogWarning($"Add Course: StudentId {id}, ADD course {CourseIDToAdd}");

            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Include(s => s.StudentCourses!).ThenInclude(sc => sc.Course).FirstOrDefault(m => m.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            CoursesDropDown = new SelectList(_context.Courses.ToList(), "CourseID", "Description");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Model State is INVALID");
                return Page();
            }

            if (!_context.StudentCourses.Any(sc => sc.CourseID == CourseIDToAdd && sc.StudentID == id))
            {
                StudentCourse courseToAdd = new StudentCourse {StudentID = id.Value, CourseID = CourseIDToAdd};
                _context.Add(courseToAdd);
                _context.SaveChanges();
            } else {
                _logger.LogWarning("Student already enrolled in the course");
            }

            return Page();
        }

        public IActionResult OnPostDropCourse(int? id)
        {
            _logger.LogWarning($"Drop Course: StudentId {id}, DROP course {CourseIDToDelete}");

            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students.Include(s => s.StudentCourses!).ThenInclude(sc => sc.Course).FirstOrDefault(m => m.StudentID == id);

            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            CoursesDropDown = new SelectList(_context.Courses.ToList(), "CourseID", "Description");

            var courseToDrop = _context.StudentCourses.Find(CourseIDToDelete, id);

            if (courseToDrop != null)
            {
                _context.Remove(courseToDrop);
                _context.SaveChanges();
            }
            else 
            {
                _logger.LogWarning("Student NOT enrolled in course");
            }

            // Use RedirectToPage instead of Page to reload the same page
            // But RedirectToPage resets the ModelState so no errors are present
            // Otherwise, our other form to add a course would show an invalid course error
            return RedirectToPage(new {id = id});
        }
    }
}
