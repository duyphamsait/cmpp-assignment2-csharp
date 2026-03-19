using cmpp_assignment2_csharp.Models;

namespace cmpp_assignment2_csharp.Views
{
    // Handles all console output
    public static class ConsoleView
    {
        // Displays the application header
        public static void DisplayHeader()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("       Enrollment Management System");
            Console.WriteLine("=========================================");
        }

        // Displays the main menu
        public static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("-------- Main Menu --------");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Modify Student");
            Console.WriteLine("4. View Records");
            Console.WriteLine("0. Exit");
            Console.WriteLine("---------------------------");
        }

        // Displays the main menu
        public static void DisplayModifyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---- Modify Student ----");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Gender");
            Console.WriteLine("4. Program Name");
            Console.WriteLine("5. Current Semester");
            Console.WriteLine("6. Number of Courses");
            Console.WriteLine("7. Date of Birth");
            Console.WriteLine("8. GPA");
            Console.WriteLine("9. Student ID");
            Console.WriteLine("0. Done");
        }
        // Displays a single message
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Displays all student records in table format
        public static void DisplayStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo student records.\n");
                return;
            }

            Console.WriteLine("\n================ Student Records ================\n");
            Console.WriteLine(BuildTableHeader());
            Console.WriteLine(new string('-', 115));

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(BuildStudentRow(students[i], i + 1));
            }

            Console.WriteLine();
        }

        // Builds the table header
        private static string BuildTableHeader()
        {
            return
                Pad("No", (int)ColumnWidth.No) +
                Pad("ID", (int)ColumnWidth.Id) +
                Pad("FirstName", (int)ColumnWidth.FirstName) +
                Pad("LastName", (int)ColumnWidth.LastName) +
                Pad("DOB", (int)ColumnWidth.Dob) +
                Pad("Gender", (int)ColumnWidth.Gender) +
                Pad("GPA", (int)ColumnWidth.Gpa) +
                Pad("Program", (int)ColumnWidth.Program) +
                Pad("Courses", (int)ColumnWidth.Courses);
        }

        // Builds one student row
        private static string BuildStudentRow(Student student, int recordNumber)
        {
            return
                Pad(recordNumber.ToString(), (int)ColumnWidth.No) +
                Pad(student.StudentId.ToString(), (int)ColumnWidth.Id) +
                Pad(student.FirstName, (int)ColumnWidth.FirstName) +
                Pad(student.LastName, (int)ColumnWidth.LastName) +
                Pad(student.Dob.ToString("yyyy-MM-dd"), (int)ColumnWidth.Dob) +
                Pad(student.Gender, (int)ColumnWidth.Gender) +
                Pad(student.Gpa.ToString("F2"), (int)ColumnWidth.Gpa) +
                Pad(student.ProgramName, (int)ColumnWidth.Program) +
                Pad(student.NoOfCourses.ToString(), (int)ColumnWidth.Courses);
        }

        // Pads text for table alignment
        private static string Pad(string text, int width)
        {
            return text.PadRight(width);
        }

        // Puase wait until press any key to return to main menu
        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to return to main menu...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}