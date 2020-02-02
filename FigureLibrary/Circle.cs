using System;
using System.Collections.Generic;
using System.Text;

namespace FigureLibrary
{
    public class Circle : IFigure
    {
        private double area;

        private double[] figureSides;

        /// <summary>
        /// Функция расчета площади.
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        /// <returns>площадь круга double</returns>
        private static double AreaCalculate(double radius)
        {
            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Валидация круга. Если радиус больше или равен 0 - фигура соответствует.
        /// 0 принят для сохранения возможности создания пустого объекта.
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        /// <returns>true - круг; исключение - при отрицательном радиусе</returns>
        private static bool CircleValidate(double radius)
        {
            bool result = false;
            if (radius >= 0)
            {
                result = true;
            }
            else
            {
                throw new NotValidateException("Radius cannot be assigned as negative value");
            }

            return result;
        }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Площадь круга
        /// </summary>
        public double Area 
        {
            get { return area;  } 
        }

        public double[] FigureSides
        {
            get { return figureSides; }
            set
            {
                double radius = value[0];

                if (value != figureSides)
                {
                    if (CircleValidate(radius))
                    {
                        figureSides =  value;
                        area = AreaCalculate(radius);
                    }
                }
            }
        }


        /// <summary>
        /// Конструктор Circle
        /// </summary>
        public Circle() : this(0) {}

        /// <summary>
        /// Конструктор Circle
        /// </summary>
        /// <param name="radius">значение радиуса double[]</param>
        public Circle(double[] radius) : this(radius[0]) {}

        /// <summary>
        /// Конструктор Circle
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        public Circle(double radius)
        {
            if (CircleValidate(radius))
            {
                Type = "circle";
                area = getArea(radius);
            } else
            {
                Type = "not a circle";
            }
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        /// <param name="radius">значение радиуса double[]</param>
        /// <returns>площадь круга double</returns>
        public static double getArea(double[] radius)
        {
            return getArea(radius[0]);
        }

        /// <summary>
        /// Площадь круга
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        /// <returns>площадь круга double</returns>
        public static double getArea(double radius)
        {
            if (CircleValidate(radius))
            {
                return AreaCalculate(radius);
            } else {
                return 0;
            }
        }

        /// <summary>
        /// Получить название фигуры
        /// </summary>
        /// <returns>название фигуры string</returns>
        public override string ToString()
        {
            return Type;
        }
    }
}
