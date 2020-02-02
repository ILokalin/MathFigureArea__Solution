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
                Area = getArea(radius);
            } else
            {
                Type = "not a circle";
            }
        }
        
        public static double getArea(double[] radius)
        {
            return getArea(radius[0]);
        }

        public static double getArea(double radius)
        {
            if (CircleValidate(radius))
            {
                return AreaCalculate(radius);
            } else {
                return 0;
            }
        }

        public override string ToString()
        {
            return Type;
        }

        private static bool CircleValidate(double radius)
        {
            bool result = false;
            if (radius >= 0)
            {
                result = true;
            } else
            {
                throw new NotValidateException("Radius cannot be assigned as negative value");
            }

            return result;
        }

        private static double AreaCalculate(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}
