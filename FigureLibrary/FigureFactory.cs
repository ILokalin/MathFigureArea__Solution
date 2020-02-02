using System;

namespace FigureLibrary 
{
    public class FigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(double radius)
        {
            return new Circle(radius);
        }

        public IFigure CreateFigure(double sideA, double sideB, double sideC)
        {
            return new Triangle(sideA, sideB, sideC);
        }

        public IFigure CreateFigure(double[] sides)
        {
            return new Circle();
        }

        public override string ToString()
        {
            return "IFigureFactory";
        }
    }
}
