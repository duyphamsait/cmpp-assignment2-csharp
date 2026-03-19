using cmpp_assignment2_csharp.Models;

namespace cmpp_assignment2_csharp.Data
{
    public static class MockDataLoader
    {
        public static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                new Student(1001, "John", "Smith", "Male", "Software Development", 2, 5, new DateTime(2001, 5, 10), 3.45),
                new Student(1002, "Anna", "Tran", "Female", "Information Technology", 3, 4, new DateTime(2000, 11, 22), 3.90),
                new Student(1003, "David", "Nguyen", "Male", "Computer Science", 1, 6, new DateTime(2002, 3, 14), 3.20)
            };
        }
    }
}