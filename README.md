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

## Описание
Диаграмма классов
![class diagram](https://i.ibb.co/0CYCsSW/Untitled-Diagram-4.jpg)
