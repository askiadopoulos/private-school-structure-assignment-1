using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Assignment
    {
        // Member variable, counts the number of succesfull constructed objects
        private static ushort counter = 0;

        // Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDateTime { get; set; }
        public double OralMark { get; set; }
        public double TotalMark { get; set; }

        // Default Constructor
        public Assignment()
        {
            counter++; // Increases automatically every time a new object is created
            Console.WriteLine($"\nAssignment #{counter}");
        }

        // Constructor with Parameters | Used for initializing the Synthetic data at run-time
        public Assignment(string title, string description, DateTime submissionDateTime, double oralMark, double totalMark)
        {
            Title = title;
            Description = description;
            SubmissionDateTime = submissionDateTime;
            OralMark = oralMark;
            TotalMark = totalMark;
        }

        //Method of type Assignment | The user can input data at run-time
        public Assignment InputAssignmentData()
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();
            Console.Write("Submission Date and Time (yyyy/mm/dd): ");
            var submissionDateTime = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Oral Mark: ");
            var oralMark = Convert.ToDouble(Console.ReadLine());
            Console.Write("Total Mark: ");
            var totalMark = Convert.ToDouble(Console.ReadLine());

            Title = title;
            Description = description;
            SubmissionDateTime = submissionDateTime;
            OralMark = oralMark;
            TotalMark = totalMark;

            // Initialize a variable of type Assignment using the Constructor with parameters
            var assignment = new Assignment(title, description, submissionDateTime, oralMark, totalMark);
            return assignment;
        }

        // Create assignments on-demand and store them in an accessible dictionary.
        public static Dictionary<short, Assignment> CreateAssignments(short numberToCreateAssignments)
        {
            var newAssignmentssDictionary = new Dictionary<short, Assignment>(); // Used to store the recently created assignments(s)
            Assignment newAssignment = null; // Used to create a new assignment every time
            short primaryKey = 0; // Auto increment Primary Key (ID) to uniquely identify a recently created assignment

            for (ushort i = 0; i < numberToCreateAssignments; i++)
            {
                newAssignment = new Assignment();
                primaryKey++;
                newAssignmentssDictionary.Add(primaryKey, newAssignment.InputAssignmentData()); // TValue is initialized via method
            }
            return newAssignmentssDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created assignments dictionary
        // (source) shorto the assignments dictionary (destination), which is declared in the Main Program.  
        public static Dictionary<short, Assignment> AddRangeDictionary(Dictionary<short, Assignment> sourceDictionary, Dictionary<short, Assignment> destinationDictionary)
        {
            foreach (KeyValuePair<short, Assignment> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prshorts the assignments data contained in the corresponding dictionary
        public static void PrintAssignments(Dictionary<short, Assignment> dictionaryOfAssignmentsToPrshort)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE ASSIGNMENTS OF THE PRIVATE SCHOOL***\n");
            foreach (var assignment in dictionaryOfAssignmentsToPrshort)
            {
                Console.WriteLine($"{assignment.ToString()}");
            }
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // Override method ToString() to prshort the contents of a collection (assignment dictionary)
        public override string ToString()
        {
            return ($"Title: {Title}, Description: {Description}, Submission Date and Time: {SubmissionDateTime}, " +
                    $"Oral Mark: {OralMark} | Total Mark {TotalMark}");
        }

    }
}
