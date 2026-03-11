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

//         public string Display(int recordNumber)
//         {
//             return $@"
// Record #{recordNumber}
// Student ID       : {StudentId}
// First Name       : {FirstName}
// Last Name        : {LastName}
// Date of Birth    : {Dob}
// Gender           : {Gender}
// GPA              : {Gpa:F2}
// Current Semester : {CurrentSemester}
// Program          : {ProgramName}
// Number of Courses: {NoOfCourses}";
//         }

        public static string TableHeader()
        {
            return
                Pad("No", (int)ColumnLength.No) +
                Pad("ID", (int)ColumnLength.ID) +
                Pad("FirstName", (int)ColumnLength.FirstName) +
                Pad("LastName", (int)ColumnLength.LastName) +
                Pad("DOB", (int)ColumnLength.DOB) +
                Pad("Gender", (int)ColumnLength.Gender) +
                Pad("GPA", (int)ColumnLength.GPA) +
                Pad("Program", (int)ColumnLength.Program) +
                "Courses";
        }

        public string TableRow(int recordNumber)
        {
            return
                Pad(recordNumber.ToString(), (int)ColumnLength.No) +
                Pad(StudentId.ToString(), (int)ColumnLength.ID) +
                Pad(FirstName, (int)ColumnLength.FirstName) +
                Pad(LastName, (int)ColumnLength.LastName) +
                Pad(Dob, (int)ColumnLength.DOB) +
                Pad(Gender, (int)ColumnLength.Gender) +
                Pad(Gpa.ToString("F2"), (int)ColumnLength.GPA) +
                Pad(ProgramName, (int)ColumnLength.Program) +
                NoOfCourses.ToString();
        }

        private static string Pad(string text, int width)
        {
            return text.PadRight(width);
        }
    }
}