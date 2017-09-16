using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            double Lowest = double.MaxValue;
            //foreach (float grade in grades)
            //{
            //    Lowest = Math.Min(grade, Lowest);
            //}
            Lowest = grades.Min();
            grades.Remove(Lowest);
            return base.ComputeStatistics();
        }
    }
}
