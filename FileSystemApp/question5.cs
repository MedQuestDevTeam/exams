using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public string StudentID { get; set; }
    public List<int> Grades { get; set; }

    public Student(string name, string id, List<int> grades)
    {
        Name = name;
        StudentID = id;
        Grades = grades;
    }

    public double GetAverage()
    {
        return Grades.Average();
    }

    public void PrintSortedGrades()
    {
        var sorted = Grades.OrderByDescending(g => g);
        Console.WriteLine("Grades from high to low: " + string.Join(", ", sorted));
    }
}

class StudentSystem
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        Console.Write("Enter the number of students: ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter information for student {i + 1}:");

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Student ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter grades separated by spaces (e.g., 85 92 78): ");
            string[] gradeInput = Console.ReadLine().Split(' ');
            List<int> grades = new List<int>();

            foreach (string g in gradeInput)
            {
                if (int.TryParse(g, out int grade))
                    grades.Add(grade);
            }

            students.Add(new Student(name, id, grades));
        }

        Console.WriteLine("\n===== Student Results =====");

        foreach (var student in students)
        {
            Console.WriteLine($"\nStudent: {student.Name} (ID: {student.StudentID})");
            Console.WriteLine($"Average Grade: {student.GetAverage():F2}");
            student.PrintSortedGrades();
        }
    }
}
