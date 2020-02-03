using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLibrary;
using System.Linq;

namespace FigureLibraryTest
{
    [TestClass]
    public class SeriveseTest
    {
        struct SDoubleArray
        {
            public double[] CheckArray;
            public double[] ResultArray;
            public double ResultSum;
        }

        [TestMethod]
        public void TestSortServise()
        {
            List<SDoubleArray> arraysList = new List<SDoubleArray>();

            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 45, 12, 4.8, 38.89783, 74 }, ResultArray = new double[] { 4.8, 12, 38.89783, 45, 74 } });
            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 2, 36.4354, 5, 17, 0 }, ResultArray = new double[] { 0, 2, 5, 17, 36.4354 } });
            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 45, 12 }, ResultArray = new double[] { 12, 45 } });
            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 45 }, ResultArray = new double[] { 45 } });
            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 45, 12, 4.8 }, ResultArray = new double[] { 4.8, 12, 45 } });

            arraysList.ForEach(delegate (SDoubleArray testItem)
            {
                Service.arraySort(testItem.CheckArray);
                IStructuralEquatable CompareArray = testItem.CheckArray;
                bool result = CompareArray.Equals(testItem.ResultArray, StructuralComparisons.StructuralEqualityComparer);

                string stringArray = "";

                foreach (var item in testItem.CheckArray)
                {
                    stringArray += item.ToString() + " ";
                }

                Assert.AreEqual(result, true, String.Format("Sort array {0} fail", stringArray));
            });
        }

        [TestMethod]
        public void TestSumService()
        {
            List<SDoubleArray> arraysList = new List<SDoubleArray>();

            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 4, 6, 5, 5 }, ResultSum = 20 });
            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 1, 2, 5, 4 }, ResultSum = 12 });
            arraysList.Add(new SDoubleArray() { CheckArray = new double[] { 0, 5, 5 }, ResultSum = 10 });

            arraysList.ForEach(delegate (SDoubleArray testItem)
            {
                double result = Service.arraySum(testItem.CheckArray);
                string stringArray = "";

                foreach (var item in testItem.CheckArray)
                {
                    stringArray += item.ToString() + " ";
                }

                Assert.AreEqual(result, testItem.ResultSum, String.Format("Array '{0}' has sum: '{1}'", stringArray, testItem.ResultSum));
            });
        }
    }
}
