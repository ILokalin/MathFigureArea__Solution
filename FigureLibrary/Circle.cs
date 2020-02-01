using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLibrary
{
    public class Circle
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Площадь круга
        /// </summary>
        public double Area { get; }

        public Circle() : this(0) {}
        
        public Circle(double[] radius) : this(radius[0]) {}

        public Circle(double radius)
        {
            if (CircleValidate(radius))
            {
                Type = "circle";
            } else
            {
                Type = "not a circle";
            }
            
        }

        public override string ToString()
        {
            return Type;
        }

        private bool CircleValidate(double radius)
        {
            bool result = false;
            if (radius >= 0) result = true;

            return result;
        }
    }
}
