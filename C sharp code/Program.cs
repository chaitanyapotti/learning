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
            //Intersections();
            SpiralMatrix();
            //DecodedMessaged();
            //Dp();
            //dp.Max();
            //List<int> len = new List<int>();
            //for (int index = 0; index < arr.Count; index++)
            //{
            //    len.Add(GetGreaterElementsCount(arr, index));
            //}
            //Console.WriteLine(len.Max());
            //InsertionSortTest();
        }

        private static void SpiralMatrix()
        {
            int numRows = 0;
            while (numRows <= 0)
            {
                Console.WriteLine("Enter a valid number for the size of a square matrix: ");
                string number = Console.ReadLine();
                int.TryParse(number, out numRows);
            }
            int[,] abc = new int[numRows, numRows];
            int startElem = 0;
            bool direction = true;
            for (int i = 0; i < numRows; i++)
            {
                RowFilling(numRows, i, startElem, abc, direction);
                direction = !direction;
            }

        }

        private static void RowFilling(int numRows, int rowNum, int startElement, int[,] abc, bool direction)
        {
            if (direction)
                for (int i = 0; i < numRows; i++)
                {
                    if (abc[rowNum, i] == 0)
                        abc[rowNum, i] = startElement + 1;
                }
            else
                for (int i = numRows - 1; i >= 0; i--)
                {
                    if (abc[rowNum, i] == 0)
                        abc[rowNum, i] = startElement + 1;
                }
        }
        private static void ColumnFilling(int numRows, int colNum, int startElement, int[,] abc, bool direction)
        {
            if (direction)
                for (int i = 0; i < numRows; i++)
                {
                    if (abc[i, colNum] == 0)
                        abc[i, colNum] = startElement + 1;
                }
            else
                for (int i = numRows - 1; i >= 0; i--)
                {
                    if (abc[i, colNum] == 0)
                        abc[i, colNum] = startElement + 1;
                }
        }

        private static void Intersections()
        {

            // Do not change or remove the below Console input.
            string str_Ropes = Console.ReadLine();
            int num_Ropes = Int32.Parse(str_Ropes);

            char[] sep = { };
            string[] inputs;

            string str_line;
            int[,] ropeConnections = new int[num_Ropes, 2];

            for (int i = 0; i < num_Ropes; i++)
            {
                //Do not change or remove the below Console input.
                str_line = Console.ReadLine();
                inputs = str_line.Split(sep);

                for (int j = 0; j < 2; j++)
                {
                    ropeConnections[i, j] = Int32.Parse(inputs[j]);
                }
            }

            int numIntersection = FindIntersections(num_Ropes, ropeConnections);

            // Do not change or remove the below Console output.
            Console.WriteLine(numIntersection.ToString());
        }

        private static void DecodedMessaged()
        {
            // Do not change or remove the below Console input.
            string cipherMessage =
                "999_6666666_88_0000000_7777_33_33_6__0_8_666_0_44_2_888_33_0_88_66_3_33_777_7777_8_666_666_3_0_44_666_9_0_8_44_444_7777_0_777777777777_88_33_7777_8_444_666_66_0_9_666_777_55_7777";
            string decodedMessage = DecodeMessage(cipherMessage);

            // Do not change or remove the below Console output.
            Console.WriteLine(decodedMessage);
        }

        public static string DecodeMessage(string cipherMessage)
        {
            // Implement your logic here to decode the message.
            string[] msg = cipherMessage.Split('_');
            StringBuilder str = new StringBuilder();
            foreach (var character in msg)
            {
                if (string.IsNullOrEmpty(character)) continue;
                int count = character.Length;
                switch (character[0])
                {
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                        double number = 0;
                        double.TryParse(character[0].ToString(), out number);
                        if (count % 4 == 0) str.Append(character[0]);
                        else str.Append((char)((int)character[0] + 46 + (number - 2) * 2 + count % 4));
                        break;
                    case '7':
                        if (count % 5 == 0) str.Append(character[0]);
                        else str.Append((char)((int)character[0] + 56 + count % 5));
                        break;
                    case '8':
                        if (count % 4 == 0) str.Append(character[0]);
                        else str.Append((char)((int)character[0] + 59 + count % 4));
                        break;
                    case '9':
                        if (count % 5 == 0) str.Append(character[0]);
                        else str.Append((char)((int)character[0] + 61 + count % 5));
                        break;
                    case '1':
                        str.Append(count % 2 == 0 ? character[0] : '.');
                        break;
                    case '0':
                        str.Append(count % 2 == 0 ? character[0] : ' ');
                        break;
                }
                //str.Append();
            }
            return str.ToString();
        }
        public static int FindIntersections(int num_Ropes, int[,] ropeConnections)
        {
            int numIntersection = -1;
            int count = 0;
            // Implement your logic here to find the number of intersections.
            for (int i = 0; i <= num_Ropes - 1; i++)
            {
                for (int j = i; j <= num_Ropes - 1; j++)
                {
                    if (ropeConnections[i, 0] > ropeConnections[j, 0] && ropeConnections[i, 1] <= ropeConnections[j, 1]
                        || ropeConnections[i, 0] >= ropeConnections[j, 0] && ropeConnections[i, 1] < ropeConnections[j, 1]
                        || ropeConnections[i, 0] < ropeConnections[j, 0] && ropeConnections[i, 1] >= ropeConnections[j, 1]
                        || ropeConnections[i, 0] <= ropeConnections[j, 0] && ropeConnections[i, 1] > ropeConnections[j, 1]) count++;
                }
            }
            numIntersection = count;
            return numIntersection;
        }
        public static char DecodedCharacter(string number)
        {
            char a = ' ';
            //if (number.Contains('1') && number)
            return a;
        }

        private static void Dp()
        {
            var arr = new List<int> { 0, 15, 27, 14, 38, 26, 55, 46, 65, 85 };
            //arr = new List<int> { 15, 27, 28, 16, 17, 18, 19 };
            int[] dp = new int[arr.Count];

            dp[0] = 0;
            dp[1] = 1;
            for (int i = 2; i <= 9; i++)
            {
                dp[i] = 0;
                for (int j = 1; j < i; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                        }
                    }
                }
            }
            Console.WriteLine(dp.Max());
        }

        private static int GetGreaterElementsCount(List<int> arr, int index)
        {
            int count = 0;
            for (int i = index; i < arr.Count; i++)
            {
                if (arr[i] >= arr[index])
                {
                    count++;
                    index = i;
                }
            }
            return count;
            //throw new NotImplementedException();
        }

        private static void InsertionSortTest()
        {
            List<int> arr = new List<int> { 1, 3, 24, 12, 46, 32 };
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
