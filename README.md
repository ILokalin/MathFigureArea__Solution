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

Для объектов с иетерфейсом IFigure доступны все поля и методы, объявленные классами Circle и Triangle (кроме статических методов указанных классов)
### Работа с объектами IFigure

Достпны поля:<br>
`Area<double>` - `{ get; }` получить вычисленную площадь<br>
`Type<double>` - `{ get; }` Тип фигуры<br>
`FigureSides<double[]>` - `{ get; set; }` значение сторон фигуры для расчета площади. Изменяет значение поля `Area`. Наименьшее число перезегрузок.<br>

Алгоритм классов построен по принципу хранения вычесленного значения сразу после его указания. Таким образом, не происходит повторное вычисление площади, при последующих обращениях к полю `Area`.
Для инициализации нового расчета и изменение занчения поля:<br>
`figure.Set(double radius)` - Для объекта Circle. Игнорируется объектом Triangle<br>
`figure.Set(double sideA, double sideB, double sideC)` - Для объекта Triangle. Игнорируется объектом Circle<br>
`figure.Set(double[] sides)` - Для объекта Triangle и Circle, при соответствии параметров<br>

При возникновении ситуаций, когда необходимо задать новые параметры и получить значение площади предусмотрен метод `UpdateArea()` с соответствующими перезагрузками для соответствующих объектов и решений
`double figure.UpdateArea(double radius)` - Для объекта Circle. Игнорируется объектом Triangle<br>
`double figure.UpdateArea(double sideA, double sideB, double sideC)` - Для объекта Triangle. Игнорируется объектом Circle<br>
`double figure.UpdateArea(double[] sides)` - Для объекта Triangle и Circle, при соответствии параметров<br>


### Работа с классом Circle()

**Конструктор Circle**<br>

При объявлении объекта Circle и изменении его входных данных просиходит следующая проверка входных параметров:<br>
- значение радиуса не должно быть меньше 0
- радиус со значением 0 означает пустой объект<br>
В остальных случаях вызывается Exception с сообщением: <br>
- 'Radius cannot be assigned as negative value' 

Создание пустого объекта (значение площади будет равняться 0):<br>
`Circle myCircle = new Circle();`

Создание объекта и присвоение значения для радиуса числовой переменной:<br>
`Circle myCircle = new Circle(double radius);`

Создание объекта и присвоение значения для радиуса через массив(применяется для расширения работы с Figure):<br>
`Circle myCircle = new Circle(double[] radius);`

Присвоение нового значения радиуса числовой переменной:<br>
`myCircle.Set(double radius);`

Присвоение нового значения радиуса через массив:<br>
`myCircle.Set(double[] {radius});`

**Поля для чтения**

`Area<double>` - `{ get; }` вычисленная площадь<br>
`Type<double>` - `{ get; }` Тип фигуры<br>
`FigureSides<double[]>` - `{ get; set; }` значение сторон фигуры для расчета площади. Изменяет значение поля `Area`<br>


**Использование статических методов класса Circle. Методы не доступны при работе с объектами через интерфейс IFigure.**

Расчет площади используя числовую переменную для задания радиуса:<br>
`double area = Circle.gerArea(double radius);`

Массив для входных параметров (принимается 0 индекс массива в качестве радиуса):<br>
`double area = Circle.getArea(double[] radius);`


### Работа с классом Triangle()

При объявлении объекта Triangle и изменении его входных данных просиходит следующая проверка входных параметров:<br>
- ни одна из сторн не должна быть меньше 0 или равняться 0 (исключение - все стороны равны 0 при объявлении пустого объекта)
- должны быть указаны для 3 сторон
- наибольшая сторона не может быть больше чем сумма других сторон<br>
В остальных случаях вызывается Exception с сообщением: <br>
- 'Too few parameters for sides'
- 'Too many parameters for sides'
- 'One of the side has bad size (0 or negative)'
- 'One of the sides too long'

**Конструктор Triangl**<br>

Создание пустого объекта (значение площади будет равняться 0):<br>
`Triangle myTriangl = new Triangle();`

Создание объекта и присвоение значения для трех сторон числовыми переменнфми:<br>
`Triangl myTriangl = new Triangl(double sideA, double sideB, double sideC);`

Создание объекта и присвоение значения для трех сторон через массив(применяется для расширения работы с Figure):<br>
`Triangl myCTriangl = new Triangle(double[] sides);`

Присвоение новых значений сторон числовыми переменными:<br>
`myCircle.Set(double sideA, double sideB, double sideC);`

Присвоение новых значений сторон через массив:<br>
`myCircle.Set(double[] sides);`

**Поля для чтения**

Area<double> - { get; } вычисленная площадь<br>
Type<double> - { get; } Тип фигуры<br>
FigureSides<double[]> - { get; set; } значение сторон фигуры для расчета площади. Изменяет значение поля Area<br>

**Использование статических методов класса Triangl. Методы не доступны при работе с объектами через интерфейс IFigure.**

Расчет площади используя числовые переменные для задания сторон:<br>
`double area =Triangl.gerArea(double sideA, double sideB, double sideC);`

Массив для входных параметров:<br>
`double area = Triangl.getArea(double[] sides);`



## Описание
Диаграмма классов
![class diagram](https://i.ibb.co/0CYCsSW/Untitled-Diagram-4.jpg)
