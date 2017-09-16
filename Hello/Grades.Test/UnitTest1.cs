using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hello;

namespace Grades.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GradeBook book1 = new GradeBook();
            book1.AddGrade(21);
            book1.AddGrade(22);
            book1.AddGrade(23);
            var stats = book1.ComputeStatistics();
            Assert.AreEqual(22, stats.AverageGrade);
            Assert.AreEqual(21, stats.LowestGrade);
            Assert.AreEqual(23, stats.HighestGrade);

        }

        [TestMethod]
        public void refandout()
        {
            int x =10;
            IncrementNumber(ref x);
        }

        public void IncrementNumber(ref int x)
        {
            //x = 10;
            x += 1;
        }
    }
}
