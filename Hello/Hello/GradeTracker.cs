using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public abstract class GradeTracker : object, IGradeTracker
    {
        public abstract void AddGrade(double grade);

        public abstract GradeStatistics ComputeStatistics();

        public abstract string Name { get; set; }

        public abstract IEnumerator GetEnumerator();
    }
}
