using System;

namespace Spoj
{
    public class HS12HDPW
    {
        public HS12HDPW()
        {
            Init();
        }

        public void Init()
        {
            int casesCount = 0;
            int.TryParse(Console.ReadLine(), out casesCount);
            for (int i = 0; i < casesCount; i++)
            {
                int objectCount = 0;
                int.TryParse(Console.ReadLine(), out objectCount);
                string[] codeArray = Console.ReadLine().Split(' ');
                string message = Console.ReadLine();
                Execute(codeArray, message);
            }
        }

        public void Execute(string[] codeArray, string message)
        {
            foreach (string code in codeArray)
            {
                int index = 0;
                for (int i = 0; i < 6; i++)
                {
                    index |= code[i] & (1 << i);
                }
                Console.Write(message[index]);
                index = 0;
                for (int j = 0; j < 3; ++j)
                {
                    index |= (code[j] & (1 << (j + 3))) >> 3;
                }
                for (int j = 3; j < 6; ++j)
                {
                    index |= (code[j] & (1 << (j - 3))) << 3;
                }
                Console.Write(message[index]);

            }
            Console.Write("\n");
        }

    }

}
