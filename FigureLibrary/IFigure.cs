using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLibrary
{
    public interface IFigure
    {
        double Area { get; }

        string Type { get; }

        double[] FigureSides { get; set; }

        void Set(double[] sides);

        void Set(double side);
    }
}
