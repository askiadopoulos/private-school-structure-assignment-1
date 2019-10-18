Coding Bootcamp - Assignment 1 Brief

You are required to produce a solution that implements a private school structure.

The private school must include at least the following entities:

• Student
  o First Name
  o Last Name
  o Date of Birth
  o Tuition Fees
• Trainer
  o First Name
  o Last Name
  o Subject
• Assignment
  o Title
  o Description
  o Submission Date and Time
  o Oral Mark
  o Total Mark
• Course
  o Title
  o Stream (Java, C#)
  o Type (Full, Part)
  o Start Date, End Date
  
Your program must ask from the command prompt to input data to all the entities and it should give the option to add more than one entry at a time [10 marks].

If the user decides not to type any data, the program should use synthetic data [5 marks].

Also, your program must be able to output the following:

• A list of all the students [5 marks]
• A list of all the trainers [5 marks]
• A list of all the assignments [5 marks]
• A list of all the courses [5 marks]
• All the students per course [10 marks]
HINT: Make a new class that contains the students within a course
• All the trainers per course [10 marks]
HINT: As above
• All the assignments per course [10 marks]
HINT: As above
• All the assignments per student [10 marks]
HINT: You need to relate a student per course and per assignment
• A list of students that belong to more than one courses [10 marks]

Lastly, the program should ask from the user a date and it should output a list of students who need to submit one or more assignments on the same calendar week as the given date [15 marks].

HINT 1: The calendar week is considered as Monday to Friday for submissions. For example, if the user inputs 15/2/2019 you need to check from Monday 11/2/2019 to Friday 15/2/2019.
If the user inputs 16/2/2019 (Saturday) or 17/2/2019 (Sunday) you need to check from Monday 11/2/2019 to Friday 15/2/2019.

HINT 2: C#: https://docs.microsoft.com/enus/dotnet/api/system.datetime.dayofweek?view=netframework-4.7.2
