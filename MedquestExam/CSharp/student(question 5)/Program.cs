using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a student.
            Student student = new Student("John Doe", 123456, new List<double> { 90, 80, 70 });

            // Calculate the student's average grade.
            double average = student.CalculateAverage();

            // Sort the student's grades.
            student.SortGrades();

            // Print the student's information.
            Console.WriteLine("Student name: {0}", student.Name);
            Console.WriteLine("Student ID: {0}", student.StudentID);
            Console.WriteLine("Student average: {0}", average);
            Console.WriteLine("Student grades: " + string.Join(", ", student.Grades));
        }
    }
