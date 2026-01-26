using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * C# Question 5: Using the Student class to manage student grades
 * Author: Kevin Tian
 */

namespace MQExamsSolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public Student(string studentId, string name)
        {
            StudentId = studentId;
            Name = name;
            Grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            if (grade < 0 || grade > 100) throw new ArgumentException("Grade must be 0-100");
            Grades.Add(grade);
        }

        // Sort grades ascending / descending
        public void SortGrades(bool descending = false)
        {
            if (descending)
                Grades.Sort((a, b) => b.CompareTo(a));
            else
                Grades.Sort();
        }

        // Statistics
        public double Average()
        {
            if (Grades.Count == 0) return 0;
            return Grades.Average();
        }

        public double Min()
        {
            if (Grades.Count == 0) return 0;
            return Grades.Min();
        }

        public double Max()
        {
            if (Grades.Count == 0) return 0;
            return Grades.Max();
        }

        public override string ToString()
        {
            return $"{StudentId} - {Name} | Avg: {Average():0.00}";
        }
    }

    // Helper class for class-level statistics (multiple students)
    public static class StudentStats
    {
        public static double ClassAverage(List<Student> students)
        {
            var all = students.SelectMany(s => s.Grades).ToList();
            if (all.Count == 0) return 0;
            return all.Average();
        }

        public static Student? TopStudentByAverage(List<Student> students)
        {
            if (students == null || students.Count == 0) return null;
            return students.OrderByDescending(s => s.Average()).FirstOrDefault();
        }
    }
}
