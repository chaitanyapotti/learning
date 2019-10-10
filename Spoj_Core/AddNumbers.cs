using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spoj_Core
{
    class AddNumbers
    {
        public AddNumbers()
        {
            Init();
        }

        public void Init()
        {
            var array1 = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Execute(array1);
            Console.Read();
        }

        public void Execute(string[] numberStrings)
        {
            var smallString = numberStrings[0].Length >= numberStrings[1].Length ? numberStrings[1].Reverse().ToArray() : numberStrings[0].Reverse().ToArray();
            var largeString = numberStrings[0].Length < numberStrings[1].Length ? numberStrings[1].Reverse().ToArray() : numberStrings[0].Reverse().ToArray();
            int carryOver = 0;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < smallString.Length; i++)
            {
                var sum = int.Parse(largeString[i].ToString()) + int.Parse(smallString[i].ToString()) + carryOver;
                carryOver = sum / 10;
                str.Append(sum);
                //Console.Write(sum);
            }
            for (int i = smallString.Length; i < largeString.Length; i++)
            {
                var sum = carryOver + int.Parse(largeString[i].ToString());
                carryOver = sum / 10;
                str.Append(sum);
                //Console.Write(sum);
            }
            //Console.Write(carryOver);
            str.Append(carryOver);
            foreach (var character in str.ToString().Reverse())
            {
                Console.Write(character);
            }

        }
    }
}
