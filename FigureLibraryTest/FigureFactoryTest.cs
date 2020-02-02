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


        }
    }
}
