using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FigureLibrary
{
    public class Triangle
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public double Area { get; }

        /// <summary>
        /// Конструктор Triangle
        /// </summary>
        public Triangle() : this(0, 0, 0) { }

        /// <summary>
        /// Конструктор Triangle
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        public Triangle(double sideA, double sideB, double sideC) : this(new double[] { sideA, sideB, sideC }) { }

        /// <summary>
        /// Конструктор Triangle
        /// </summary>
        /// <param name="radius">значение радиуса double[]</param>
        public Triangle(double[] sides) 
        {
            if (TriangleValidate(sidesToList(sides)))
            {
                Type = "triangle";
            }
        }

        public static double getArea(double[] sides)
        {
            return 0;
        }

        /// <summary>
        /// Получить название фигуры
        /// </summary>
        /// <returns>название фигуры string</returns>
        public override string ToString()
        {
            return Type;
        }

        private static List<double> sidesToList(double[] sides)
        {
            List<double> sidesList = new List<double>();
            foreach(var side in sides)
            {
                sidesList.Add(side);
            }

            return sidesList;
        }

        /// <summary>
        /// Валидация треугольника. Фигура соответствует треугольнику если:
        /// - нет сторон больше суммы двух других
        /// - нет сторон с отрицательным значением
        /// - сумма всех сторон равна 0 (создание пустого объкта)
        /// - заданы значения для трех сторон
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        /// <returns>true - треугольник; исключение - при несоответствии</returns>
        private static bool TriangleValidate(List<double> sides)
        {
            double sumOfSides = sides.Sum();
            sides.Sort();

            if (sides.Count < 3)
            {
                throw new NotValidateException("Too few parameters for sides");
            }

            if (sides.Count > 3)
            {
                throw new NotValidateException("Too many parameters for sides"); 
            }

            sides.ForEach(delegate (double side)
            {
                if (side <= 0 & sumOfSides != 0)
                {
                    throw new NotValidateException("One of the side has bad size (0 or negative)");
                }
            });

            if (sides[2] > sides[1] + sides[0] & sumOfSides != 0)
            {
                throw new NotValidateException("One of the sides too long");
            }

            

            return true;
        }
    }
}
