using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPA_Calculator
{
    public class Course
    {
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public int CreditHours { get; set; }
        public string Grade { get; set; }
        public int Semester { get; set; }
    }
}
