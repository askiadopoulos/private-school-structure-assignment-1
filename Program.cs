using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        // Main menu options
        public enum MainMenu
        {
            RegisterData = 1,
            PrintData,
            Quit
        }
        // Sub-menu for register data
        public enum RegisterData
        {
            Students = 1,
            Trainers,
            Assignments,
            Courses,
            SyntheticData,
            StudentPerCourse,
            TrainerPerCourse,
            AssignmentPerCourse,
            AssignmentPerStudent,
            SubmitDateForAssignment,
            MainMenu,
            Quit,
        }
        // Sub-menu for print data
        public enum PrintData
        {
            Students = 1,
            Trainers,
            Assignments,
            Courses,
            StudentsPerCourse,
            TrainersPerCourse,
            AssignmentsPerCourse,
            AssignmentsPerStudent,
            MainMenu,
            Quit
        }
        // Dictionaries to hold the Objects instances
        public static Dictionary<short, Student> studentsDictionary = new Dictionary<short, Student>();
        public static Dictionary<short, Trainer> trainersDictionary = new Dictionary<short, Trainer>();
        public static Dictionary<short, Assignment> assignmentsDictionary = new Dictionary<short, Assignment>();
        public static Dictionary<short, Course> coursesDictionary = new Dictionary<short, Course>();
        // Dictionaries to hold the matches
        public static Dictionary<Student, Course> studentsPerCourseDictionary = new Dictionary<Student, Course>();
        public static Dictionary<Trainer, Course> trainersPerCourseDictionary = new Dictionary<Trainer, Course>();
        public static Dictionary<Assignment, Course> assignmentPerCourseDictionary = new Dictionary<Assignment, Course>();
        public static Dictionary<Assignment, Student> assignmentPerStudentDictionary = new Dictionary<Assignment, Student>();
        // List for the submission dates
        public static List<DateTime> datesOfSubmission = new List<DateTime>();

        // Calling Code of the Main Method
        static void Main(string[] args)
        {

            // Declaration - Initialization of boolean variables
            bool allowDataEntry = true; // Data registration more than once
            bool useSyntheticData = false; // Use (or not) Synthetic Data
            bool registerData = false; // Register Data sub-menu options
            bool printData = false; // Print Data sub-menu options

            // Auxiliary dictionaries to store the matches
            Dictionary<Student, Course> newStudentPerCourseDictionary = new Dictionary<Student, Course>();
            Dictionary<Trainer, Course> newTrainerPerCourseDictionary = new Dictionary<Trainer, Course>();
            Dictionary<Assignment, Course> newAssignmentPerCourseDictionary = new Dictionary<Assignment, Course>();
            Dictionary<Assignment, Student> newAssignmentPerStudentDictionary = new Dictionary<Assignment, Student>();

            // Loop that gives user the option to add more than one entry at a time
            do
            {
                // Program Header
                Console.WriteLine("Private School Structure - Main menu.\n");

                // Main menu options
                Console.WriteLine("1. Register Data");
                Console.WriteLine("2. Print Data");
                Console.WriteLine("3. Quit program");
                Console.Write("\nEnter your preference: ");

                // Declaration - Initialization of variables: main and sub-menu user options
                short userChoice = short.Parse(Console.ReadLine());
                short numberToCreateObjects = 0;
                string programQuit = string.Empty;
                bool subMenu = true;

                // Loop for the sub-menu options
                while (subMenu)
                {
                    switch (userChoice)
                    {
                        case (short)MainMenu.RegisterData:
                            Console.Clear();
                            Console.WriteLine("Private School Structure\n");
                            Console.WriteLine(" -- Register Data:");
                            Console.WriteLine(" -----------------");
                            Console.WriteLine(" 1. Students");
                            Console.WriteLine(" 2. Trainers");
                            Console.WriteLine(" 3. Assignments");
                            Console.WriteLine(" 4. Courses");
                            Console.WriteLine(" 5. Use synthetic data");
                            Console.WriteLine("\n -- Match Data:");
                            Console.WriteLine(" -----------------");
                            Console.WriteLine(" 6. Student with a Course");
                            Console.WriteLine(" 7. Trainer with a Course");
                            Console.WriteLine(" 8. Assignment with a Course");
                            Console.WriteLine(" 9. Assignment with a Student");
                            Console.WriteLine("\n -- Submit Date:");
                            Console.WriteLine(" -----------------");
                            Console.WriteLine("10. Submit date for Assignment");
                            Console.WriteLine("\n11. Return to the Main menu");
                            Console.WriteLine("12. Quit");
                            Console.Write("\nEnter your preference: ");
                            userChoice = short.Parse(Console.ReadLine());
                            registerData = true;
                            break;

                        case (short)MainMenu.PrintData:
                            Console.Clear();
                            Console.WriteLine("Private School Structure\n");
                            Console.WriteLine(" -- Print Data:");
                            Console.WriteLine(" -----------------");
                            Console.WriteLine(" 1. Students");
                            Console.WriteLine(" 2. Trainers");
                            Console.WriteLine(" 3. Assignments");
                            Console.WriteLine(" 4. Courses");
                            Console.WriteLine(" 5. Students per Course");
                            Console.WriteLine(" 6. Trainers per Course");
                            Console.WriteLine(" 7. Assignments per Course");
                            Console.WriteLine(" 8. Assignments per Student");
                            Console.WriteLine("\n 9. Return to the Main menu");
                            Console.WriteLine("10. Quit");
                            Console.Write("\nEnter your preference: ");
                            userChoice = short.Parse(Console.ReadLine());
                            printData = true;
                            break;

                        case (short)MainMenu.Quit:
                            subMenu = false; // Exit sub-menu
                            allowDataEntry = false; // Exit main-menu
                            break;

                        default:
                            Console.Write("Wrong selection. Press any key to try again...");
                            Console.ReadKey();
                            Console.Clear();
                            subMenu = false;
                            break;
                    }

                    // Loop for the Register Data sub-menu options
                    while (registerData)
                    {
                        switch (userChoice)
                        {
                            case (short)RegisterData.Students:
                                Console.Write("\nEnter the number of Students you want to create: ");
                                numberToCreateObjects = short.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Input Data for Students");

                                var recentlyCreatedStudents = Student.CreateStudents(numberToCreateObjects);
                                Student.AddRangeDictionary(recentlyCreatedStudents, studentsDictionary);

                                Console.Write("\nData successfully created. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case (short)RegisterData.Trainers:
                                Console.Write("\nEnter the number of Trainers you want to create: ");
                                numberToCreateObjects = short.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Input Data for Trainers");

                                var recentlyCreatedTrainers = Trainer.CreateTrainers(numberToCreateObjects);
                                Trainer.AddRangeDictionary(recentlyCreatedTrainers, trainersDictionary);

                                Console.Write("\nData successfully created. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case (short)RegisterData.Assignments:
                                Console.Write("\nEnter the number of Assignments you want to create: ");
                                numberToCreateObjects = short.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Input Data for Assignments");

                                var recentlyCreatedAssignments = Assignment.CreateAssignments(numberToCreateObjects);
                                Assignment.AddRangeDictionary(recentlyCreatedAssignments, assignmentsDictionary);

                                Console.Write("\nData successfully created. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case (short)RegisterData.Courses:
                                Console.Write("\nEnter the number of Courses you want to create: ");
                                numberToCreateObjects = short.Parse(Console.ReadLine());
                                Console.Clear();
                                Console.WriteLine("Input Data for Courses");

                                var recentlyCreatedCourses = Course.CreateCourses(numberToCreateObjects);
                                Course.AddRangeDictionary(recentlyCreatedCourses, coursesDictionary);

                                Console.Write("\nData successfully created. Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;

                            case (short)RegisterData.SyntheticData:
                                if (!useSyntheticData)
                                {
                                    // Initialization of Synthetic Data
                                    studentsDictionary.Add(1, new Student("Angelos", "Skiadopoulos", new DateTime(1979, 01, 24), 350.85));
                                    studentsDictionary.Add(2, new Student("George", "Anastasiadis", new DateTime(1985, 10, 15), 355));
                                    studentsDictionary.Add(3, new Student("Efi", "Koutsoff", new DateTime(1975, 06, 14), 380.50));
                                    trainersDictionary.Add(1, new Trainer("Periklis", "Aidinopoulos", "C# Funtamentals"));
                                    trainersDictionary.Add(2, new Trainer("Argiris", "Pagidas", "Introduction To Python"));
                                    trainersDictionary.Add(3, new Trainer("Pikos", "Apikos", "Froutopia"));
                                    assignmentsDictionary.Add(1, new Assignment("Coding Bootcamp Assignment 1", "Private School Structure", new DateTime(2019, 03, 15, 18, 30, 01), 35.8, 72.11));
                                    assignmentsDictionary.Add(2, new Assignment("Coding Bootcamp Assignment 2", "On-Line Orders Platform", new DateTime(2019, 05, 20, 19, 10, 01), 66.0, 45.55));
                                    assignmentsDictionary.Add(3, new Assignment("Coding Bootcamp Assignment 3", "Commercial E-Shop", new DateTime(2019, 07, 10, 19, 10, 01), 66.0, 45.55));
                                    coursesDictionary.Add(1, new Course("Full Stack .NET Entry Level Developer", Stream.CSharp, Type.Part, new DateTime(2019, 02, 04), new DateTime(2019, 08, 02)));
                                    coursesDictionary.Add(2, new Course("Full Stack Java Entry Level Developer", Stream.Java, Type.Full, new DateTime(2018, 10, 10), new DateTime(2019, 04, 02)));

                                    useSyntheticData = true; // Avoid running twice

                                    Console.Write("\nSynthetic data successfully created. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Write("\nSynthetic data already created. Press any key to continue...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                break;

                            case (short)RegisterData.StudentPerCourse:
                                Console.Clear();
                                Console.WriteLine("Match Student Per Course");
                                newStudentPerCourseDictionary = StudentPerCourse.MatchStudentPerCourse(studentsDictionary, coursesDictionary);
                                StudentPerCourse.AddRangeDictionary(newStudentPerCourseDictionary, studentsPerCourseDictionary);
                                break;

                            case (short)RegisterData.TrainerPerCourse:
                                Console.Clear();
                                Console.WriteLine("Match Trainer Per Course");
                                newTrainerPerCourseDictionary = TrainerPerCourse.MatchTrainerPerCourse(trainersDictionary, coursesDictionary);
                                TrainerPerCourse.AddRangeDictionary(newTrainerPerCourseDictionary, trainersPerCourseDictionary);
                                break;

                            case (short)RegisterData.AssignmentPerCourse:
                                Console.Clear();
                                Console.WriteLine("Match Assignment Per Course");
                                newAssignmentPerCourseDictionary = AssignmentPerCourse.MatchAssignmentPerCourse(assignmentsDictionary, coursesDictionary);
                                AssignmentPerCourse.AddRangeDictionary(newAssignmentPerCourseDictionary, assignmentPerCourseDictionary);
                                break;

                            case (short)RegisterData.AssignmentPerStudent:
                                Console.Clear();
                                Console.WriteLine("Match Assignment Per Student");
                                newAssignmentPerStudentDictionary = AssignmentPerStudent.MatchAssignmentPerStudent(assignmentsDictionary, studentsDictionary);
                                AssignmentPerStudent.AddRangeDictionary(newAssignmentPerStudentDictionary, assignmentPerStudentDictionary);
                                break;

                            case (short)RegisterData.SubmitDateForAssignment:
                                Console.Clear();
                                Console.WriteLine("Submit Date for Assignment");
                                var submissionInput = Submission.SubmissionDate();
                                Submission.StudentToSubmitAssignment(assignmentPerStudentDictionary, submissionInput);
                                Submission.PrintSubmissionDate(datesOfSubmission);
                                break;

                            case (short)RegisterData.MainMenu:
                                subMenu = false; // Exit sub-menu
                                Console.Clear();
                                break;

                            case (short)RegisterData.Quit:
                                registerData = false; // Exit Register Data options menu
                                subMenu = false; // Exit sub-menu
                                allowDataEntry = false; // Exit main-menu
                                break;

                            default:
                                Console.WriteLine("Wrong selection. Please try again...\n");
                                break;
                        }
                        registerData = false; // Exit Register Data options menu
                        userChoice = (short)MainMenu.RegisterData; // Go back to the Register Data sub-menu 
                    }

                    // Loop for the Print Data sub-menu options
                    while (printData)
                    {
                        switch (userChoice)
                        {
                            case (short)PrintData.Students:
                                Student.PrintStudents(studentsDictionary);
                                break;

                            case (short)PrintData.Trainers:
                                Trainer.PrintTrainers(trainersDictionary);
                                break;

                            case (short)PrintData.Assignments:
                                Assignment.PrintAssignments(assignmentsDictionary);
                                break;

                            case (short)PrintData.Courses:
                                Course.PrintCourses(coursesDictionary);
                                break;

                            case (short)PrintData.StudentsPerCourse:
                                StudentPerCourse.PrintStudentsPerCourse(studentsPerCourseDictionary);
                                break;

                            case (short)PrintData.TrainersPerCourse:
                                TrainerPerCourse.PrintTrainersPerCourse(trainersPerCourseDictionary);
                                break;

                            case (short)PrintData.AssignmentsPerCourse:
                                AssignmentPerCourse.PrintAssignmentsPerCourse(assignmentPerCourseDictionary);
                                break;

                            case (short)PrintData.AssignmentsPerStudent:
                                AssignmentPerStudent.PrintAssignmentsPerStudent(assignmentPerStudentDictionary);
                                break;

                            case (short)PrintData.MainMenu:
                                subMenu = false; // Exit sub-menu
                                Console.Clear();
                                break;

                            case (short)PrintData.Quit:
                                printData = false; // Exit Print Data options menu
                                subMenu = false; // Exit sub-menu
                                allowDataEntry = false; // Exit main-menu
                                break;

                            default:
                                Console.WriteLine("Wrong selection. Please try again...\n");
                                break;
                        }
                        printData = false; // Exit Print Data options menu
                        userChoice = (short)MainMenu.PrintData; // Go back to the Print Data sub-menu 
                    }
                }
                // Check condition of loop to add more than one entry at a time
            } while (allowDataEntry);



        }
    }
}
