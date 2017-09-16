using System.Collections;

namespace Hello
{
    internal interface IGradeTracker : IEnumerable
    {
        void AddGrade(double grade);

        GradeStatistics ComputeStatistics();

        string Name { get; set; }

    }
}