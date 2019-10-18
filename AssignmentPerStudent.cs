using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class AssignmentPerStudent
    {
        // Properties
        public Assignment Assignment { get; set; }
        public Student Student { get; set; }

        // Method to match an assignment with a student. The user must input a valid pair of assignment and student ID's.
        // It checks whether the two keys (ID's) exist in the dictionary as <TKey>. If yes, then the corresponding
        // objects (Assignment and Student) are stored as <TKey, TValue> in a new dictionary (declared in the Main Program).
        public static Dictionary<Assignment, Student> MatchAssignmentPerStudent(Dictionary<short, Assignment> assignmentsDictionary, Dictionary<short, Student> studentsDictionary)
        {
            Dictionary<Assignment, Student> assignmentsPerStudentDictionary = new Dictionary<Assignment, Student>();
            short inputAssignmentID = 0, inputStudentID = 0; // User input as ID to check if it exists in Assignments and Students

            Console.Write("\nEnter an Assignment ID (> 0) to match with a Student: ");
            inputAssignmentID = short.Parse(Console.ReadLine());
            Console.Write("Enter a Student ID (> 0) to match with an Assignment: ");
            inputStudentID = short.Parse(Console.ReadLine());

            // Check if the dictionaries are empty
            if (assignmentsDictionary.Count <= 0 || studentsDictionary.Count <= 0)
            {
                Console.Write("\nStudent and/or Course Dictionaries are empty.");
            }
            // Check if input keys exist in both dictionaries
            else if (!assignmentsDictionary.ContainsKey(inputAssignmentID) || (!studentsDictionary.ContainsKey(inputStudentID)))
            {
                Console.Write("\nNo such key(s) where found in the corresponding dictionaries.");
            }
            else
            {
                // Why -1 ? The index position of an element in a dictionary starts from 0. If the user inputs
                // an ID with number 1, the corresponding index position will be equal with the index number -1.
                var assignmentID = assignmentsDictionary.ElementAt(inputAssignmentID - 1);
                var studentID = studentsDictionary.ElementAt(inputStudentID - 1);

                // Store assignment ID as <TKey> and student ID as <TValue> in a new Assignments Per Student dictionary
                assignmentsPerStudentDictionary.Add(assignmentID.Value, studentID.Value);
                Console.Write("\nSuccesfully match Assignment with Student.");
            }
            Console.Write(" Press any key to continue...");
            Console.ReadKey();
            return assignmentsPerStudentDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created assignments per student
        // (TKey, TValue) dictionary (source) into a new assignments <TKey> per student <TValue> dictionary (destination),
        // which is declared in the Main Program.
        public static Dictionary<Assignment, Student> AddRangeDictionary(Dictionary<Assignment, Student> sourceDictionary, Dictionary<Assignment, Student> destinationDictionary)
        {
            foreach (KeyValuePair<Assignment, Student> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prints all the assignments within an already existing student
        public static void PrintAssignmentsPerStudent(Dictionary<Assignment, Student> dictionaryOfAssignmentsPerStudentToPrint)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE ASSIGNMENTS PER STUDENT OF THE PRIVATE SCHOOL***\n");
            Console.Write("\nType a Student to print all the Assignments within it: ");
            string inputStudent = Console.ReadLine();
            int counter = 0; // increased if no student is found

            foreach (var assignmentPerStudent in dictionaryOfAssignmentsPerStudentToPrint)
            {
                // if student firstname & lastname exists within the dictionary, print the results
                if (inputStudent.Contains(assignmentPerStudent.Value.FirstName) && inputStudent.Contains(assignmentPerStudent.Value.LastName))
                {
                    Console.WriteLine($"\n|ASSIGNMENT|{assignmentPerStudent.Key}");
                    Console.WriteLine($"|STUDENT|{assignmentPerStudent.Value}\n");
                }
                else
                {
                    counter++;
                }
                // if dictionary's capacity is reached and no student is found
                if (counter == dictionaryOfAssignmentsPerStudentToPrint.Count)
                {
                    Console.WriteLine("Student does not exists in the dictionary...");
                }
            }
            Console.Write("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
