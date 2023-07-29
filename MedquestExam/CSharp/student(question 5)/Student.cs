public class Student
{
    public string Name { get; set; }
    public int StudentID { get; set; }
    public List<double> Grades { get; set; }

    public Student(){}
    public Student(string name, int studentID, List<double> grades)
    {
        this.Name = name;
        this.StudentID = studentID;
        this.Grades = grades;
    }

    public double CalculateAverage()
    {
        double total = 0;

        foreach (double grade in Grades)
        {
            total += grade;
        }

        return total / Grades.Count;
    }

    public void SortGrades()
    {
        Grades.Sort();
    }
}
