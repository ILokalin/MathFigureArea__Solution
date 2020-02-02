using System;

namespace FigureLibrary 
{
    public class FigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(int type)
        {
            return new Circle();
        }

        public override string ToString()
        {
            return "IFigureFactory";
        }
    }
}
