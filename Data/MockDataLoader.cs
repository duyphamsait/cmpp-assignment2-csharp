using cmpp_assignment2_csharp.Models;

namespace cmpp_assignment2_csharp.Data
{
    public static class MockDataLoader
    {
        public static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                new Student
                {
                    StudentId = 1001,
                    FirstName = "John",
                    LastName = "Smith",
                    Gender = "Male",
                    ProgramName = "Software Development",
                    CurrentSemester = 2,
                    NoOfCourses = 5,
                    Dob = "2001-05-10",
                    Gpa = 3.45
                },

                new Student
                {
                    StudentId = 1002,
                    FirstName = "Anna",
                    LastName = "Tran",
                    Gender = "Female",
                    ProgramName = "Information Technology",
                    CurrentSemester = 3,
                    NoOfCourses = 4,
                    Dob = "2000-11-22",
                    Gpa = 3.90
                },

                new Student
                {
                    StudentId = 1003,
                    FirstName = "David",
                    LastName = "Nguyen",
                    Gender = "Male",
                    ProgramName = "Computer Science",
                    CurrentSemester = 1,
                    NoOfCourses = 6,
                    Dob = "2002-03-14",
                    Gpa = 3.20
                }
            };
        }
    }
}