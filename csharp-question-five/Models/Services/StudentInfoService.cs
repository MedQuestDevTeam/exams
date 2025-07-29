using System.Collections.Generic;
using System.Linq;

namespace csharp_question_five.Models.Services
{
    public class StudentInfoService
    {
        public double CalculateAverageSubjectGrade(IEnumerable<SubjectInfo> subjects)
        {
            if (!subjects.Any())
                return 0;

            double totalGrade = subjects.Sum(subject => subject.SubjectGrade);
            return totalGrade / subjects.Count();
        }

        public double GetHighestSubjectGrade(IEnumerable<SubjectInfo> subjects)
        {
            if (!subjects.Any())
                return 0;

            return subjects.Max(subject => subject.SubjectGrade);
        }

        public double GetLowestSubjectGrade(IEnumerable<SubjectInfo> subjects)
        {
            if (!subjects.Any())
                return 0;

            return subjects.Min(subject => subject.SubjectGrade);
        }
    }
}
