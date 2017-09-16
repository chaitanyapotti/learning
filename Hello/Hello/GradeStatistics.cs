using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = 100;
            AverageGrade = 0;
        }

        public double AverageGrade;
        public double LowestGrade;
        public double HighestGrade;
    }
}
