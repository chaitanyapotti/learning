using System.Collections;

namespace Hello
{
    public interface IGradeTracker : IEnumerable
    {
        void AddGrade(double grade);

        GradeStatistics ComputeStatistics();

        string Name { get; set; }

    }
}