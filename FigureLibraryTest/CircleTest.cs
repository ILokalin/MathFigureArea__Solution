using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLibrary;

namespace FigureLibraryTest
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void circleConstructor()
        {
            Circle testCircle = new Circle();
            Assert.AreEqual(testCircle.ToString(), "circle");

            Circle testCircleWithValue = new Circle(5);
            Assert.AreEqual(testCircleWithValue.ToString(), "circle");

            Circle testCircleWithArray = new Circle(new double[] { 5 });
            Assert.AreEqual(testCircleWithArray.ToString(), "circle");

            Circle testCircleNotACircle = new Circle( -5 );
            Assert.AreEqual(testCircleNotACircle.ToString(), "not a circle");
        }
    }
}
