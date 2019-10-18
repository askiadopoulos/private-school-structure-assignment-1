using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public enum Stream { Java = 1, CSharp }
    public enum Type { Full = 1, Part }
    class Course
    {
        // Member variable, counts the number of succesfull constructed objects
        private static ushort counter = 0;

        // Properties
        public string Title { get; set; }
        public Stream Stream { get; set; } // Java, C#
        public Type Type { get; set; } // Full, Part
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Default Constructor
        public Course()
        {
            counter++; // Increases automatically every time a new object is created
            Console.WriteLine($"\nCourse #{counter}");
        }

        // Constructor with parameters | Used for initializing the Synthetic data at run-time
        public Course(string title, Stream stream, Type type, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Method of type Course | The user can input data at run-time
        public Course InputCourseData()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Stream (1 for Java)|2 for C#): ");
            var stream = (Stream)Enum.Parse(typeof(Stream), Console.ReadLine());

            Console.Write("Type (1 for Full-Time|2 for Part-Time): ");
            var type = (Type)Enum.Parse(typeof(Type), Console.ReadLine());
            Console.Write("Start Date (yyyy/mm/dd): ");
            var startDate = Convert.ToDateTime(Console.ReadLine());
            Console.Write("End Date (yyyy/mm/dd): ");
            var endDate = Convert.ToDateTime(Console.ReadLine());

            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;

            // Initialize a variable of type Course using the Constructor with parameters
            var course = new Course(title, stream, type, startDate, endDate);
            return course;
        }

        // Create courses on-demand and store them in an accessible dictionary.
        public static Dictionary<short, Course> CreateCourses(short numberToCreateCourses)
        {
            var newCoursesDictionary = new Dictionary<short, Course>(); // Used to store the recently created course(s)
            Course newCourse = null; // Used to create a new course every time
            short primaryKey = 0; // Auto increment Primary Key (ID) to uniquely identify a recently created course

            for (ushort i = 0; i < numberToCreateCourses; i++)
            {
                newCourse = new Course();
                primaryKey++;
                newCoursesDictionary.Add(primaryKey, newCourse.InputCourseData()); // TValue is initialized via method
            }
            return newCoursesDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created courses dictionary
        // (source) into the courses dictionary (destination), which is declared in the Main Program.  
        public static Dictionary<short, Course> AddRangeDictionary(Dictionary<short, Course> sourceDictionary, Dictionary<short, Course> destinationDictionary)
        {
            foreach (KeyValuePair<short, Course> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prints the courses data contained in the corresponding dictionary
        public static void PrintCourses(Dictionary<short, Course> dictionaryOfCoursesToPrint)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE COURSES OF THE PRIVATE SCHOOL***\n");
            foreach (var course in dictionaryOfCoursesToPrint)
            {
                Console.WriteLine($"{course.ToString()}");
            }
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // Override method ToString() to print the contents of a collection (courses dictionary)
        public override string ToString()
        {
            return ($"Title: {Title}, Stream: {Stream}, Type: {Type}, Start Date: {StartDate.ToShortDateString()}, " +
                    $"End Date {EndDate.ToShortDateString()}");
        }

    }
}
