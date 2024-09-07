namespace StudentCourses.Models;

public class Course
{
    public int CourseID {get; set;} // Primary Key
    public string Description {get; set;} = string.Empty;

    // This property is optional (?) because Students can exist without being in a course. Courses can exist without students.
    public List<StudentCourse>? StudentCourses {get; set;} = default!; // Navigation property. A student can be enrolled in many courses
}

public class StudentCourse
{
    public int CourseID {get; set;} // Composite Primary Key, Foreign Key 1
    public int StudentID {get; set;} // Composite Primary Key, Foreign Key 2
    public Student Student {get; set;} = default!; // Navigation Property
    public Course Course {get; set;} = default!; // Navigation Property
}