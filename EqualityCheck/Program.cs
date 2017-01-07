using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityCheck
{
    class Program
    {
        static void Main()
        {
            var apple = new Food("apple", FoodGroup.Fruit);
            CookedFood stewedApple = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            Console.WriteLine(apple);
            Console.WriteLine(stewedApple);
            //var banana = new Food("banana", FoodGroup.Fruit);
            //Food banana2 = null;
            //Console.WriteLine(banana2?.Equals(banana));
            //string str1 = "banana";
            //string str2 = string.Copy(str1);
            //DisplayWhetherArgsEqual(str1, str2);
            
        }
        static void DisplayWhetherArgsEqual<T>(T x, T y) where T:class
        {
            Console.WriteLine("Equal? " + (x==y));
        }
    }
}
