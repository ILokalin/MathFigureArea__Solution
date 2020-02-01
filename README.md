# Library for calculating the area of a figure

**Библиотека, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам**
Реализация на C# с применением шаблона Factory

## Установка и запуск проекта
Для запуска проекта необходимо устанволенный **Visual Studio**
Скачать и полученный архив распаковать в пустой папке. Перейти в меню `file/open/project or solution` и выбрать папку с проектом.

## How use it

**Circle()**
Конструктор для Circle
Создание пустого объекта:
`Circle myCircle = new Circle();`

Создание объекта и присвоение значения для радиуса числовой переменной:
`Circle myCircle = new Circle(5);`

Создание объекта и присвоение значения для радиуса через массив(применяется для расширения работы с Figure):
`Circle myCircle = new Circle(double[]);`

**Circle.getArea(raduis)**
Прямой вызов функции для расчета площади:
Используя числовую переменную для задания радиуса: 
`double area = Circle.gerArea(5);`

Используя массив для радиуса: 
`double radius = { 5 };
double area = Circle.getArea(radius);`

## Описание
Диаграмма классов
![class diagram](https://i.ibb.co/0CYCsSW/Untitled-Diagram-4.jpg)
