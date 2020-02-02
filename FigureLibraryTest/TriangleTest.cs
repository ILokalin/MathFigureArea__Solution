using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLibrary;

namespace FigureLibraryTest
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void circleConstructor()
        {
            Triangle testCircle = new Triangle();
            Assert.AreEqual(testCircle.ToString(), "triangle");

            Triangle testCircleWithValue = new Triangle(5, 5, 5);
            Assert.AreEqual(testCircleWithValue.ToString(), "triangle");

            Triangle testCircleWithArray = new Triangle(new double[] { 5, 5, 5 });
            Assert.AreEqual(testCircleWithArray.ToString(), "triangle");
        }
    }
}
