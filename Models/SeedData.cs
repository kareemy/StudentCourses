using Microsoft.EntityFrameworkCore;

namespace StudentCourses.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Students.Any())
        {
            return;
        }

        // Add Students, Courses, and StudentCourses below
        List<Student> students = new List<Student>
        {
            new Student { FirstName = "John", LastName = "Doe" },
            new Student { FirstName = "Jane", LastName = "Smith" },
            new Student { FirstName = "Michael", LastName = "Johnson" },
            new Student { FirstName = "Emily", LastName = "Davis" },
            new Student { FirstName = "Daniel", LastName = "Garcia" },
            new Student { FirstName = "Sophia", LastName = "Martinez" },
            new Student { FirstName = "William", LastName = "Rodriguez" },
            new Student { FirstName = "Olivia", LastName = "Wilson" },
            new Student { FirstName = "James", LastName = "Anderson" },
            new Student { FirstName = "Isabella", LastName = "Thomas" },
            new Student { FirstName = "Alexander", LastName = "Lee" },
            new Student { FirstName = "Mia", LastName = "Perez" },
            new Student { FirstName = "Benjamin", LastName = "Taylor" },
            new Student { FirstName = "Charlotte", LastName = "Moore" },
            new Student { FirstName = "Ethan", LastName = "Jackson" },
            new Student { FirstName = "Amelia", LastName = "Martin" },
            new Student { FirstName = "Logan", LastName = "Harris" },
            new Student { FirstName = "Ava", LastName = "Clark" },
            new Student { FirstName = "Mason", LastName = "Lewis" },
            new Student { FirstName = "Harper", LastName = "Walker" },
            new Student { FirstName = "Elijah", LastName = "Hall" },
            new Student { FirstName = "Ella", LastName = "Allen" },
            new Student { FirstName = "Liam", LastName = "Young" },
            new Student { FirstName = "Grace", LastName = "King" },
            new Student { FirstName = "Noah", LastName = "Scott" },
            new Student { FirstName = "Aiden", LastName = "Green" },
            new Student { FirstName = "Abigail", LastName = "Adams" },
            new Student { FirstName = "Lucas", LastName = "Baker" },
            new Student { FirstName = "Emily", LastName = "Carter" },
            new Student { FirstName = "Oliver", LastName = "Nelson" },
            new Student { FirstName = "Hannah", LastName = "Hill" },
            new Student { FirstName = "Jacob", LastName = "Ramirez" },
            new Student { FirstName = "Victoria", LastName = "Mitchell" },
            new Student { FirstName = "Matthew", LastName = "Roberts" },
            new Student { FirstName = "Chloe", LastName = "Phillips" },
            new Student { FirstName = "Henry", LastName = "Campbell" },
            new Student { FirstName = "Zoe", LastName = "Parker" },
            new Student { FirstName = "Samuel", LastName = "Evans" },
            new Student { FirstName = "Lily", LastName = "Edwards" },
            new Student { FirstName = "David", LastName = "Collins" },
            new Student { FirstName = "Avery", LastName = "Stewart" },
            new Student { FirstName = "Joseph", LastName = "Sanchez" },
            new Student { FirstName = "Samantha", LastName = "Morris" },
            new Student { FirstName = "Gabriel", LastName = "Rogers" },
            new Student { FirstName = "Sofia", LastName = "Reed" },
            new Student { FirstName = "Jackson", LastName = "Cook" },
            new Student { FirstName = "Mila", LastName = "Morgan" },
            new Student { FirstName = "Sebastian", LastName = "Bell" },
            new Student { FirstName = "Layla", LastName = "Murphy" },
            new Student { FirstName = "Emma", LastName = "Patterson" }
        };
        context.AddRange(students);
        context.SaveChanges();

        List<Course> courses = new List<Course>
        {
            new Course { Description = "CIDM 2315" },
            new Course { Description = "CIDM 3312" },
            new Course { Description = "CIDM 3350" },
            new Course { Description = "CIDM 4385" },
            new Course { Description = "CIDM 4390" }
        };
        context.AddRange(courses);
        context.SaveChanges();

        List<StudentCourse> studentCourses = new List<StudentCourse>
        {
            // Student 1 assigned to 3 courses
            new StudentCourse { StudentID = 1, CourseID = 1 },
            new StudentCourse { StudentID = 1, CourseID = 2 },
            new StudentCourse { StudentID = 1, CourseID = 3 },

            // Student 2 assigned to 2 courses
            new StudentCourse { StudentID = 2, CourseID = 1 },
            new StudentCourse { StudentID = 2, CourseID = 4 },

            // Student 3 assigned to 1 course
            new StudentCourse { StudentID = 3, CourseID = 5 },

            // Student 4 assigned to 2 courses
            new StudentCourse { StudentID = 4, CourseID = 2 },
            new StudentCourse { StudentID = 4, CourseID = 3 },

            // Student 5 assigned to 1 course
            new StudentCourse { StudentID = 5, CourseID = 1 },

            // Student 6 assigned to 3 courses
            new StudentCourse { StudentID = 6, CourseID = 2 },
            new StudentCourse { StudentID = 6, CourseID = 4 },
            new StudentCourse { StudentID = 6, CourseID = 5 },

            // Student 7 assigned to 1 course
            new StudentCourse { StudentID = 7, CourseID = 3 },

            // Student 8 assigned to 2 courses
            new StudentCourse { StudentID = 8, CourseID = 1 },
            new StudentCourse { StudentID = 8, CourseID = 5 },

            // Student 9 assigned to 3 courses
            new StudentCourse { StudentID = 9, CourseID = 2 },
            new StudentCourse { StudentID = 9, CourseID = 3 },
            new StudentCourse { StudentID = 9, CourseID = 4 },

            // Student 10 assigned to 1 course
            new StudentCourse { StudentID = 10, CourseID = 5 },

            // Student 11 assigned to 2 courses
            new StudentCourse { StudentID = 11, CourseID = 2 },
            new StudentCourse { StudentID = 11, CourseID = 4 },

            // Student 12 assigned to 3 courses
            new StudentCourse { StudentID = 12, CourseID = 1 },
            new StudentCourse { StudentID = 12, CourseID = 3 },
            new StudentCourse { StudentID = 12, CourseID = 5 },

            // Student 13 assigned to 2 courses
            new StudentCourse { StudentID = 13, CourseID = 4 },
            new StudentCourse { StudentID = 13, CourseID = 5 },

            // Student 14 assigned to 1 course
            new StudentCourse { StudentID = 14, CourseID = 1 },

            // Student 15 assigned to 2 courses
            new StudentCourse { StudentID = 15, CourseID = 2 },
            new StudentCourse { StudentID = 15, CourseID = 5 },

            // Student 16 assigned to 2 courses
            new StudentCourse { StudentID = 16, CourseID = 3 },
            new StudentCourse { StudentID = 16, CourseID = 4 },

            // Student 17 assigned to 1 course
            new StudentCourse { StudentID = 17, CourseID = 1 },

            // Student 18 assigned to 2 courses
            new StudentCourse { StudentID = 18, CourseID = 3 },
            new StudentCourse { StudentID = 18, CourseID = 5 },

            // Student 19 assigned to 1 course
            new StudentCourse { StudentID = 19, CourseID = 2 },

            // Student 20 assigned to 3 courses
            new StudentCourse { StudentID = 20, CourseID = 1 },
            new StudentCourse { StudentID = 20, CourseID = 4 },
            new StudentCourse { StudentID = 20, CourseID = 5 },

            // Student 21 assigned to 2 courses
            new StudentCourse { StudentID = 21, CourseID = 3 },
            new StudentCourse { StudentID = 21, CourseID = 4 },

            // Student 22 assigned to 1 course
            new StudentCourse { StudentID = 22, CourseID = 2 },

            // Student 23 assigned to 3 courses
            new StudentCourse { StudentID = 23, CourseID = 1 },
            new StudentCourse { StudentID = 23, CourseID = 3 },
            new StudentCourse { StudentID = 23, CourseID = 5 },

            // Student 24 assigned to 2 courses
            new StudentCourse { StudentID = 24, CourseID = 2 },
            new StudentCourse { StudentID = 24, CourseID = 4 },

            // Student 25 assigned to 1 course
            new StudentCourse { StudentID = 25, CourseID = 3 },

            // Student 26 assigned to 2 courses
            new StudentCourse { StudentID = 26, CourseID = 1 },
            new StudentCourse { StudentID = 26, CourseID = 5 },

            // Student 27 assigned to 3 courses
            new StudentCourse { StudentID = 27, CourseID = 2 },
            new StudentCourse { StudentID = 27, CourseID = 3 },
            new StudentCourse { StudentID = 27, CourseID = 4 },

            // Student 28 assigned to 1 course
            new StudentCourse { StudentID = 28, CourseID = 5 },

            // Student 29 assigned to 3 courses
            new StudentCourse { StudentID = 29, CourseID = 1 },
            new StudentCourse { StudentID = 29, CourseID = 2 },
            new StudentCourse { StudentID = 29, CourseID = 4 },

            // Student 30 assigned to 2 courses
            new StudentCourse { StudentID = 30, CourseID = 3 },
            new StudentCourse { StudentID = 30, CourseID = 5 },

            // Student 31 assigned to 1 course
            new StudentCourse { StudentID = 31, CourseID = 4 },

            // Student 32 assigned to 2 courses
            new StudentCourse { StudentID = 32, CourseID = 2 },
            new StudentCourse { StudentID = 32, CourseID = 3 },

            // Student 33 assigned to 3 courses
            new StudentCourse { StudentID = 33, CourseID = 1 },
            new StudentCourse { StudentID = 33, CourseID = 4 },
            new StudentCourse { StudentID = 33, CourseID = 5 },

            // Student 34 assigned to 1 course
            new StudentCourse { StudentID = 34, CourseID = 3 },

            // Student 35 assigned to 2 courses
            new StudentCourse { StudentID = 35, CourseID = 1 },
            new StudentCourse { StudentID = 35, CourseID = 5 },

            // Student 36 assigned to 1 course
            new StudentCourse { StudentID = 36, CourseID = 2 },

            // Student 37 assigned to 3 courses
            new StudentCourse { StudentID = 37, CourseID = 3 },
            new StudentCourse { StudentID = 37, CourseID = 4 },
            new StudentCourse { StudentID = 37, CourseID = 5 },

            // Student 38 assigned to 1 course
            new StudentCourse { StudentID = 38, CourseID = 1 },

            // Student 39 assigned to 2 courses
            new StudentCourse { StudentID = 39, CourseID = 2 },
            new StudentCourse { StudentID = 39, CourseID = 3 },

            // Student 40 assigned to 1 course
            new StudentCourse { StudentID = 40, CourseID = 4 },

            // Student 41 assigned to 2 courses
            new StudentCourse { StudentID = 41, CourseID = 1 },
            new StudentCourse { StudentID = 41, CourseID = 5 },

            // Student 42 assigned to 3 courses
            new StudentCourse { StudentID = 42, CourseID = 2 },
            new StudentCourse { StudentID = 42, CourseID = 3 },
            new StudentCourse { StudentID = 42, CourseID = 4 },

            // Student 43 assigned to 1 course
            new StudentCourse { StudentID = 43, CourseID = 5 },

            // Student 44 assigned to 2 courses
            new StudentCourse { StudentID = 44, CourseID = 1 },
            new StudentCourse { StudentID = 44, CourseID = 4 },

            // Student 45 assigned to 1 course
            new StudentCourse { StudentID = 45, CourseID = 3 },

            // Student 46 assigned to 3 courses
            new StudentCourse { StudentID = 46, CourseID = 2 },
            new StudentCourse { StudentID = 46, CourseID = 3 },
            new StudentCourse { StudentID = 46, CourseID = 5 },

            // Student 47 assigned to 1 course
            new StudentCourse { StudentID = 47, CourseID = 4 },

            // Student 48 assigned to 2 courses
            new StudentCourse { StudentID = 48, CourseID = 1 },
            new StudentCourse { StudentID = 48, CourseID = 5 },

            // Student 49 assigned to 3 courses
            new StudentCourse { StudentID = 49, CourseID = 2 },
            new StudentCourse { StudentID = 49, CourseID = 3 },
            new StudentCourse { StudentID = 49, CourseID = 4 },

            // Student 50 assigned to 1 course
            new StudentCourse { StudentID = 50, CourseID = 5 }
        };
        context.AddRange(studentCourses);
        context.SaveChanges();
    }
}