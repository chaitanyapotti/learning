using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_code
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int> { 1,3,24,12,46,32};
            InsertionSortExample(ref arr);
            
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        private static List<int> InsertionSortExample(ref List<int> arr)
        {
            InsertionSort sort = new InsertionSort();
            //List<int> sortedArray = sort.Sort(arr);
            arr = sort.Sort(arr);
            //arr = new List<int> { 1, 2 };
            return arr;
            //sortedArray = new List<int> { 1,2};
            //return sortedArray;
            //throw new NotImplementedException();
        }
    }
}
