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
                        ConsoleView.Pause();
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
            string gender = InputHelper.ReadString("Gender: ");
            string program = InputHelper.ReadString("Program name: ");
            int semester = InputHelper.ReadInt("Current semester: ", 1);
            int courses = InputHelper.ReadInt("Number of courses: ", 0);
            DateTime dob = InputHelper.ReadDate("Date of birth (YYYY-MM-DD): ");
            double gpa = InputHelper.ReadDouble("GPA (0.0 - 4.0): ", 0.0, 4.0);

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

            // Verify student added
            if (studentList.Any(s => s.StudentId == student.StudentId))
            {
                ConsoleView.ShowMessage($"{student.FirstName} {student.LastName} added to Student List\n");
                nextStudentId++;
            }
            else
            {
                ConsoleView.ShowMessage("Student not added – Try Again\n");
            }

            ConsoleView.Pause();
        }

        // Removes a student by ID
        private void RemoveStudent()
        {
            // Check if list is empty
            if (studentList.Count == 0)
            {
                ConsoleView.ShowMessage("No students to remove.\n");
                ConsoleView.Pause();
                return;
            }

            int id = InputHelper.ReadInt("Enter student ID to remove: ");

            // Find student by ID
            Student? student = studentList.FirstOrDefault(s => s.StudentId == id);

            if (student != null)
            {
                studentList.Remove(student);
                ConsoleView.ShowMessage("Student Removed from List\n");
            }
            else
            {
                ConsoleView.ShowMessage("Student Not Found\n");
            }

            ConsoleView.Pause();
        }

        // Modify a student record
        private void ModifyStudent()
        {
            if (studentList.Count == 0)
            {
                ConsoleView.ShowMessage("No students available.\n");
                ConsoleView.Pause();
                return;
            }

            ConsoleView.ShowMessage("Enter Student ID to modify:");
            int id = InputHelper.ReadInt("Student ID: ");

            // Find the student
            Student? student = studentList.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                ConsoleView.ShowMessage("Student Not Found\n");
                ConsoleView.Pause();
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
                        ConsoleView.ShowMessage("Selected: First Name (String)");
                        student.FirstName = InputHelper.ReadString("Type new value: ");
                        break;

                    case 2:
                        ConsoleView.ShowMessage("Selected: Last Name (String)");
                        student.LastName = InputHelper.ReadString("Type new value: ");
                        break;

                    case 3:
                        ConsoleView.ShowMessage("Selected: Gender (String)");
                        student.Gender = InputHelper.ReadString("Type new value: ");
                        break;

                    case 4:
                        ConsoleView.ShowMessage("Selected: Program Name (String)");
                        student.ProgramName = InputHelper.ReadString("Type new value: ");
                        break;

                    case 5:
                        ConsoleView.ShowMessage("Selected: Current Semester (Integer)");
                        student.CurrentSemester = InputHelper.ReadInt("Type new value: ", 1);
                        break;

                    case 6:
                        ConsoleView.ShowMessage("Selected: Number of Courses (Integer)");
                        student.NoOfCourses = InputHelper.ReadInt("Type new value: ", 0);
                        break;

                    case 7:
                        ConsoleView.ShowMessage("Selected: Date of Birth (YYYY-MM-DD)");
                        student.Dob = InputHelper.ReadDate("Type new value: ");
                        break;

                    case 8:
                        ConsoleView.ShowMessage("Selected: GPA (Double)");
                        student.Gpa = InputHelper.ReadDouble("Type new value: ", 0.0, 4.0);
                        break;

                    // case 9:
                    //     ConsoleView.ShowMessage("Selected: Student ID (Integer)");
                    //     student.StudentId = InputHelper.ReadInt("Type new value: ", 1);
                    //     break;

                    case 0:
                        editing = false;
                        ConsoleView.ShowMessage("Modification completed.\n");
                        break;

                    default:
                        ConsoleView.ShowMessage("Invalid choice.");
                        break;
                }
            }

            ConsoleView.Pause();
        }

        // Displays all student records
        private void ViewRecords()
        {
            ConsoleView.DisplayStudents(studentList);
            ConsoleView.Pause();
        }
    }
}