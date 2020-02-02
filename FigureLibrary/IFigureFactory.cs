﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLibrary
{
    public interface IFigureFactory
    {
        IFigure CreateFigure(double radius);

        IFigure CreateFigure(double[] sides);

        IFigure CreateFigure(double sideA, double sideB, double sideC);
    }
}
