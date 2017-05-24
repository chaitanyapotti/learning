using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProblems
{
    /// <summary>
    /// This class shall perform operations related to Question 1
    /// </summary>
    internal class Question1 : IQuestion
    {
        public void Execute(object input)
        {
            //Arrange Input
            var inputx = input as List<object>;
            var reqInput = inputx?.ElementAt(0) as int[];
            int elementToFind;
            int.TryParse(inputx?.ElementAt(1).ToString(), out elementToFind);
            FindElement(reqInput, elementToFind);
            DeleteElement(reqInput, elementToFind);

        }

        private void DeleteElement(int[] reqInput, int elementToFind)
        {
            var elementIndex = FindElement(reqInput, elementToFind);
            if (!elementIndex.Equals(-1))
            {
                for (int index = elementIndex; index < reqInput.Length - 1; index++)
                {
                    reqInput[index] = reqInput[index + 1];
                }
                reqInput[reqInput.Length - 1] = 0;
            }
            foreach (int i in reqInput)
            {
                Console.WriteLine(i);
            }
        }

        private int FindElement(int[] reqInput, int elementToFind)
        {
            for (int index = 0; index < reqInput.Length - 1; index++)
            {
                if (reqInput[index].Equals(elementToFind))
                {
                    Console.WriteLine($"Element found at position {index + 1}");
                    return index;
                }
            }
            Console.WriteLine($"Element not found");
            return -1;
        }
    }
}
