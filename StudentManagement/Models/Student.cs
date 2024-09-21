using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student : Person
    {
        public string studentId { get; set; }

        public string school { get; set; }

        public int startingTime { get; set; }

        public double AverangeScore { get; set; }
        
        public AcademicPerformanceRatingEnum APR { get; set; }

        public Student()
        {
            
        }

        public Student(string Name, DateTime DOB, string Address, float Height, float Weight, string StudentId, string School, int StartingTime, double averangeScore) : base(Name, Address, DOB, Height, Weight)
        {
            studentId = StudentId;
            school = School;
            startingTime = StartingTime;
            AverangeScore = averangeScore;
            UpdateAcademiPerformance();
        }

        public override string ToString()
        {
            base.ToString();
            return $"| StudentInfo | StudentId <{studentId}> School <{school}> StartingTime <{startingTime}> AverangeScore <{AverangeScore}> |";
        }

        private void UpdateAcademiPerformance()
        {
            APR = AverangeScore switch
            {
                < 3 => AcademicPerformanceRatingEnum.POOR,
                >= 3 and < 5 => AcademicPerformanceRatingEnum.WEAK,
                >= 5 and < 6.5 => AcademicPerformanceRatingEnum.AVERAGE,
                >= 6.5 and < 7.5 => AcademicPerformanceRatingEnum.WELL,
                >= 7.5 and < 9 => AcademicPerformanceRatingEnum.GOOD,
                _ => AcademicPerformanceRatingEnum.EXCELLENT,
            };
        }
    }
}
