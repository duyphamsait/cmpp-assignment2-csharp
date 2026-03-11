using cmpp_assignment2_csharp.Models;

namespace cmpp_assignment2_csharp.Views
{
    public static class ConsoleView
    {
        public static void DisplayHeader()
        {
            Console.WriteLine("=========================================");
            Console.WriteLine("       Enrollment Management System");
            Console.WriteLine("=========================================");
        }

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

        public static void DisplayModifyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---- Modify Student ----");
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Date of Birth");
            Console.WriteLine("4. Gender");
            Console.WriteLine("5. GPA");
            Console.WriteLine("6. Semester");
            Console.WriteLine("7. Program");
            Console.WriteLine("8. Number of Courses");
            Console.WriteLine("0. Done");
        }

        public static void DisplayStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("\nNo student records.\n");
                return;
            }

            Console.WriteLine("\n================ Student Records ================\n");

            Console.WriteLine(Student.TableHeader());
            Console.WriteLine(new string('-', 110));

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].TableRow(i + 1));
            }

            Console.WriteLine();
        }
    }
}