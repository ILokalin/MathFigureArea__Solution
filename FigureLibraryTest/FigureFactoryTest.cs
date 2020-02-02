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

            figureList.Add(new SFigureTest() { Sides = new double[] { 4 }, CheckName = "circle"});
            figureList.Add(new SFigureTest() { Sides = new double[] { 4, 5, 6 }, CheckName = "triangle" });

            figureList.ForEach(delegate (SFigureTest figure)
            {
                var (sides, checkArea, checkName, checkWeight) = figure;
                IFigure testFigure = figureFactory.CreateFigure(sides);
                Assert.AreEqual(testFigure.ToString(), checkName);
            });
                
        }
    }
}
