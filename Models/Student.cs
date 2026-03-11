namespace cmpp_assignment2_csharp.Models
{
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
                Pad("No", 4) +
                Pad("ID", 8) +
                Pad("FirstName", 15) +
                Pad("LastName", 15) +
                Pad("DOB", 14) +
                Pad("Gender", 10) +
                Pad("GPA", 8) +
                Pad("Program", 25) +
                "Courses";
        }

        public string TableRow(int recordNumber)
        {
            return
                Pad(recordNumber.ToString(), 4) +
                Pad(StudentId.ToString(), 8) +
                Pad(FirstName, 15) +
                Pad(LastName, 15) +
                Pad(Dob, 14) +
                Pad(Gender, 10) +
                Pad(Gpa.ToString("F2"), 8) +
                Pad(ProgramName, 25) +
                NoOfCourses.ToString();
        }

        private static string Pad(string text, int width)
        {
            return text.PadRight(width);
        }
    }
}