using System.Collections.Generic;
using csharp_question_five.Models.Services;

namespace csharp_question_five.Models{
    public class StudentInfo{
        public string StuName { get; set; }
        public int StuId { get; set; }
        public List<SubjectInfo> Subjects { get; set; } = new List<SubjectInfo>();

        private readonly StudentInfoService _studentService = new StudentInfoService();

        public double CalculateAverageSubjectGrade()
        {
            return _studentService.CalculateAverageSubjectGrade(Subjects);
        }

        public double GetHighestSubjectGrade()
        {
            return _studentService.GetHighestSubjectGrade(Subjects);
        }

        public double GetLowestSubjectGrade()
        {
            return _studentService.GetLowestSubjectGrade(Subjects);
        }
    }
}