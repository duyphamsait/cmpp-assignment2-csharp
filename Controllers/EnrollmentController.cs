using cmpp_assignment2_csharp.Data;
using cmpp_assignment2_csharp.Helpers;
using cmpp_assignment2_csharp.Models;
using cmpp_assignment2_csharp.Views;

namespace cmpp_assignment2_csharp.Controllers
{
    public class EnrollmentController
    {
        private List<Student> studentList = new();
        private int nextStudentId = 1001;

        public EnrollmentController()
        {
            studentList = MockDataLoader.LoadStudents();

            if (studentList.Count > 0)
                nextStudentId = studentList.Max(s => s.StudentId) + 1;
        }

        public void Run()
        {
            ConsoleView.DisplayHeader();

            bool running = true;

            while (running)
            {
                ConsoleView.DisplayMenu();

                int selection = InputHelper.ReadInt("Enter selection: ");

                switch (selection)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        RemoveStudent();
                        break;

                    case 3:
                        ModifyStudent();
                        break;

                    case 4:
                        ViewRecords();
                        break;

                    case 0:
                        Console.WriteLine("User Selected 'Exit'...");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Please pick from one of the listed options.");
                        break;
                }
            }

            Console.WriteLine("Program Closed Successfully.");
        }

        private void AddStudent()
        {
            Console.WriteLine("\nEnter student information\n");

            string firstName = InputHelper.ReadString("First name: ");
            string lastName = InputHelper.ReadString("Last name: ");
            string dob = InputHelper.ReadString("Date of birth: ");
            string gender = InputHelper.ReadString("Gender: ");
            double gpa = InputHelper.ReadDouble("GPA (0.0 - 4.0): ", 0.0, 4.0);
            int semester = InputHelper.ReadInt("Current semester: ", 1);
            string program = InputHelper.ReadString("Program name: ");
            int courses = InputHelper.ReadInt("Number of courses: ", 0);

            Student student = new Student
            {
                StudentId = nextStudentId,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                ProgramName = program,
                CurrentSemester = semester,
                NoOfCourses = courses,
                Dob = dob,
                Gpa = gpa
            };

            studentList.Add(student);
            nextStudentId++;

            Console.WriteLine("Student added successfully.\n");
        }

        private void RemoveStudent()
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("No students to remove.\n");
                return;
            }

            int id = InputHelper.ReadInt("Enter student ID to remove: ");

            Student? student = studentList.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                studentList.Remove(student);
                Console.WriteLine("Student removed successfully.\n");
            }
            else
            {
                Console.WriteLine("Student ID not found.\n");
            }
        }

        private void ModifyStudent()
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("No students available.\n");
                return;
            }

            int id = InputHelper.ReadInt("Enter student ID to modify: ");

            Student? student = studentList.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                Console.WriteLine("Student not found.\n");
                return;
            }

            bool editing = true;

            while (editing)
            {
                ConsoleView.DisplayModifyMenu();

                int choice = InputHelper.ReadInt("Select field: ");

                switch (choice)
                {
                    case 1:
                        student.FirstName = InputHelper.ReadString("New first name: ");
                        break;
                    case 2:
                        student.LastName = InputHelper.ReadString("New last name: ");
                        break;
                    case 3:
                        student.Dob = InputHelper.ReadString("New DOB: ");
                        break;
                    case 4:
                        student.Gender = InputHelper.ReadString("New gender: ");
                        break;
                    case 5:
                        student.Gpa = InputHelper.ReadDouble("New GPA: ", 0.0, 4.0);
                        break;
                    case 6:
                        student.CurrentSemester = InputHelper.ReadInt("New semester: ", 1);
                        break;
                    case 7:
                        student.ProgramName = InputHelper.ReadString("New program: ");
                        break;
                    case 8:
                        student.NoOfCourses = InputHelper.ReadInt("New course count: ", 0);
                        break;
                    case 0:
                        editing = false;
                        Console.WriteLine("Modification completed.\n");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void ViewRecords()
        {
            ConsoleView.DisplayStudents(studentList);
        }
    }
}