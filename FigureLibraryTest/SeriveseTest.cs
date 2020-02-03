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
        }

        [TestMethod]
        public void testSortServise()
        {
            List<SDoubleArray> testArrays = new List<SDoubleArray>();

            testArrays.Add(new SDoubleArray() { CheckArray = new double[] { 45, 12, 4.8, 38.89783, 74 }, ResultArray = new double[] { 4.8, 12, 38.89783, 45, 74 } });
            testArrays.Add(new SDoubleArray() { CheckArray = new double[] { 2, 36.4354, 5, 17, 0 }, ResultArray = new double[] { 0, 2, 5, 17, 36.4354 } });
            //testArrays.Add(new SDoubleArray() { CheckArray = new double[] { 45, 12 }, ResultArray = new double[] { 12, 45 } });
            //testArrays.Add(new SDoubleArray() { CheckArray = new double[] { 45 }, ResultArray = new double[] { 45 } });
            testArrays.Add(new SDoubleArray() { CheckArray = new double[] { 45, 12, 4.8 }, ResultArray = new double[] { 4.8, 12, 45 } });

            testArrays.ForEach(delegate (SDoubleArray CompareArrays)
            {
                Service.arraySort(CompareArrays.CheckArray);
                IStructuralEquatable ComparePartCheck =CompareArrays.CheckArray;
                bool result = ComparePartCheck.Equals(CompareArrays.ResultArray, StructuralComparisons.StructuralEqualityComparer);

                string stringArray = "";

                foreach (var item in CompareArrays.CheckArray)
                {
                    stringArray += item.ToString() + " ";
                }

                Assert.AreEqual(result, true, String.Format("Sort array {0} fail", stringArray));
            });
        }
    }
}
