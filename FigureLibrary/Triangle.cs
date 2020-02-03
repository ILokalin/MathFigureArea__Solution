﻿using System;
using System.Collections.Generic;
using System.Collections;
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
                figureSides = sides;
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
            List<double> sideList = sidesToList(side);

            if (TriangleValidate(sideList))
            {
                figureSides = side;
                area = AreaCalculate(sideList);
            }

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

        public bool Rectangular()
        {
            List<double> sideList = sidesToList(figureSides);
            sideList.Sort();

            if (sideList[2] == Math.Sqrt(Math.Pow(sideList[0], 2) + Math.Pow(sideList[1], 2)))
            {
                return true;
            } else
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
            } else {
                Triangle triangle = (Triangle)obj;
                
                List<double> thisSides = sidesToList(this.FigureSides);
                List<double> objSides = sidesToList(triangle.FigureSides);

                thisSides.Sort();
                objSides.Sort();

                IStructuralEquatable testA = thisSides.ToArray();
                double[] testB = objSides.ToArray();

                return testA.Equals(testB, StructuralComparisons.StructuralEqualityComparer);
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
        /// - задано сторон не более 3
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
