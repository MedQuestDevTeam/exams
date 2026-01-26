using MQExamsSolution;

// C# Question 2: Using the FileSystem class to perform file operations
FileSystem fs = new FileSystem();
string filePath = "test.txt";

fs.CreateFile(filePath);
fs.WriteFile(filePath, "Hello from real file system!");
Console.WriteLine(fs.ReadFile(filePath));
fs.DeleteFile(filePath);
Console.WriteLine("Done.");


// C# Question 5: Using the Student class to manage student grades
var s1 = new Student("S001", "Ali");
s1.AddGrade(90);
s1.AddGrade(70);
s1.AddGrade(85);

var s2 = new Student("S002", "Ming");
s2.AddGrade(60);
s2.AddGrade(75);
s2.AddGrade(80);

// Sort grades
s1.SortGrades(descending: true);
Console.WriteLine("S001 grades (desc): " + string.Join(", ", s1.Grades));

// Student stats
Console.WriteLine(s1);
Console.WriteLine($"Min/Max: {s1.Min()} / {s1.Max()}");

// Class stats
var students = new List<Student> { s1, s2 };
Console.WriteLine("Class average: " + StudentStats.ClassAverage(students).ToString("0.00"));

var top = StudentStats.TopStudentByAverage(students);
Console.WriteLine("Top student: " + (top == null ? "-" : top.ToString()));

Console.ReadLine();