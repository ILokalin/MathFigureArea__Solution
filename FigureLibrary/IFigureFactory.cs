using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLibrary
{
    public interface IFigureFactory
    {
        IFigure CreateFigure(int type);
    }
}
