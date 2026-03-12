using cmpp_assignment2_csharp.Data;
using cmpp_assignment2_csharp.Helpers;
using cmpp_assignment2_csharp.Models;
using cmpp_assignment2_csharp.Views;

namespace cmpp_assignment2_csharp.Controllers
{
    // Controller responsible for handling user actions and application flow
    public class EnrollmentController
    {
        // Stores the list of students
        private List<Student> studentList = new();
        // Keeps track of the next student ID
        private int nextStudentId = 1001;

        public EnrollmentController()
        {
            studentList = MockDataLoader.LoadStudents();

            // Find next available student ID
            if (studentList.Count > 0)
                nextStudentId = studentList.Max(s => s.StudentId) + 1;
        }

        // Main application loop
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
                        ConsoleView.ShowMessage("User Selected 'Exit'...");
                        running = false;
                        break;

                    default:
                        ConsoleView.ShowMessage("Please pick from one of the listed options.");
                        break;
                }
            }

            ConsoleView.ShowMessage("Program Closed Successfully.");
        }

        // Adds a new student to the list        
        private void AddStudent()
        {
            ConsoleView.ShowMessage("\nEnter student information\n");

            string firstName = InputHelper.ReadString("First name: ");
            string lastName = InputHelper.ReadString("Last name: ");
            string dob = InputHelper.ReadString("Date of birth: ");
            string gender = InputHelper.ReadString("Gender: ");
            double gpa = InputHelper.ReadDouble("GPA (0.0 - 4.0): ", 0.0, 4.0);
            int semester = InputHelper.ReadInt("Current semester: ", 1);
            string program = InputHelper.ReadString("Program name: ");
            int courses = InputHelper.ReadInt("Number of courses: ", 0);

            // Create new student object
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

            // Add student to list
            studentList.Add(student);
            nextStudentId++;

            ConsoleView.ShowMessage("Student added successfully.\n");
        }

        // Removes a student by ID
        private void RemoveStudent()
        {
            // Check if list is empty
            if (studentList.Count == 0)
            {
                ConsoleView.ShowMessage("No students to remove.\n");
                return;
            }

            int id = InputHelper.ReadInt("Enter student ID to remove: ");

            // Find student by ID - (FirstOrDefault C# Clourse)
            Student? student = studentList.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                studentList.Remove(student);
                ConsoleView.ShowMessage("Student removed successfully.\n");
            }
            else
            {
                ConsoleView.ShowMessage("Student ID not found.\n");
            }
        }

        // Modify a student record
        private void ModifyStudent()
        {
            if (studentList.Count == 0)
            {
                ConsoleView.ShowMessage("No students available.\n");
                return;
            }

            int id = InputHelper.ReadInt("Enter student ID to modify: ");

            // Find the student
            Student? student = studentList.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                ConsoleView.ShowMessage("Student not found.\n");
                return;
            }

            bool editing = true;

            // Loop until user finishes editing
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
                        ConsoleView.ShowMessage("Modification completed.\n");
                        break;
                    default:
                        ConsoleView.ShowMessage("Invalid choice.");
                        break;
                }
            }
        }

        // Displays all student records
        private void ViewRecords()
        {
            ConsoleView.DisplayStudents(studentList);
        }
    }
}