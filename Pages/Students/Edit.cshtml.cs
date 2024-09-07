using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourses.Models;

namespace StudentCourses.Pages_Students
{
    public class EditModel : PageModel
    {
        private readonly StudentCourses.Models.AppDbContext _context;

        public EditModel(StudentCourses.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public List<Course> Courses {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student =  await _context.Students.Include(s => s.StudentCourses!).ThenInclude(sc => sc.Course).FirstOrDefaultAsync(m => m.StudentID == id);
            Courses = _context.Courses.ToList();
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedCourses)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var studentToUpdate = await _context.Students.Include(s => s.StudentCourses!).ThenInclude(sc => sc.Course).FirstOrDefaultAsync(m => m.StudentID == Student.StudentID);
            if (studentToUpdate != null)
            {
                studentToUpdate.FirstName = Student.FirstName;
                studentToUpdate.LastName = Student.LastName;
                UpdateStudentCourses(selectedCourses, studentToUpdate);
            }
            //_context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.StudentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }

        private void UpdateStudentCourses(int[] selectedCourses, Student studentToUpdate)
        {
            if (selectedCourses == null)
            {
                studentToUpdate.StudentCourses = new List<StudentCourse>();
                return;
            }

            List<int> currentCourses = studentToUpdate.StudentCourses!.Select(c => c.CourseID).ToList();
            List<int> selectedCoursesList = selectedCourses.ToList();

            foreach (var course in _context.Courses)
            {
                if (selectedCoursesList.Contains(course.CourseID))
                {
                    if (!currentCourses.Contains(course.CourseID))
                    {
                        // Add course here
                        studentToUpdate.StudentCourses!.Add(
                            new StudentCourse { StudentID = studentToUpdate.StudentID, CourseID = course.CourseID }
                        );
                        //_logger.LogWarning($"Student {studentToUpdate.FirstName} {studentToUpdate.LastName} ({studentToUpdate.StudentID}) - ADD {course.CourseID} {course.Description}");
                    }
                }
                else
                {
                    if (currentCourses.Contains(course.CourseID))
                    {
                        // Remove course here
                        StudentCourse courseToRemove = studentToUpdate.StudentCourses!.SingleOrDefault(s => s.CourseID == course.CourseID)!;
                        _context.Remove(courseToRemove);
                        //_logger.LogWarning($"Student {studentToUpdate.FirstName} {studentToUpdate.LastName} ({studentToUpdate.StudentID}) - DROP {course.CourseID} {course.Description}");
                    }
                }
            }
        }
    }
}
