using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lesson1();
            Lesson2();
            //Lesson3();
            //SpeechSynthesizer spea = new SpeechSynthesizer();
            //spea.Speak("Hello. This is a test");
        }

        private static void Lesson3()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;
            g1.NameDelegate += new NameChangedDelegate(OnNameChanged);
            g1.NameDelegate += new NameChangedDelegate(OnNameChanged2);


            g2.NameDelegate2 += OnNameChanged3;

            //InputValue();

            g1.Name = "Scott's Gradebook";
            Console.WriteLine(g2.Name);
            //throw new NotImplementedException();
        }

        private static void InputValue()
        {
            double? val = 0;
            do
            {
                try
                {
                    Console.WriteLine("Enter a number which is not 0 : ");
                    val = Convert.ToDouble(Console.ReadLine());
                    if (val == 0) continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Enter proper number: ");
                    continue;
                }

            } while (val == 0);
        }

        private static void OnNameChanged3(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade Book Name Changing from {args.ExistingName} to {args.NewName}");
            //throw new NotImplementedException();
        }

        private static void Lesson2()
        {
            IGradeTracker book = new ThrowAwayGradeBook();
            AddGrade(book);
            GradeStatistics stats = WriteResults(book);

            Console.WriteLine(stats.HighestGrade);
        }

        private static void AddGrade(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5);
            book.AddGrade(75);
        }

        private static GradeStatistics WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();

            foreach (var grade in book)
            {
                Console.WriteLine(grade);
            }


            WriteResult("Average", stats.AverageGrade);
            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.LowestGrade);

            WriteResult("Lowest", (int)stats.LowestGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            return stats;
        }

        public static void WriteResult(string description, double result)
        {
            Console.WriteLine(description + " : " + result);
        }
        public static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + " : " + result);
            Console.WriteLine($"{description}: {result:F2}");

        }
        private static void Lesson1()
        {
            Console.WriteLine("Your Name:");
            string name = Console.ReadLine();

            Console.WriteLine("How many hrs of sleep?");
            int hoursOfSleep;
            int.TryParse(Console.ReadLine(), out hoursOfSleep);
            if (hoursOfSleep >= 8)
            {
                Console.WriteLine("Good Sleep");
            }
            else
            {
                Console.WriteLine("Bad Sleep");
            }
            Console.Read();
            //throw new NotImplementedException();
        }

        public static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"GradeBook Changing Name from {existingName} to {newName}");
        }
        public static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***");
        }
    }
}
