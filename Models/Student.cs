using System.ComponentModel.DataAnnotations;

namespace StudentCourses.Models;

public class Student
{
    public int StudentID {get; set;} // Primary Key

    [Display(Name = "First Name")]
    public string FirstName {get; set;} = string.Empty;
    
    [Display(Name = "Last Name")]
    public string LastName {get; set;} = string.Empty;

    // This property is optional (?) because Students can exist without being in a course. Courses can exist without students.
    [Display(Name = "Enrolled Courses")]
    public List<StudentCourse>? StudentCourses {get; set;} = default!; // Navigation property. A student can be enrolled in many courses
}