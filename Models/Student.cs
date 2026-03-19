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
        public DateTime Dob { get; set; }
        public double Gpa { get; set; }

        // Construction
        public Student(
            int studentId,
            string firstName,
            string lastName,
            string gender,
            string programName,
            int currentSemester,
            int noOfCourses,
            DateTime dob,
            double gpa)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            ProgramName = programName;
            CurrentSemester = currentSemester;
            NoOfCourses = noOfCourses;
            Dob = dob;
            Gpa = gpa;
        }

        public Student()
        {
            FirstName = "";
            LastName = "";
            Gender = "";
            ProgramName = "";
        }

    }
}