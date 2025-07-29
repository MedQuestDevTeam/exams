using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharp_question_five.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace csharp_question_five.Controllers
{
    public class StudentInfoController : Controller
    {
        public ActionResult Index()
        {
           var students = new List<StudentInfo>
            {
                new StudentInfo{
                    StuId = 1000001,
                    StuName = "Thomas",
                    Subjects = new List<SubjectInfo>
                    {
                        new SubjectInfo {SubjectName = "Math",SubjectGrade = 97},
                        new SubjectInfo {SubjectName = "Science",SubjectGrade = 82},
                        new SubjectInfo {SubjectName = "English",SubjectGrade = 80},
                        new SubjectInfo {SubjectName = "Chinese",SubjectGrade = 86},
                        new SubjectInfo {SubjectName = "Physic",SubjectGrade = 90}
                    }
                },
                new StudentInfo{
                    StuId = 1000002,
                    StuName = "James",
                    Subjects = new List<SubjectInfo>
                    {
                        new SubjectInfo {SubjectName = "Math",SubjectGrade = 80},
                        new SubjectInfo {SubjectName = "Science",SubjectGrade = 81},
                        new SubjectInfo {SubjectName = "English",SubjectGrade = 98},
                        new SubjectInfo {SubjectName = "Chinese",SubjectGrade = 90},
                        new SubjectInfo {SubjectName = "Physic",SubjectGrade = 70}
                    }
                },
                new StudentInfo{
                    StuId = 1000003,
                    StuName = "Vitamin",
                    Subjects = new List<SubjectInfo>
                    {
                        new SubjectInfo {SubjectName = "Math",SubjectGrade = 70},
                        new SubjectInfo {SubjectName = "Science",SubjectGrade = 68},
                        new SubjectInfo {SubjectName = "English",SubjectGrade = 80},
                        new SubjectInfo {SubjectName = "Chinese",SubjectGrade = 71},
                        new SubjectInfo {SubjectName = "Physic",SubjectGrade = 68}
                    }
                }
            };
            return View(students);
        }
    }
}
