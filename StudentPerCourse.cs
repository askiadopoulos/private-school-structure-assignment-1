using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class StudentPerCourse
    {
        // Holds the ID of the Students in order to compare for dublicates
        private static Dictionary<Student, Course> IdOfStudentDictionary = new Dictionary<Student, Course>();

        // Properties
        public Student Student { get; set; }
        public Course Course { get; set; }

        // Method to match a student with a course. The user must input a valid pair of student and course ID's.
        // It checks whether the two keys (ID's) exist in the dictionary as <TKey>. If yes, then the corresponding
        // objects (Student and Course) are stored as <TKey, TValue> in a new dictionary (declared in the Main Program).
        public static Dictionary<Student, Course> MatchStudentPerCourse(Dictionary<short, Student> studentsDictionary, Dictionary<short, Course> coursesDictionary)
        {
            Dictionary<Student, Course> studentsPerCourseDictionary = new Dictionary<Student, Course>();
            short inputStudentID = 0, inputCourseID = 0; // User input as ID to check if it exists in Students and Courses

            Console.Write("\nEnter a Student ID (> 0) to match with a Course: ");
            inputStudentID = short.Parse(Console.ReadLine());
            Console.Write("Enter a Course ID (> 0) to match with a Student: ");
            inputCourseID = short.Parse(Console.ReadLine());

            // Check if the dictionaries are empty
            if (studentsDictionary.Count <= 0 || coursesDictionary.Count <= 0)
            {
                Console.Write("\nStudent and/or Course Dictionaries are empty.");
            }
            // Check if input keys exist in both dictionaries
            else if (!studentsDictionary.ContainsKey(inputStudentID) || !coursesDictionary.ContainsKey(inputCourseID))
            {
                Console.Write("\nNo such key(s) where found in the corresponding dictionaries.");
            }
            // Check for dublicates in student IDs: A course can be attended by one or more
            // students at the same time, but a student can only attend one course at a time.
            else if (IdOfStudentDictionary.ContainsKey(studentsDictionary[inputStudentID]))
            {
                Console.Write("\nThe submitted key is already used in the corresponding Students dictionary.");
            }
            else
            {
                // Why -1 ? The index position of an element in a dictionary starts from 0. If the user inputs
                // an ID with number 1, the corresponding index position will be equal with the index number -1.
                var studentID = studentsDictionary.ElementAt(inputStudentID - 1);
                var courseID = coursesDictionary.ElementAt(inputCourseID - 1);

                // Store student ID as <TKey> and course ID as <TValue> in a new Students Per Course dictionary
                studentsPerCourseDictionary.Add(studentID.Value, courseID.Value);
                // Store student ID as <TKey> in order to check for duplicates
                IdOfStudentDictionary.Add(studentID.Value, courseID.Value);
                Console.Write("\nSuccesfully match Student with Course.");
            }
            Console.Write(" Press any key to continue...");
            Console.ReadKey();

            return studentsPerCourseDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created students per course
        // (TKey, TValue) dictionary (source) into a new students <TKey> per course <TValue> dictionary (destination),
        // which is declared in the Main Program.
        public static Dictionary<Student, Course> AddRangeDictionary(Dictionary<Student, Course> sourceDictionary, Dictionary<Student, Course> destinationDictionary)
        {
            foreach (KeyValuePair<Student, Course> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prints all the students within an already existing course
        public static void PrintStudentsPerCourse(Dictionary<Student, Course> dictionaryOfStudentsPerCourseToPrint)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE STUDENTS PER COURSE OF THE PRIVATE SCHOOL***\n");
            Console.Write("\nType a Course to print all the Students within it: ");
            string inputCourse = Console.ReadLine();
            int counter = 0; // increased if no course is found

            foreach (var studentPerCourse in dictionaryOfStudentsPerCourseToPrint)
            {
                // if course title exists within the dictionary, print the results
                if (inputCourse.Contains(studentPerCourse.Value.Title))
                {
                    Console.WriteLine($"\n|STUDENT|{studentPerCourse.Key}");
                    Console.WriteLine($"|COURSE|{studentPerCourse.Value}\n");
                }
                else
                {
                    counter++;
                }
                // if dictionary's capacity is reached and no course is found
                if (counter == dictionaryOfStudentsPerCourseToPrint.Count)
                {
                    Console.WriteLine("Course does not exists in the dictionary...");
                }
            }
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
