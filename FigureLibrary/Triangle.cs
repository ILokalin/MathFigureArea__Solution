using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FigureLibrary
{
    public class Triangle : IFigure
    {
        /// <summary>
        /// Значение площади фигуры
        /// </summary>
        private double area;

        /// <summary>
        /// Значение сторон фигуры
        /// </summary>
        private double[] figureSides;

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public double Area 
        { 
            get { return area; }

        }

        /// <summary>
        /// Стороны фигуры double[]
        /// </summary>
        public double[] FigureSides
        {
            get { return figureSides; }
            set
            {
                if (value != figureSides)
                {
                    List<double> sideList = sidesToList(value);
                    if (TriangleValidate(sideList))
                    {
                        figureSides = value;
                        area = AreaCalculate(sideList);
                    }
                }
            }
        }

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
            List<double> sideList = sidesToList(sides);

            if (TriangleValidate(sideList))
            {
                Type = "triangle";
                area = AreaCalculate(sideList);
            }
        }

        /// <summary>
        /// Установить значения сторон фигуры
        /// </summary>
        /// <param name="sides">Массив со значением сторон double[]</param>
        public void Set(double[] sides)
        {
            FigureSides = sides;
        }

        /// <summary>
        /// Установить значения сторон фигуры
        /// </summary>
        /// <param name="sideA">sideA double</param>
        /// <param name="sideB">sideB double</param>
        /// <param name="sideC">sideC double</param>
        public void Set(double sideA, double sideB, double sideC)
        {
            FigureSides = new double[] { sideA,sideB,sideC };
        }

        /// <summary>
        /// Обеспечение совместимости с интерфесом IFigure
        /// </summary>
        /// <param name="side"></param>
        public void Set(double side) {}

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <param name="sideA">сторона A double</param>
        /// <param name="sideB">стоорна B double</param>
        /// <param name="sideC">сторона C double</param>
        /// <returns>площадь треугольника double</returns>
        public static double getArea(double sideA, double sideB, double sideC)
        {
            return getArea(new double[] { sideA, sideB, sideC });
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <param name="sides">стороны треугольника double[]</param>
        /// <returns>площадь треугольника double</returns>
        public static double getArea(double[] sides)
        {
            List<double> sideList = sidesToList(sides);
            if (TriangleValidate(sideList))
            {
                return AreaCalculate(sideList);
            } else
            {
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

        /// <summary>
        /// Расчет площади треугольника
        /// </summary>
        /// <param name="sides">список сторон трегуольника List of double</param>
        /// <returns>площадь треугольника double</returns>
        private static double AreaCalculate(List<double> sides)
        {
            double halfP = sides.Sum() / 2;
            return Math.Sqrt(halfP * (halfP - sides[0]) * (halfP - sides[1]) * (halfP - sides[2]));
        }

        /// <summary>
        /// Преобразование массива в список
        /// </summary>
        /// <param name="sides">массив сторон треугольника array of double</param>
        /// <returns>список сторон List of double</returns>
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
        /// Валидация треугольника. Фигура соответствует треугольнику если (в соответствии с контролем):
        /// - задано сторон не меньше 3
        /// - звдвно сторон не больше 3
        /// - отдельные стороны не равны 0 и не меньше (исключение, если все стороны = 0 - для создания пустого объекта)
        /// - наибольшая сторона не больше суммы двух других
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
