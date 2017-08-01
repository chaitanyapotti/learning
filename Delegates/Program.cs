using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate int WorkPerformedHandler(int hours, WorkType workType);

    class Program
    {
        static void Main(string[] args)
        {
            WorkPerformedHandler work = WorkPerformed1;
            WorkPerformedHandler work2 = WorkPerformed2;
            WorkPerformedHandler work3 = WorkPerformed3;

            work += work2;
            work += work3;

            int? finalHours = DoWork(work);
            Console.WriteLine(finalHours);

            Worker worker = new Worker();
            worker.WorkCompleted += Worker_WorkCompleted;
            worker.WorkPerformed += Worker_WorkPerformed;
            worker.DoWork(3, WorkType.GenerateReports);
            Console.ReadLine();
        }

        private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("work is being done" + e.WorkType + " " + e.Hours);
        }

        private static void Worker_WorkCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("work is completed");
        }

        static int? DoWork(WorkPerformedHandler del)
        {
            return del?.Invoke(1, WorkType.GenerateReports);
        }

        static int WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerfomed1 Called " + workType.ToString());
            return hours + 1;
        }

        static int WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerfomed2 Called " + hours);
            return hours + 2;

        }

        static int WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine("WorkPerfomed3 Called " + hours);
            return hours + 3;

        }
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
