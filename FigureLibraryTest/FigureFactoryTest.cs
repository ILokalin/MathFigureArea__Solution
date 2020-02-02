using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureLibrary;

namespace FigureLibraryTest
{
    [TestClass]
    public class FigureFactoryTest
    {
        [TestMethod]
        public void FigureFactoryConstructortest()
        {
            IFigureFactory figureFactory = new FigureFactory();
            Assert.AreEqual(figureFactory.ToString(), "IFigureFactory");
        }

        [TestMethod]
        public void FigureCreateTest()
        {
            IFigure figureCircle = new Circle();
            Assert.AreEqual(figureCircle.ToString(), "circle");

            IFigure figureTriangle = new Triangle();
            Assert.AreEqual(figureTriangle.ToString(), "triangle");
        }

        [TestMethod]
        public void DifferentFigureCreateTest()
        {
            IFigureFactory figureFactory = new FigureFactory();
            Assert.AreEqual(figureFactory.ToString(), "IFigureFactory");

            IFigure figureCircle = figureFactory.CreateFigure(5);
            Assert.AreEqual(figureCircle.ToString(), "circle");

            IFigure figureTriangle = figureFactory.CreateFigure(5, 5, 5);
            Assert.AreEqual(figureTriangle.ToString(), "triangle");
        }

        [TestMethod]
        public void CreateFigureFromList()
        {
            List<SFigureTest> figureList = new List<SFigureTest>();
            IFigureFactory figureFactory = new FigureFactory();

            figureList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckName = "triangle" });

            figureList.ForEach(delegate (SFigureTest figure)
            {
                var (sides, checkArea, checkName, checkWeight) = figure;
                IFigure testFigure = figureFactory.CreateFigure(sides);
                Assert.AreEqual(testFigure.ToString(), checkName);
            });
        }

        [TestMethod]
        public void СheckAreaFromList()
        {
            List<SFigureTest> figureList = new List<SFigureTest>();
            IFigureFactory figureFactory = new FigureFactory();

            figureList.Add(new SFigureTest() { Sides = new double[] { 5 }, CheckArea = 78.539816, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 2 }, CheckArea = 12.566371, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7 }, CheckArea = 153.93804, CheckName = "circle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 13, 5, 14 }, CheckArea = 32.496154, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 5, 5, 5 }, CheckArea = 10.825318, CheckName = "triangle" });
            figureList.Add(new SFigureTest() { Sides = new double[] { 7, 3, 9 }, CheckArea = 8.785642, CheckName = "triangle" });

            figureList.ForEach(delegate (SFigureTest figure)
            {
                var (sides, checkArea, checkName, checkWeight) = figure;
                IFigure testFigure = figureFactory.CreateFigure(sides);
                Assert.AreEqual(testFigure.Area, checkArea, 0.0001 );
            });
        }

        [TestMethod]
        public void СheckWithChgangeSidesList()
        {
            IFigureFactory figureFactory = new FigureFactory();
            
            IFigure testCircle = figureFactory.CreateFigure(1);
            Assert.AreEqual(testCircle.Area, 3.14159, 0.0001);

            testCircle.FigureSides = new double[] { 2 };
            Assert.AreEqual(testCircle.Area, 12.566371, 0.0001);
            Assert.AreEqual(testCircle.Type, "circle");

            IFigure testTriangle = figureFactory.CreateFigure(7, 3, 9);
            Assert.AreEqual(testTriangle.Area, 8.785642, 0.0001);
            
            testTriangle.FigureSides = new double[] { 13, 5, 14 };
            Assert.AreEqual(testTriangle.Area, 32.496154, 0.0001);
            Assert.AreEqual(testTriangle.Type, "triangle");
        }
    }
}
