# Library for calculating the area of a figure

**Библиотека, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам**
Реализация на C# с применением шаблона Factory для возможности автоматического определения типа фигуры при создании объекта. 

Поддерживается работа с фигурами:
- через фабрику, создавая объект в соответствии с входными парматерами (одно значение - окружность, три значения - треугольник);
- объявлением объекта соответствующего типа используя классы напрямую (Circle и Triangle);
- при помощи методов класса;


## Установка и запуск проекта
Для запуска проекта необходимо установоленный **Visual Studio**
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

Для объектов с интерфейсом IFigure доступны все поля и методы, объявленные классами Circle и Triangle (кроме статических методов указанных классов)
### Работа с объектами IFigure

Доступны поля:<br>
`Area<double>` - `{ get; }` получить вычисленную площадь<br>
`Type<double>` - `{ get; }` Тип фигуры<br>
`FigureSides<double[]>` - `{ get; set; }` значение сторон фигуры для расчета площади. Изменяет значение поля `Area`. Наименьшее число перегрузок.<br>

Алгоритм классов построен по принципу хранения вычисленного значения сразу после его указания. Таким образом, не происходит повторное вычисление площади, при последующих обращениях к полю `Area`.
Для инициализации нового расчета и изменение значения поля:<br>
`figure.Set(double radius)` - Для объекта Circle. Игнорируется объектом Triangle<br>
`figure.Set(double sideA, double sideB, double sideC)` - Для объекта Triangle. Игнорируется объектом Circle<br>
`figure.Set(double[] sides)` - Для объекта Triangle и Circle, при соответствии параметров<br>

При возникновении ситуаций, когда необходимо задать новые параметры и получить значение площади предусмотрен метод `UpdateArea()` с соответствующими перезагрузками для соответствующих объектов и решений
`double figure.UpdateArea(double radius)` - Для объекта Circle. Игнорируется объектом Triangle<br>
`double figure.UpdateArea(double sideA, double sideB, double sideC)` - Для объекта Triangle. Игнорируется объектом Circle<br>
`double figure.UpdateArea(double[] sides)` - Для объекта Triangle и Circle, при соответствии параметров<br>

Проверка свойств фигуры.<br>
Метод для определения соответствия фигуры "прямоугольности":
`bool figure.Rectangular()` - возвращает `true` если фигура прямоугольная.

Сравнение объектов IFigure:<br>
'bool figureA.Equals(figureB)' - сравнение типа и соответствие размеров. Если фигуры одинакового типа и размеры их соответствуют, возвращает `true`.

**Пример использования**

`
	List<double[]> figureList = new List<double[]>();
	
	IFigureFactory figureFactory = new FigureFactory();
	
	figureList.Add(new double[] { 5 });
	figureList.Add(new double[] { 2 });
	figureList.Add(new double[] { 7 });
	figureList.Add(new double[] { 13, 5, 14 });
	figureList.Add(new double[] { 5, 5, 5 });
	figureList.Add(new double[] { 7, 3, 9 });
	
	figureList.ForEach(delegate (double[] figureParams)
	{
	    IFigure figure = figureFactory.CreateFigure(figureParams);
		Console.WriteLine(figure.ToString());
	});

//Console will display
//circle	
//circle
//circle
//triangle
//triangle
//triangle
`


### Работа с классом Circle()

**Конструктор Circle**<br>

При объявлении объекта Circle и изменении его входных данных происходит следующая проверка входных параметров:<br>
- значение радиуса не должно быть меньше 0
- радиус со значением 0 означает пустой объект<br>
В остальных случаях вызывается Exception с сообщением: <br>
- 'Radius cannot be assigned as negative value' 

Создание пустого объекта (значение площади будет равняться 0):<br>
`Circle circle = new Circle();`

Создание объекта и присвоение значения для радиуса числовой переменной:<br>
`Circle circle = new Circle(double radius);`
		c
Созданиеcъекта и присвоение значения для радиуса через массив(применяется для расширения работы с Figure):<br>
`Circle circle = new Circle(double[] radius);`

Присвоение нового значения радиуса числовой переменной:<br>
`circle.Set(double radius);`

Присвоение нового значения радиуса через массив:<br>
`circle.Set(double[] {radius});`

**Поля для чтения**

`Area<double>` - `{ get; }` вычисленная площадь<br>
`Type<double>` - `{ get; }` Тип фигуры<br>
`FigureSides<double[]>` - `{ get; set; }` значение сторон фигуры для расчета площади. Изменяет значение поля `Area`<br>

Метод для определения проямоугольного треугольника:
`bool figure.Rectangular()` - возвращает `true` если фигура прямоугольная.


**Использование статических методов класса Circle. Методы недоступны при работе с объектами через интерфейс IFigure.**

Расчет площади используя числовую переменную для задания радиуса:<br>
`double area = Circle.GerArea(double radius);`

Массив для входных параметров (принимается 0 индекс массива в качестве радиуса):<br>
`double area = Circle.GetArea(double[] radius);`

Сравнение объектов по размеру площади:<br> 
`bool circleA > cyrcleB`<br> 
`bool circleA < cyrcleB`<br>
`bool circleA >= cyrcleB`<br>
`bool circleA >= cyrcleB`<br>
`bool circleA != cyrcleB`<br>
`bool circleA == cyrcleB`<br>

Сравнение объектов по размеру радиуса:<br>
`bool circleA.Equals(circleB)`


### Работа с классом Triangle()

При объявлении объекта Triangle и изменении его входных данных происходит следующая проверка входных параметров:<br>
- ни одна из сторон не должна быть меньше 0 или равняться 0 (исключение - все стороны равны 0 при объявлении пустого объекта)
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

Создание объекта и присвоение значения для трех сторон числовыми переменными:<br>
`Triangl myTriangl = new Triangl(double sideA, double sideB, double sideC);`

Создание объекта и присвоение значения для трех сторон через массив(применяется для расширения работы с Figure):<br>
`Triangl myTriangl = new Triangle(double[] sides);`

Присвоение новых значений сторон числовыми переменными:<br>
`myTriangl.Set(double sideA, double sideB, double sideC);`

Присвоение новых значений сторон через массив:<br>
`myTriangl.Set(double[] sides);`

**Поля для чтения**

Area<double> - { get; } вычисленная площадь<br>
Type<double> - { get; } Тип фигуры<br>
FigureSides<double[]> - { get; set; } значение сторон фигуры для расчета площади. Изменяет значение поля Area<br>

**Использование статических методов класса Triangl. Методы не доступны при работе с объектами через интерфейс IFigure.**

Расчет площади используя числовые переменные для задания сторон:<br>
`double area =Triangl.GerArea(double sideA, double sideB, double sideC);`

Массив для входных параметров:<br>
`double area = Triangl.GetArea(double[] sides);`

Сравнение объектов по размеру площади:<br> 
`bool triangleA > triangleB`<br> 
`bool triangleA < triangleB`<br> 
`bool triangleA >= triangleB`<br> 
`bool triangleA >= triangleB`<br> 
`bool triangleA != triangleB`<br> 
`bool triangleA == triangleB`<br> 

Сравнение объектов по размеру сторон:<br>
`bool triangleA.Equals(triangleB)`



## Проектная часть
Основная структура проекта представлена на диаграмме классов. Классы для фигур наследуют единый интерфейс для совместимости. Фабрика фигур позволяет объявлять объекты автоматически определяя их тип.<br>
![class diagram](https://i.ibb.co/0CYCsSW/Untitled-Diagram-4.jpg)

Базовая последовательноcть использования методов для объекта, при создании фигуры через конструктор и расчета площади через статические медотды класса.<br>
![Sequence diagram](https://i.ibb.co/ctLDZPf/Untitled-Diagram-7.jpg)
