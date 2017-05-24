using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Problem1();
        }

        private static void Problem1()
        {
            //Search, Insert, delete in an unsorted array

            //Generate input format
            var input = new List<object> { new int[] { 12, 34, 10, 6, 40 }, 6 };
            //Execute
            var q1 = new Question1();
            q1.Execute(input);
        }
    }
}
