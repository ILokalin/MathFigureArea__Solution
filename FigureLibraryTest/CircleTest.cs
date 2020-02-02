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
        }

        [TestMethod]
        public void circleException()
        {
            try
            {
                Circle testCircleNotACircle = new Circle(-5);
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Radius cannot be assigned as negative value");
            }
        }

        [TestMethod]
        public void circleAreaTest()
        {
            List<SFigureTest> circleList = new List<SFigureTest>();

            circleList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckArea = 78.539816 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckArea = 12.566371 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckArea = 153.93804 });

            circleList.ForEach(delegate (SFigureTest circle)
            {
                var (sides, checkArea, checkName, checkWeight) = circle;
                double result = Circle.getArea(sides);
                Assert.AreEqual(result, checkArea, 0.0001, String.Format("Circle with radius '{0}'", sides[0]));
            });
        }

        [TestMethod]
        public void circleAreayObjectTest()
        {
            List<SFigureTest> circleList = new List<SFigureTest>();

            circleList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckArea = 78.539816 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckArea = 12.566371 });
            circleList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckArea = 153.93804 });

            circleList.ForEach(delegate (SFigureTest circle)
            {
                var(sides, checkArea, checkName, checkWeight) = circle;
                Circle circleTest = new Circle(sides);
                Assert.AreEqual(circleTest.Area, checkArea, 0.0001, String.Format("Circle with radius '{0}'", sides[0]));
            });
        }

        [TestMethod]
        public void circleTestWithChangeRadius()
        {
            Circle testCircle = new Circle();
            Assert.AreEqual(testCircle.Area, 0, 0.0001, String.Format("Circle with radius '{0}'", 0));

            testCircle.FigureSides = new double[] { 7 };
            Assert.AreEqual(testCircle.Area, 153.93804, 0.0001, String.Format("Circle with radius '{0}'", 7));

            testCircle.Set(new double[] { 2 });
            Assert.AreEqual(testCircle.Area, 12.566371, 0.0001, String.Format("Circle with radius '{0}'", 2));

            testCircle.Set( 5 );
            Assert.AreEqual(testCircle.Area, 78.539816, 0.0001, String.Format("Circle with radius '{0}'", 5));

            try
            {
                testCircle.Set(5, 5, 5);
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Too many parameters for Circle");
            }
        }

        [TestMethod]
        public void CircleTestUpdateArea()
        {
            Circle testCircle = new Circle();

            double result = testCircle.UpdateArea(5);
            Assert.AreEqual(result, 78.539816, 0.0001, String.Format("Circle with radius '{0}'", 5));

            result = testCircle.UpdateArea(new double[] { 7 });
            Assert.AreEqual(result, 153.93804, 0.0001, String.Format("Circle with radius '{0}'", 7));

            //Спорная ситуация - массив для радиуса длиной больше 1. Оставлена логика принтия первого значения
            result = testCircle.UpdateArea(new double[] { 5, 5 });
            Assert.AreEqual(result, 78.539816, 0.0001, String.Format("Circle with radius '{0}'", 5));

            try
            {
                result = testCircle.UpdateArea(4, 4, 4);
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Too much parameters for Circle");
            }
        }

        [TestMethod]
        public void CircleCompareTest()
        {
            Circle circleA = new Circle(5);
            Circle circleB = new Circle(10);

            bool result = circleA > circleB;
            Assert.AreEqual(result, false, "The area of circle A should have not been larger");

            circleA.Set(20);
            result = circleA < circleB;
            Assert.AreEqual(result, false, "The area of circle A should have not been smaller");
            result = circleA != circleB;
            Assert.AreEqual(result, true, "The area of circle A should have not been equal");

            circleB.Set(20);
            result = circleA <= circleB;
            Assert.AreEqual(result, true, "The area of circle A should have been equal.");
            
            result = circleA >= circleB;
            Assert.AreEqual(result, true, "The area of circle A should have been equal.");

            result = circleA == circleB;
            Assert.AreEqual(result, true, "The area of circle A should have been equal.");

            result = circleA.Equals(circleB);
            Assert.AreEqual(result, true, "The radiuses of circles should have been equal.");

            circleB.Set(10);
            result = circleA.Equals(circleB);
            Assert.AreEqual(result, false, "The radiuses of circles should have not been equal.");
        }
    }
}
