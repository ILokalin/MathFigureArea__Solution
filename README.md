# Library for calculating the area of a figure

**Библиотека, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам**
Реализация на C# с применением шаблона Factory

## Установка и запуск проекта
Для запуска проекта необходимо устанволенный **Visual Studio**
Скачать и полученный архив распаковать в пустой папке. Перейти в меню `file/open/project or solution` и выбрать папку с проектом.

## How use it

### Работа с фабрикой FigureFactory()

**Конструктор FigureFactory()**

Создание фабрики фигур:<br>
`IFigureFactory figureFactory = new FigureFactory()`

Для создания фигуры возможно использовать следующие перезагрузки метода `CreateFigure`:<br>
`IFigure figure = figureFactory()` - создание объекта с классом Circle и значением радиуса = 0<br>
`IFigure figure = figureFactory(radius)` - создание объекта с классом Circle<br>
`IFigure figure = figureFactory(double[] {radius})` - создание объекта с классом Circle<br>
`IFigure figure = figureFactory(double sideA, double sideB, doible sideC)` - создание объекта с классом Triangle<br>
`IFigure figure = figureFactory(double[] { sideA, sideB, sideC })` - создание объекта с классом Triangle<br>

### Работа с классом Circle()

**Конструктор Circle**<br>

Создание пустого объекта (значение площади будет равняться 0):<br>
`Circle myCircle = new Circle();`

Создание объекта и присвоение значения для радиуса числовой переменной:<br>
`Circle myCircle = new Circle(double radius);`

Создание объекта и присвоение значения для радиуса через массив(применяется для расширения работы с Figure):<br>
`Circle myCircle = new Circle(double[] radius);`

**Поля для чтения**

`Area<double>` - `{ get; }` вычисленная площадь<br>
`Type<double>` - `{ get; }` Тип фигуры<br>
`FigureSides<double[]>` - `{ get; set; }` значение сторон фигуры для расчета площади. Изменяет значение поля `Area`<br>


**Использование статических методов класса Circle**

Расчет площади используя числовую переменную для задания радиуса:<br>
`double area = Circle.gerArea(double radius);`

Массив для входных параметров (принимается 0 индекс массива в качестве радиуса):<br>
`double area = Circle.getArea(double[] radius);`


### Работа с классом Triangle()

**Конструктор Triangl**<br>

Создание пустого объекта (значение площади будет равняться 0):<br>
`Triangle myTriangl = new Triangle();`

Создание объекта и присвоение значения для трех сторон числовыми переменнфми:<br>
`Triangl myTriangl = new Triangl(double sideA, double sideB, double sideC);`

Создание объекта и присвоение значения для трех сторон через массив(применяется для расширения работы с Figure):<br>
`Triangl myCTriangl = new Triangle(double[] sides);`

**Поля для чтения**

Area<double> - { get; } вычисленная площадь<br>
Type<double> - { get; } Тип фигуры<br>
FigureSides<double[]> - { get; set; } значение сторон фигуры для расчета площади. Изменяет значение поля Area<br>

**Использование статических методов класса Triangl**

Расчет площади используя числовые переменные для задания сторон:<br>
`double area =Triangl.gerArea(double sideA, double sideB, double sideC);`

Массив для входных параметров:<br>
`double area = Triangl.getArea(double[] sides);`



## Описание
Диаграмма классов
![class diagram](https://i.ibb.co/0CYCsSW/Untitled-Diagram-4.jpg)
