namespace cmpp_assignment2_csharp.Models
{
    enum ColumnLength : int
    {
        No = 8,
        ID = 8,
        FirstName = 15,
        LastName = 15,
        DOB = 14,
        Gender = 10,
        GPA = 8,
        Program = 25,
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Gender { get; set; } = "";
        public string ProgramName { get; set; } = "";
        public int CurrentSemester { get; set; }
        public int NoOfCourses { get; set; }
        public string Dob { get; set; } = "";
        public double Gpa { get; set; }
    }
}