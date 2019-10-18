using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class AssignmentPerCourse
    {
        // Holds the ID of the Assignments in order to compare for dublicates
        private static Dictionary<Assignment, Course> IdOfAssignmentDictionary = new Dictionary<Assignment, Course>();

        // Properties
        public Assignment Assignment { get; set; }
        public Course Course { get; set; }

        // Method to match an assignment with a course. The user must input a valid pair of assignment and course ID's.
        // It checks whether the two keys (ID's) exist in the dictionary as <TKey>. If yes, then the corresponding
        // objects (Assignment and Course) are stored as <TKey, TValue> in a new dictionary (declared in the Main Program).
        public static Dictionary<Assignment, Course> MatchAssignmentPerCourse(Dictionary<short, Assignment> assignmentsDictionary, Dictionary<short, Course> coursesDictionary)
        {
            Dictionary<Assignment, Course> assignmentsPerCourseDictionary = new Dictionary<Assignment, Course>();
            short inputAssignmentID = 0, inputCourseID = 0; // User input as ID to check if it exists in Assignments and Courses

            Console.Write("\nEnter an Assignment ID (> 0) to match with a Course: ");
            inputAssignmentID = short.Parse(Console.ReadLine());
            Console.Write("Enter a Course ID (> 0) to match with an Assignment: ");
            inputCourseID = short.Parse(Console.ReadLine());

            // Check if the dictionaries are empty
            if (assignmentsDictionary.Count <= 0 || coursesDictionary.Count <= 0)
            {
                Console.Write("\nTrainer and/or Course Dictionaries are empty.");
            }
            // Check if input keys exist in both dictionaries
            else if (!assignmentsDictionary.ContainsKey(inputAssignmentID) || (!coursesDictionary.ContainsKey(inputCourseID)))
            {
                Console.Write("\nNo such key(s) where found in the corresponding dictionaries.");
            }
            // Check for dublicates in assignment IDs: A course can have one or more assignments
            // at the same time, but only one assignment can be part of a course at a time.
            else if (IdOfAssignmentDictionary.ContainsKey(assignmentsDictionary[inputAssignmentID]))
            {
                Console.Write("\nThe submitted key is already used in the corresponding Assignments dictionary.");
            }
            else
            {
                // Why -1 ? The index position of an element in a dictionary starts from 0. If the user inputs
                // an ID with number 1, the corresponding index position will be equal with the index number -1.
                var assignmentID = assignmentsDictionary.ElementAt(inputAssignmentID - 1);
                var courseID = coursesDictionary.ElementAt(inputCourseID - 1);

                // Store assignment ID as <TKey> and course ID as <TValue> in a new Assignments Per Course dictionary
                assignmentsPerCourseDictionary.Add(assignmentID.Value, courseID.Value);
                // Store assignment ID as <TKey> in order to check for duplicates
                IdOfAssignmentDictionary.Add(assignmentID.Value, courseID.Value);
                Console.Write("\nSuccesfully match Assignment with Course.");
            }
            Console.Write(" Press any key to continue...");
            Console.ReadKey();
            return assignmentsPerCourseDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created assignments per course
        // (TKey, TValue) dictionary (source) into a new assignments <TKey> per course <TValue> dictionary (destination),
        // which is declared in the Main Program.
        public static Dictionary<Assignment, Course> AddRangeDictionary(Dictionary<Assignment, Course> sourceDictionary, Dictionary<Assignment, Course> destinationDictionary)
        {
            foreach (KeyValuePair<Assignment, Course> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prints all the assignments within an already existing course
        public static void PrintAssignmentsPerCourse(Dictionary<Assignment, Course> dictionaryOfAssignmentsPerCourseToPrint)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE ASSIGNMENTS PER COURSE OF THE PRIVATE SCHOOL***\n");
            Console.Write("\nType a Course to print all the Assignments within it: ");
            string inputCourse = Console.ReadLine();
            int counter = 0; // increased if no course is found

            foreach (var assignmentPerCourse in dictionaryOfAssignmentsPerCourseToPrint)
            {
                // if course title exists within the dictionary, print the results
                if (inputCourse.Contains(assignmentPerCourse.Value.Title))
                {
                    Console.WriteLine($"\n|ASSIGNMENT|{assignmentPerCourse.Key}");
                    Console.WriteLine($"|COURSE|{assignmentPerCourse.Value}\n");
                }
                else
                {
                    counter++;
                }
                // if dictionary's capacity is reached and no course is found
                if (counter == dictionaryOfAssignmentsPerCourseToPrint.Count)
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
