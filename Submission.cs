using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Submission
    {
        //public Dictionary<Course, Student> CoursesPerStudentDictionary { get; set; }
        //public Dictionary<Assignment, Student> AssignmentsPerStudentDictionary { get; set; }
        public Student Student { get; set; }
        public Assignment Assignment { get; set; }

        public static DateTime SubmissionDate()
        {
            Console.Write("Enter a date to check for submissions: ");
            DateTime submissionDateInput = DateTime.Parse(Console.ReadLine());
            return submissionDateInput;
        }

        public static List<DateTime> StudentToSubmitAssignment(Dictionary<Assignment, Student> assignmentsPerStudentsDictionary, DateTime dateOfSubmission)
        {
            var startToEndOfWeek = new List<DateTime>();

            var startOfWeek = new DateTime();
            var endOfWeek = new DateTime();

            switch (dateOfSubmission.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    startOfWeek = dateOfSubmission;
                    endOfWeek = dateOfSubmission.AddDays(4);
                    break;

                case DayOfWeek.Tuesday:
                    startOfWeek = dateOfSubmission;
                    endOfWeek = dateOfSubmission.AddDays(3);
                    break;

                case DayOfWeek.Wednesday:
                    startOfWeek = dateOfSubmission;
                    endOfWeek = dateOfSubmission.AddDays(2);
                    break;

                case DayOfWeek.Thursday:
                    startOfWeek = dateOfSubmission;
                    endOfWeek = dateOfSubmission.AddDays(1);
                    break;

                case DayOfWeek.Friday:
                    startOfWeek = dateOfSubmission;
                    endOfWeek = dateOfSubmission;
                    break;

                case DayOfWeek.Saturday:
                    startOfWeek = dateOfSubmission;
                    endOfWeek = dateOfSubmission.AddDays(-1);
                    break;

                case DayOfWeek.Sunday:
                    startOfWeek = dateOfSubmission;
                    endOfWeek = dateOfSubmission.AddDays(-2);
                    break;

                default:
                    break;
            }
            startToEndOfWeek.Add(startOfWeek);
            startToEndOfWeek.Add(endOfWeek);

            return startToEndOfWeek;
        }

        public static void PrintSubmissionDate(List<DateTime> startToEndWeek)
        {
            var temp = new Submission();

            foreach (DateTime days in startToEndWeek)
            {
                Console.WriteLine(days);
            }
            Console.ReadKey();
        }

    }
}
