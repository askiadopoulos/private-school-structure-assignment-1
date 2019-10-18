using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Trainer
    {
        // Member variable, counts the number of succesfull constructed objects
        private static ushort counter = 0;

        // Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        // Default Constructor
        public Trainer()
        {
            counter++; // Increases automatically every time a new object is created
            Console.WriteLine($"\nTrainer #{counter}");
        }

        // Constructor with Parameters | Used for initializing the Synthetic data at run-time
        public Trainer(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        // Method of type Trainer | The user can input data at run-time
        public Trainer InputTrainerData()
        {
            Console.Write("FirstName: ");
            var firstName = Console.ReadLine();
            Console.Write("LastName: ");
            var lastName = Console.ReadLine();
            Console.Write("Subject: ");
            var subject = Console.ReadLine();

            FirstName = firstName;
            LastName = lastName;
            Subject = subject;

            // Initialize a variable of type Trainer using the Constructor with parameters
            var trainer = new Trainer(firstName, lastName, subject);
            return trainer;
        }

        // Create trainers on-demand and store them in an accessible dictionary.
        public static Dictionary<short, Trainer> CreateTrainers(short numberToCreateTrainers)
        {
            var newTrainersDictionary = new Dictionary<short, Trainer>(); // Used to store the recently created trainer(s)
            Trainer newTrainer = null; // Used to create a new trainer every time
            short primaryKey = 0; // Auto increment Primary Key (ID) to uniquely identify a recently created trainer

            for (ushort i = 0; i < numberToCreateTrainers; i++)
            {
                newTrainer = new Trainer();
                primaryKey++;
                newTrainersDictionary.Add(primaryKey, newTrainer.InputTrainerData()); // TValue is initialized via method
            }
            return newTrainersDictionary;
        }

        // Method to copy the contents <TKey, TValue> of a dictionary to another (similar with the List.AddRange).
        // In our case, the AddRangeDictionary() copies the contents of the recently created trainers dictionary
        // (source) into the trainers dictionary (destination), which is declared in the Main Program.  
        public static Dictionary<short, Trainer> AddRangeDictionary(Dictionary<short, Trainer> sourceDictionary, Dictionary<short, Trainer> destinationDictionary)
        {
            foreach (KeyValuePair<short, Trainer> pair in sourceDictionary) // KeyValuePair defines a pair to be set
            {
                destinationDictionary.Add(pair.Key, pair.Value);
            }
            return destinationDictionary;
        }

        // Prints the trainers data contained in the corresponding dictionary
        public static void PrintTrainers(Dictionary<short, Trainer> dictionaryOfTrainersToPrint)
        {
            Console.Clear();
            Console.WriteLine("\n***A LIST OF ALL THE TRAINERS OF THE PRIVATE SCHOOL***\n");
            foreach (var trainer in dictionaryOfTrainersToPrint)
            {
                Console.WriteLine($"{trainer.ToString()}");
            }
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // Override method ToString() to print the contents of a collection (trainers dictionary)
        public override string ToString()
        {
            return ($"FirstName: {FirstName}, LastName: {LastName}, Subject: {Subject}");
        }

    }
}
