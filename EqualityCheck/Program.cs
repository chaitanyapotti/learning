using System;
using System.Collections;
using System.Threading;

namespace EqualityCheck
{
    internal class Program
    {
        public static void Main()
        {
            Food[] food =
            {
                new Food("banana", FoodGroup.Fruit),
                new Food("apple", FoodGroup.Fruit),
                new Food("pear", FoodGroup.Fruit),
                new Food("orange", FoodGroup.Fruit)
            };
            string[] arr = { "orange", "banana", "apple", "pear" };
            Array.Sort(food, new FoodNameComparer());
            foreach (var item in food)
            {
                Console.WriteLine(item);
            }

            //OldCode();

        }

        private static void OldCode()
        {
            var output = string.Compare("lemon", "lime", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(output);
            Console.WriteLine(Thread.CurrentThread.CurrentCulture);
            var apple = new Food("apple", FoodGroup.Fruit);
            CookedFood stewedApple = new CookedFood("stewed", "apple", FoodGroup.Fruit);
            Console.WriteLine(apple);
            Console.WriteLine(stewedApple);
            var banana = new Food("banana", FoodGroup.Fruit);
            Food banana2 = banana;
            Console.WriteLine(banana2?.Equals(banana));
            string str1 = "banana";
            string str2 = string.Copy(str1);
            DisplayWhetherArgsEqual(str1, str2);
            var apple2 = "apple";
            var pear = "pear";
            DisplayOrder(apple2, pear);
        }

        static void DisplayWhetherArgsEqual<T>(T x, T y) where T : class => Console.WriteLine("Equal? " + (x == y));

        static void DisplayOrder<T>(T x, T y) where T : IComparable<T>
        {
            int result = x.CompareTo(y);
            if (result == 0) Console.WriteLine($"{x} = {y}");
            else if (result > 0) Console.WriteLine($"{x} > {y}");
            else Console.WriteLine($"{x} < {y}");

        }
    }
}
