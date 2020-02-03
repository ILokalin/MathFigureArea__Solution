using System;
using System.Collections.Generic;
using FigureLibrary;

namespace DemoApp
{
    class Demo
    {
        static void Main(string[] args)
        {
            List<double[]> figureList = new List<double[]>();

            IFigureFactory figureFactory = new FigureFactory();

            figureList.Add(new double[] { 5 });
            figureList.Add(new double[] { 2 });
            figureList.Add(new double[] { 7 });
            figureList.Add(new double[] { 13, 5, 14 });
            figureList.Add(new double[] { 5, 5, 5 });
            figureList.Add(new double[] { 7, 3, 9 });
            figureList.Add(new double[] { 3, 4, 5 });
            figureList.Add(new double[] { 12 });
            figureList.Add(new double[] { 7, 11, 5 });
            figureList.Add(new double[] { 5, 12, 13 });
            figureList.Add(new double[] { 3 });
            figureList.Add(new double[] { 27, 36, 45 });
            figureList.Add(new double[] { 14, 15, 5 });

                figureList.ForEach(delegate (double[] figureParams)
            {
                IFigure figure = figureFactory.CreateFigure(figureParams);
                Console.WriteLine(String.Format("Figure {0, 10} with area equals {1, 20} //Properties: rectangular - {2, 5}", figure.ToString(), figure.Area, figure.Rectangular()));
            });


            double[] setA = { 3, 7, 9 };
            double[] setB = { 7, 9, 3 };

            string stringA = "";
            string stringB = "";

            foreach (var side in setA)
            {
                stringA += side.ToString() + " ";
            }

            foreach (var side in setB)
            {
                stringB += side.ToString() + " ";
            }

            IFigure figureA = figureFactory.CreateFigure(setA);
            IFigure figureB = figureFactory.CreateFigure(setB);

            if (figureA.Equals(figureB))
            {
                Console.WriteLine(String.Format("\nCompare Example. Triangel with side {0} and traingle {1} is Equals", stringA, stringB));
            } else
            {
                Console.WriteLine(String.Format("\nCompare Example. Triangel with side {0} and traingle {1} is not Equals", stringA, stringB));
            }
        }
    }
}
