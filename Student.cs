using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Student
    {
        // Member variable, counts the number of succesfull constructed objects
        private static ushort counter = 0;

        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double TuitionFees { get; set; }

        // Default Constructor
        public Student()
        {
            counter++; // Increases automatically every time a new object is created
            Console.WriteLine($"\nStudent #{counter}");
        }

        // Constructor with parameters | Used for initializing the Synthetic data at run-time
        public Student(string firstName, string lastName, DateTime dateOfBirth, double tuitionFees)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;
        }

        // Method of type Student | The user can input data at run-time
        public Student InputStudentData()
        {
            Console.Write("FirstName: ");
            var firstName = Console.ReadLine();
            Console.Write("LastName: ");
            var lastName = Console.ReadLine();
            Console.Write("Date Of Birth (yyyy/mm/dd): ");
            var dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Tuition Fees: ");
            var tuitionFees = Convert.ToDouble(Console.ReadLine());

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            TuitionFees = tuitionFees;

            // Initialize a variable of type Student using the Constructor with parameters
            var student = new Student(firstName, lastName, dateOfBirth, tuitionFees);
            return student;
        }

        // Create students on-demand and store them in an accessible dictionary.
        public static Dictionary<short, Student> CreateStudents(short numberToCreateStudents)
        {
            var newStudentsDictionary = new Dictionary<short, Student>(); // Used to store the recently created student(s)
            Student newStudent = null; // Used to create a new student every time
            short primaryKey = 0; // Auto increment Primary Key (ID) to uniquely identify a recently created student

            for (ushort i = 0; i < numberToCreateStudents; i++)
            {
                newStudent = new Student();
                primaryKey++;
                newStudentsDictionary.Add(primaryKey, newStudent.InputStudentData()); // TValue is initialized via method
            }
            return newStudentsDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created students dictionary
        // (source) into the students dictionary (destination), which is declared in the Main Program.
        public static Dictionary<short, Student> AddRangeDictionary(Dictionary<short, Student> sourceDictionary, Dictionary<short, Student> destinationDictionary)
        {
            foreach (KeyValuePair<short, Student> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prints the students data contained in the corresponding dictionary
        public static void PrintStudents(Dictionary<short, Student> dictionaryOfStudentsToPrint)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE STUDENTS OF THE PRIVATE SCHOOL***\n");
            foreach (var student in dictionaryOfStudentsToPrint)
            {
                Console.WriteLine($"{student.ToString()}");
            }
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // Override method ToString() to print the contents of a collection(students dictionary)
        public override string ToString()
        {
            return ($"FirstName: {FirstName}, LastName: {LastName}, Date of Birth {DateOfBirth.ToShortDateString()} " +
                    $"Tuition Fees: {TuitionFees} EUR");
        }

    }
}
