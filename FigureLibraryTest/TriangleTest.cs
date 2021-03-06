﻿using FigureLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FigureLibraryTest
{
    [TestClass]
    public class TriangleTest
    {
        double Delta = 0.0001;

        [TestMethod]
        public void triangleConstructor()
        {
            Triangle testCircle = new Triangle();
            Assert.AreEqual(testCircle.ToString(), "triangle");

            Triangle testCircleWithValue = new Triangle(5, 5, 5);
            Assert.AreEqual(testCircleWithValue.ToString(), "triangle");

            Triangle testCircleWithArray = new Triangle(new double[] { 5, 5, 5 });
            Assert.AreEqual(testCircleWithArray.ToString(), "triangle");
        }

        [TestMethod]
        public void triangleException()
        {
            try
            {
                Triangle testCircleNotACircle = new Triangle(5, 15, 55);
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "One of the sides too long");
            }

            try
            {
                Triangle testCircleNotACircle = new Triangle(new double[] { 3, 4 });
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Too few parameters for sides");
            }

            try
            {
                Triangle testCircleNotACircle = new Triangle(new double[] { 3, 4, 7, 3 });
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Too many parameters for sides");
            }

            try
            {
                Triangle testCircleNotACircle = new Triangle(new double[] { 0, 4, 4 });
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "One of the side has bad size (0 or negative)");
            }

            try
            {
                Triangle testCircleNotACircle = new Triangle(new double[] { -5, 4, 4 });
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "One of the side has bad size (0 or negative)");
            }
        }

        [TestMethod]
        public void TriangleGetArea()
        {
            List<SFigureTest> triangleList = new List<SFigureTest>();

            triangleList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckArea = 32.496154 });
            triangleList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckArea = 10.825318 });
            triangleList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckArea = 8.785642 });

            triangleList.ForEach(delegate (SFigureTest triangleTest)
            {
                var (sides, checkArea, checkName, checkWeight) = triangleTest;
                double result = Triangle.GetArea(sides);
                Assert.AreEqual(result, checkArea, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", sides[0], sides[1], sides[2]));
            });
        }


        [TestMethod]
        public void triangleLetsSides()
        {
            Triangle testTriangle = new Triangle();
            Assert.AreEqual(testTriangle.ToString(), "triangle");

            testTriangle.FigureSides = new double[] { 13, 5, 14 };
            Assert.AreEqual(testTriangle.Area, 32.496154, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", 13, 5, 14));

            testTriangle.Set(new double[] { 7, 3, 9 });
            Assert.AreEqual(testTriangle.Area, 8.785642, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", 7, 3, 9));

            try
            {
                testTriangle.Set(5);
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Too few parameters for Triangle");
            }

            testTriangle.Set(5, 5, 5);
            Assert.AreEqual(testTriangle.Area, 10.825318, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", 5, 5, 5));
        }

        [TestMethod]
        public void TriangleWorkWitObject()
        {
            List<SFigureTest> triangleList = new List<SFigureTest>();

            triangleList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckArea = 32.496154 });
            triangleList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckArea = 10.825318 });
            triangleList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckArea = 8.785642 });

            triangleList.ForEach(delegate (SFigureTest triangleTest)
            {
                var (sides, checkArea, checkName, checkWeight) = triangleTest;
                Triangle testTriangle = new Triangle(sides);
                Assert.AreEqual(testTriangle.Area, checkArea, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", sides[0], sides[1], sides[2]));
            });
        }

        [TestMethod]
        public void TriangleUpdateAreaTest()
        {
            Triangle testTriangle = new Triangle();

            double result = testTriangle.UpdateArea(5, 5, 5);
            Assert.AreEqual(result, 10.825318, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", 5, 5, 5));

            result = testTriangle.UpdateArea(new double[] { 13, 5, 14 });
            Assert.AreEqual(result, 32.496154, Delta, String.Format("Triangle with sides '{0}, {1}, {2}' ", 13, 5, 14));

            try
            {
                result = testTriangle.UpdateArea(new double[] { 13 });
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Too few parameters for sides");
            }

            try
            {
                result = testTriangle.UpdateArea(13);
                Assert.Fail("An exception should have been throw");
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Too few parameters for Triangle");
            }
        }

        [TestMethod]
        public void CompareTriangleTest()
        {
            Triangle triangleA = new Triangle(15, 15, 9);
            Triangle triangleB = new Triangle(17, 15, 4);

            bool result = triangleA < triangleB;
            Assert.AreEqual(result, false, "The area of triangle A should have been not smaller.");

            triangleB.Set(5, 5, 5);
            result = triangleA > triangleB;
            Assert.AreEqual(result, true, "The area of triangle A should have been larger.");

            result = triangleA != triangleB;
            Assert.AreEqual(result, true, "The area of triangles should have been not equal.");

            triangleA.Set(5, 5, 5);
            result = triangleA >= triangleB;
            Assert.AreEqual(result, true, "The area of triangles should have been equal.");

            result = triangleA <= triangleB;
            Assert.AreEqual(result, true, "The area of triangles should have been equal.");

            result = triangleA == triangleB;
            Assert.AreEqual(result, true, "The area of triangles should have been equal.");

            result = triangleA.Equals(triangleB);
            Assert.AreEqual(result, true, "The sides of triangles should have been equal.");

            triangleA.Set(4, 5, 4);
            result = triangleA.Equals(triangleB);
            Assert.AreEqual(result, false, "The area of triangles should have not been equal.");
        }
    }
}
