using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class TrainerPerCourse
    {
        // Holds the ID of the Trainers in order to compare for dublicates
        private static Dictionary<Trainer, Course> IdOfTrainerDictionary = new Dictionary<Trainer, Course>();

        // Properties
        public Trainer Trainer { get; set; }
        public Course Course { get; set; }

        // Method to match a trainer with a course. The user must input a valid pair of trainer and course ID's.
        // It checks whether the two keys (ID's) exist in the dictionary as <TKey>. If yes, then the corresponding
        // objects (Trainer and Course) are stored as <TKey, TValue> in a new dictionary (declared in the Main Program).
        public static Dictionary<Trainer, Course> MatchTrainerPerCourse(Dictionary<short, Trainer> trainersDictionary, Dictionary<short, Course> coursesDictionary)
        {
            Dictionary<Trainer, Course> trainersPerCourseDictionary = new Dictionary<Trainer, Course>();
            short inputTrainerID = 0, inputCourseID = 0; // User input as ID to check if it exists in Trainers and Courses

            Console.Write("\nEnter a Trainer ID (> 0) to match with a Course: ");
            inputTrainerID = short.Parse(Console.ReadLine());
            Console.Write("Enter a Course ID (> 0) to match with a Trainer: ");
            inputCourseID = short.Parse(Console.ReadLine());

            // Check if the dictionaries are empty
            if (trainersDictionary.Count <= 0 || coursesDictionary.Count <= 0)
            {
                Console.Write("\nTrainer and/or Course Dictionaries are empty.");
            }
            // Check if input keys exist in both dictionaries
            else if (!trainersDictionary.ContainsKey(inputTrainerID) || (!coursesDictionary.ContainsKey(inputCourseID)))
            {
                Console.Write("\nNo such key(s) where found in the corresponding dictionaries.");
            }
            // Check for dublicates in trainer IDs: A course can be teached by one or more 
            // trainers at the same time, but a trainer can only teach one course at a time.
            else if (IdOfTrainerDictionary.ContainsKey(trainersDictionary[inputTrainerID]))
            {
                Console.Write("\nThe submitted key is already used in the corresponding Trainers dictionary.");
            }
            else
            {
                // Why -1 ? The index position of an element in a dictionary starts from 0. If the user inputs
                // an ID with number 1, the corresponding index position will be equal with the index number -1.
                var trainerID = trainersDictionary.ElementAt(inputTrainerID - 1);
                var courseID = coursesDictionary.ElementAt(inputCourseID - 1);

                // Store trainer ID as <TKey> and course ID as <TValue> in a new Trainers Per Course dictionary
                trainersPerCourseDictionary.Add(trainerID.Value, courseID.Value);
                // Store trainer ID as <TKey> in order to check for duplicates
                IdOfTrainerDictionary.Add(trainerID.Value, courseID.Value);
                Console.Write("\nSuccesfully match Trainer with Course.");
            }
            Console.Write(" Press any key to continue...");
            Console.ReadKey();
            return trainersPerCourseDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created trainers per course
        // (TKey, TValue) dictionary (source) into a new trainers <TKey> per course <TValue> dictionary (destination),
        // which is declared in the Main Program.
        public static Dictionary<Trainer, Course> AddRangeDictionary(Dictionary<Trainer, Course> sourceDictionary, Dictionary<Trainer, Course> destinationDictionary)
        {
            foreach (KeyValuePair<Trainer, Course> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prints all the trainers within an already existing course
        public static void PrintTrainersPerCourse(Dictionary<Trainer, Course> dictionaryOfTrainersPerCourseToPrint)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE TRAINERS PER COURSE OF THE PRIVATE SCHOOL***\n");
            Console.Write("\nType a Course to print all the Trainers within it: ");
            string inputCourse = Console.ReadLine();
            int counter = 0; // increased if no course is found

            foreach (var trainerPerCourse in dictionaryOfTrainersPerCourseToPrint)
            {
                // if course title exists within the dictionary, print the results
                if (inputCourse.Contains(trainerPerCourse.Value.Title))
                {
                    Console.WriteLine($"\n|TRAINER|{trainerPerCourse.Key}");
                    Console.WriteLine($"|COURSE|{trainerPerCourse.Value}\n");
                }
                else
                {
                    counter++;
                }
                // if dictionary's capacity is reached and no course is found
                if (counter == dictionaryOfTrainersPerCourseToPrint.Count)
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
