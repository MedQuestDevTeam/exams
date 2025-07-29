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
        Console.WriteLine("成绩从高到低：" + string.Join(", ", sorted));
    }
}

class StudentSystem
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Alice", "S001", new List<int> { 85, 92, 78 }),
            new Student("Bob", "S002", new List<int> { 66, 75, 88 })
        };

        foreach (var student in students)
        {
            Console.WriteLine($"\n学生：{student.Name}（ID: {student.StudentID}）");
            Console.WriteLine($"平均成绩：{student.GetAverage():F2}");
            student.PrintSortedGrades();
        }
    }
}
