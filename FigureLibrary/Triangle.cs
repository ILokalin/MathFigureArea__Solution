using System;
using System.Collections;


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
                double[] triangleSides = (double[])value.Clone();

                if (triangleSides != figureSides)
                {
                    if (TriangleValidate(triangleSides))
                    {
                        figureSides = triangleSides;
                        area = AreaCalculate(triangleSides);
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
            FigureSides = sides;
            Type = "triangle";
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
            FigureSides = new double[] { sideA, sideB, sideC };
        }

        /// <summary>
        /// Вызывает исключение - слишком мало парметров
        /// </summary>
        /// <param name="side"></param>
        public void Set(double side)
        {
            throw new NotValidateException("Too few parameters for Triangle");
        }

        /// <summary>
        /// Вызывает исключение для Triangle
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        public double UpdateArea(double side)
        {
            throw new NotValidateException("Too few parameters for Triangle");
        }

        /// <summary>
        /// Обновление значений сторон и возврат значения площади
        /// </summary>
        /// <param name="side">значения сторон double[]</param>
        /// <returns></returns>
        public double UpdateArea(double[] side)
        {
            FigureSides = side;
            return area;
        }

        /// <summary>
        /// Обновление значений сторон и возврат значения площади
        /// </summary>
        /// <param name="sideA">sideA double</param>
        /// <param name="sideB">sideB double</param>
        /// <param name="sideC">sideC double</param>
        /// <returns></returns>
        public double UpdateArea(double sideA, double sideB, double sideC)
        {
            return UpdateArea(new double[] { sideA, sideB, sideC });
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <param name="sideA">сторона A double</param>
        /// <param name="sideB">стоорна B double</param>
        /// <param name="sideC">сторона C double</param>
        /// <returns>площадь треугольника double</returns>
        public static double GetArea(double sideA, double sideB, double sideC)
        {
            return GetArea(new double[] { sideA, sideB, sideC });
        }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        /// <param name="sides">стороны треугольника double[]</param>
        /// <returns>площадь треугольника double</returns>
        public static double GetArea(double[] sides)
        {
            double[] triangleSedes = (double[])sides.Clone();

            if (TriangleValidate(triangleSedes))
            {
                return AreaCalculate(triangleSedes);
            }
            else
            {
                return 0;
            }
        }

        public bool Rectangular()
        {
            if (figureSides[2] == Math.Sqrt(Math.Pow(figureSides[0], 2) + Math.Pow(figureSides[1], 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="triangleA"></param>
        /// <param name="triangleB"></param>
        /// <returns></returns>
        public static bool operator >(Triangle triangleA, Triangle triangleB)
        {
            return triangleA.Area > triangleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="triangleA"></param>
        /// <param name="triangleB"></param>
        /// <returns></returns>
        public static bool operator <(Triangle triangleA, Triangle triangleB)
        {
            return triangleA.Area < triangleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="triangleA"></param>
        /// <param name="triangleB"></param>
        /// <returns></returns>
        public static bool operator >=(Triangle triangleA, Triangle triangleB)
        {
            return triangleA.Area >= triangleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="triangleA"></param>
        /// <param name="triangleB"></param>
        /// <returns></returns>
        public static bool operator <=(Triangle triangleA, Triangle triangleB)
        {
            return triangleA.Area <= triangleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="triangleA"></param>
        /// <param name="triangleB"></param>
        /// <returns></returns>
        public static bool operator !=(Triangle triangleA, Triangle triangleB)
        {
            return triangleA.Area != triangleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="triangleA"></param>
        /// <param name="triangleB"></param>
        /// <returns></returns>
        public static bool operator ==(Triangle triangleA, Triangle triangleB)
        {
            return triangleA.Area == triangleB.Area;
        }

        /// <summary>
        /// Сравнение сторон объектов
        /// </summary>
        /// <param name="obj">объект Triangle</param>
        /// <returns>bool</returns>
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Triangle triangle = (Triangle)obj;

                IStructuralEquatable testThis = this.figureSides;
                double[] testObj = triangle.figureSides;

                return testThis.Equals(testObj, StructuralComparisons.StructuralEqualityComparer);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
        /// <param name="sides">список сторон треугольника List of double</param>
        /// <returns>площадь треугольника double</returns>
        private static double AreaCalculate(double[] sides)
        {
            double halfP = Service.arraySum(sides) / 2;
            return Math.Sqrt(halfP * (halfP - sides[0]) * (halfP - sides[1]) * (halfP - sides[2]));
        }

        /// <summary>
        /// Валидация треугольника. Фигура соответствует треугольнику если (в соответствии с контролем):
        /// - задано сторон не меньше 3
        /// - задано сторон не более 3
        /// - отдельные стороны не равны 0 и не меньше (исключение, если все стороны = 0 - для создания пустого объекта)
        /// - наибольшая сторона не больше суммы двух других
        /// </summary>
        /// <param name="radius">значение радиуса double</param>
        /// <returns>true - треугольник; исключение - при несоответствии</returns>
        private static bool TriangleValidate(double[] sides)
        {
            double sumOfSides = Service.arraySum(sides);
            Service.arraySort(sides);

            if (sides.Length < 3)
            {
                throw new NotValidateException("Too few parameters for sides");
            }

            if (sides.Length > 3)
            {
                throw new NotValidateException("Too many parameters for sides");
            }

            foreach (var side in sides)
            {
                if (side <= 0 & sumOfSides != 0)
                {
                    throw new NotValidateException("One of the side has bad size (0 or negative)");
                }
            }

            if (sides[2] > sides[1] + sides[0] & sumOfSides != 0)
            {
                throw new NotValidateException("One of the sides too long");
            }

            return true;
        }
    }
}
