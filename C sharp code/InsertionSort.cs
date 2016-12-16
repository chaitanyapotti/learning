using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_code
{
    public class InsertionSort
    {
        public List<int> Sort(List<int> arr) 
        {

            //arr.Sort();
            int leng = arr.Count;
            for (int i = 1 ; i < leng; i++)
            {
                int key = arr[i];
                for (int j = 0; j < i; j++)
                {
                    int val = arr[j];
                    if(key < arr[j])
                    {
                        arr[j] = key;
                        arr[j + 1] = val;

                    }
                }
            }
            return arr;
        }
    }
}
