using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLibrary;

namespace BasicArrayOps
{
    class Program
    {
        static void Main(string[] args)
        {
            var monday = "Monday";
            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            var bigCities = new HashSet<string>(new StringEqualityComparer())
                {"Beijing", "NY", "Sheffield", "Paris", "ny"};

            //foreach (var bigCity in bigCities)
            //{
            //    Console.WriteLine(bigCity);
            //}
            DisplayItems(bigCities);

            PeopleRepository repo = new PeopleRepository();

            IStructuralComparable arr1 = repo.People2;
            Console.WriteLine(arr1.CompareTo(repo.People3, Comparer<Person>.Default));

            //Dictionaries();

            //Stacks();

            //Linkedlist();


            //oldCode(daysOfWeek);
            //Code2(daysOfWeek);
            //OldCode2(daysOfWeek);

        }

        public static void DisplayItems<T>(IEnumerable<T> collection)
        {
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                bool moreItems = enumerator.MoveNext();
                while (moreItems)
                {
                    Console.WriteLine(enumerator.Current);
                    moreItems = enumerator.MoveNext();
                }
            }
        }

        public class AllDaysOfWeek : IEnumerable<string>
        {
            public IEnumerator<string> GetEnumerator()
            {
                yield return "Monday";
                yield return "Tuesday";
                yield return "Wednesday";
                //throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private static void Dictionaries()
        {
            var primeMinisters = new Dictionary<string, PrimeMinister>(new StringEqualityComparer())
            {
                {"JC", new PrimeMinister(1976, "Callaghan")} ,
                {"MT", new PrimeMinister(1979, "Margaret")} ,
                {"TB",new PrimeMinister(1997, "Blair") }
            };


            var primeMinisters2 = new SortedList<string, PrimeMinister>(new StringKeyComparer())
            {
                {"JC", new PrimeMinister(1976, "Callaghan")} ,
                {"TM", new PrimeMinister(1979, "Margaret")} ,
                {"TB",new PrimeMinister(1977, "Blair") }
            };

            foreach (var primeMinister in primeMinisters2)
            {
                Console.WriteLine(primeMinister);
            }

            PrimeMinister pm = primeMinisters["tb"];
            Console.WriteLine(pm);

            bool found = primeMinisters.TryGetValue("jc", out pm);

            Console.WriteLine(found ? $"value is {pm}" : "Value not in dictionary");

            foreach (var primeMinister in primeMinisters)
            {
                Console.WriteLine(primeMinister);
            }
        }

        private static void Stacks()
        {
            Stack<string> books = new Stack<string>();
            books.Push("a");
            books.Push("b");
            books.Push("c");
            books.Push("d");

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            var item = books.Pop();
            var item2 = books.Peek();
            Console.WriteLine("\n" + item2);

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private static void Linkedlist()
        {
            var presidents = new LinkedList<string>();
            presidents.AddLast("JFK");
            presidents.AddLast("Johnson");
            presidents.AddLast("Nixon");
            var carter = presidents.AddLast("Carter");

            LinkedListNode<string> nixon = presidents.Find("Nixon");

            presidents.AddAfter(nixon, "Ford");

            foreach (var president in presidents)
            {
                Console.WriteLine(president);
            }
        }

        private static void OldCode2(string[] daysOfWeek)
        {
            ICollection<string> collection = daysOfWeek;
            if (!collection.IsReadOnly)
                collection.Add("newDay");

            Console.WriteLine(collection.Count);

            List<string> list = daysOfWeek.ToList();
            Console.WriteLine(list.Capacity);
            List<string> list2 = new List<string>(20);
            list2[0] = "reload";
            Console.WriteLine(list2[0]);
        }

        private static void Code2(string[] daysOfWeek)
        {
            Array.Sort(daysOfWeek, StringComparer.OrdinalIgnoreCase);
            int index = Array.FindIndex(daysOfWeek, x => x[0] == 'W');
            var indexes = Array.FindAll(daysOfWeek, x => x.Length == 6);
            int indexofSun = Array.BinarySearch(daysOfWeek, "Sunday", DaysComparer.Instance);
            Console.WriteLine(indexofSun);
            foreach (var item in daysOfWeek)
            {
                Console.WriteLine(item);
            }
        }

        private static void oldCode(string[] daysOfWeek)
        {
            string tuesday = daysOfWeek[1];
            Console.WriteLine(tuesday);
            int[] x5 = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine(daysOfWeek.Contains("monday", StringComparer.CurrentCultureIgnoreCase));
            Console.WriteLine(2 | 10);
        }
    }
}
