# Library for calculating the area of a figure

**Библиотека, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам**
Реализация на C# с применением шаблона Factory

## Установка и запуск проекта
Для запуска проекта необходимо устанволенный **Visual Studio**
Скачать и полученный архив распаковать в пустой папке. Перейти в меню `file/open/project or solution` и выбрать папку с проектом.

## How use it

### Работа с классом Circle()

**Конструктор Circle**<br>

Создание пустого объекта (значение площади будет равняться 0):<br>
`Circle myCircle = new Circle();`

Создание объекта и присвоение значения для радиуса числовой переменной:<br>
`Circle myCircle = new Circle(double radius);`

Создание объекта и присвоение значения для радиуса через массив(применяется для расширения работы с Figure):<br>
`Circle myCircle = new Circle(double[] radius);`

**Использование статических методов класса Circle**

Расчет площади используя числовую переменную для задания радиуса:<br>
`double area = Circle.gerArea(double radius);`

Массив для входных параметров (принимается 0 индекс массива в качестве радиуса):<br>
`double area = Circle.getArea(double[] radius);`

**Поля для чтения**

Area<double> - вычисленная площадь<br>
Type<double> - Тип фигуры<br>
FigureSides<double[]> - значение сторон фигуры для расчета площади<br>

### Работа с классом Triangle()

**Конструктор Triangl**<br>

Создание пустого объекта (значение площади будет равняться 0):<br>
`Triangle myTriangl = new Triangle();`

Создание объекта и присвоение значения для трех сторон числовыми переменнфми:<br>
`Triangl myTriangl = new Triangl(double sideA, double sideB, double sideC);`

Создание объекта и присвоение значения для трех сторон через массив(применяется для расширения работы с Figure):<br>
`Triangl myCTriangl = new Triangle(double[] sides);`

**Использование статических методов класса Triangl**

Расчет площади используя числовые переменные для задания сторон:<br>
`double area =Triangl.gerArea(double sideA, double sideB, double sideC);`

Массив для входных параметров:<br>
`double area = Triangl.getArea(double[] sides);`

**Поля для чтения**

Area<double> - вычисленная площадь<br>
Type<double> - Тип фигуры<br>
FigureSides<double[]> - значение сторон фигуры для расчета площади<br>

## Описание
Диаграмма классов
![class diagram](https://i.ibb.co/0CYCsSW/Untitled-Diagram-4.jpg)
