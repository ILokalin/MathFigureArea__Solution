using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace FigureLibrary
{
    public class Circle : IFigure
    {
        /// <summary>
        /// значение площади фигуры
        /// </summary>
        private double area;

        /// <summary>
        /// значение радиуса
        /// </summary>
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
            if (radius < 0)
            {
                throw new NotValidateException("Radius cannot be assigned as negative value");
            }

            return true;
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

        /// <summary>
        /// Радиус окружности double[]
        /// </summary>
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
        /// Установить значения сторон
        /// </summary>
        /// <param name="sides">Массив double[]</param>
        public void Set(double[] sides)
        {
            FigureSides = sides;
        }

        /// <summary>
        /// Установить значение радиуса
        /// </summary>
        /// <param name="side">side радиус double</param>
        public void Set(double side)
        {
            FigureSides = new double[] { side };
        }

        /// <summary>
        /// Вызывает исключение - слишком много параметров
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        public void Set(double sideA, double sideB, double sideC) 
        {
            throw new NotValidateException("Too many parameters for Circle");
        }

        /// <summary>
        /// Обновление значений сторон и возврат значения площади
        /// </summary>
        /// <param name="side">радиус double</param>
        /// <returns></returns>
        public double UpdateArea(double side)
        {
            if (CircleValidate(side))
            {
                area = getArea(side);
            }

            return area;
        }

        /// <summary>
        /// Обновление значений сторон и возврат значения площади
        /// </summary>
        /// <param name="side">радиус double[]</param>
        /// <returns></returns>
        public double UpdateArea(double[] side)
        {
            if (CircleValidate(side[0]))
            {
                area = getArea(side[0]);
            }

            return area;
        }

        /// <summary>
        /// Вызывает исключение для Circle
        /// </summary>
        /// <param name="sideA"></param>
        /// <param name="sideB"></param>
        /// <param name="sideC"></param>
        /// <returns></returns>
        public double UpdateArea(double sideA, double sideB, double sideC)
        {
            throw new NotValidateException("Too much parameters for Circle");
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
        /// сравнение площадей
        /// </summary>
        /// <param name="circleA"></param>
        /// <param name="circleB"></param>
        /// <returns></returns>
        public static bool operator >(Circle circleA, Circle circleB)
        {
            return circleA.Area > circleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="circleA"></param>
        /// <param name="circleB"></param>
        /// <returns></returns>
        public static bool operator <(Circle circleA, Circle circleB)
        {
            return circleA.Area < circleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="circleA"></param>
        /// <param name="circleB"></param>
        /// <returns></returns>
        public static bool operator >=(Circle circleA, Circle circleB)
        {
            return circleA.Area >= circleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="circleA"></param>
        /// <param name="circleB"></param>
        /// <returns></returns>
        public static bool operator <=(Circle circleA, Circle circleB)
        {
            return circleA.Area <= circleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="circleA"></param>
        /// <param name="circleB"></param>
        /// <returns></returns>
        public static bool operator !=(Circle circleA, Circle circleB)
        {
            return circleA.Area != circleB.Area;
        }

        /// <summary>
        /// сравнение площадей
        /// </summary>
        /// <param name="circleA"></param>
        /// <param name="circleB"></param>
        /// <returns></returns>
        public static bool operator ==(Circle circleA, Circle circleB)
        {
            return circleA.Area == circleB.Area;
        }

        /// <summary>
        /// Сравнение сторон объектов
        /// </summary>
        /// <param name="obj">Объект Circle</param>
        /// <returns>bool</returns>
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Circle circle = (Circle)obj;
                IStructuralEquatable testA = this.FigureSides;

                return testA.Equals(circle.FigureSides, StructuralComparisons.StructuralEqualityComparer);
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
