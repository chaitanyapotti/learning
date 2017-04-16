using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EqualityCheck
{
    internal class Program
    {
        public static void Main()
        {
            //string[] arr1 = { "apple", "orange", "pineapple" };
            //string[] arr2 = { "Apple", "orange", "pineapple" };

            //var arrayEq = (IStructuralEquatable)arr1;
            //bool structEqual = arrayEq.Equals(arr2, StringComparer.OrdinalIgnoreCase);
            //Console.WriteLine(structEqual);

            //var arrayEq2 = (IStructuralComparable)arr1;
            //int structEqual2 = arrayEq2.CompareTo(arr2, StringComparer.Ordinal);
            //Console.WriteLine(structEqual2);
            //DemoComparable();
            //ComparerDemo();

            //OldCode();

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("a", 1);
            dict.Add("b", 3);
            dict.Add("c", 2);
            var xy = dict.OrderBy(x => x.Value);

            foreach (var item in xy)
            {
                Console.WriteLine(item.Value);
            }

        }

        private static void DemoComparable()
        {
            //If we want custom equality comparision just here, implement IEqualityComparer just here

            var foodItems = new HashSet<FoodItem>(FoodItemEqualityComparer.Instance)
            {
                new FoodItem("apple", FoodGroup.Fruit),
                new FoodItem("banana", FoodGroup.Fruit),
                new FoodItem("pear", FoodGroup.Fruit),
                new FoodItem("Pear", FoodGroup.Fruit)
            };


            foreach (var item in foodItems)
            {
                Console.WriteLine(item);

            }
        }

        private static void ComparerDemo()
        {
            Food[] food =
            {
                new Food("banana", FoodGroup.Fruit),
                new Food("apple", FoodGroup.Fruit),
                new Food("pear", FoodGroup.Fruit),
                new Food("orange", FoodGroup.Fruit)
            };
            string[] arr = { "orange", "banana", "apple", "pear" };
            Array.Sort(food, FoodNameComparer.Instance);
            foreach (var item in food)
            {
                Console.WriteLine(item);
            }
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
