
//
// Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2;
// значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
//
// В процессе решения задачи проверим координаты точек на перпендикулярность,
// параллельность и совпадение прямых, если ничего не совпадает, то решаем задачу
// иначе выходим с сообщением.
//
// k1 * k2 = -1 - перпендикулярна
// k1 = k2 - параллельна
// k1 = q * k2 и b1 = q * b2 - прямые совпадают, где q - любое целое
//

// Ввод чисел.Разделитель между числами или пробел(ы)(табуляция)
// Формат (порядок) ввода: b1 k1 b2 k1
// Возвращает строку целых чисел из консоли.
string InputIntegerDigitsAsString()
{
    Console.Write(" --- Input digits of integers as coord points (b1 k1 b2 k1) (as example: 2 5 4 9, where: b1=2 k1=5 b2=4 k2=9 )");
    Console.Write("\n --- The number separator is space and or Tab!");

    Console.Write("\nInput digits, please: ");

    string? strArray = Console.ReadLine();
    if( String.IsNullOrEmpty(strArray) == true)
        strArray = "";

    // Из строки, которая может иметь значение NULL, делаем строку без NULL. Чтобы не использовать string?
    string str = string.Concat("", strArray);
    return str;
}

// Печатаем коэффициенты прямых из данных ввода
void PrintInput(int[] array)
{
    Console.Write($"\nYou input coef: b1={array[0]}, k1={array[1]}, b2={array[2]}, k2={array[3]}");
}

// Конвертирует строку целых чисел в массив строк целых чисел
// Возвращает массив слов, где каждый элемент массива целое число в виде строки.
string[] GetStrArrayOfNumvers(string strDigits)
{
    return strDigits.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
}

// Конвертирует массив строк целых чисел в массив целых чисел
// Пример: string "11 -2 77 90 101 -44" => int[11 -2 77 90 101 -44]
// Возвращает массив целых чисел
int[] GetConvertStrArrayToArrayInt(string[] wordsOfNumbers)
{
    int lengthArray = wordsOfNumbers.Length;
    int[] array = new int[lengthArray];

    for(int i = 0; i < lengthArray; ++i)
    {
        array[i] = Convert.ToInt32(wordsOfNumbers[i]);
    }

    return array;
}

// Проверяет на перпендикулярность прямые. В массиве координаты (коэффициенты)  прямых
// arrayCoord[0] - b1, arrayCoord[1] - k1, arrayCoord[2] - b2, arrayCoord[3] - k2
// Возвращает: true если прямые перпендикулярны иначе - false
bool IsPerpendicular(int[] arrayCoord)
{
    if(arrayCoord[1] * arrayCoord[3] == -1)
        return true;
    else
        return false;
}

// Проверяет на параллельность прямые. В массиве координаты (коэффициенты)  прямых
// arrayCoord[0] - b1, arrayCoord[1] - k1, arrayCoord[2] - b2, arrayCoord[3] - k2
// Возвращает: true если прямые параллельны иначе - false
bool IsParallel(int[] arrayCoord)
{
    if(arrayCoord[1] == arrayCoord[3])
        return true;
    else
        return false;
}

// Находит координаты пересечения двух прямых на плоскости, значения возвращает в виде
// массива double, где array[0] - x и array[1] - y
// Возвращает массив double, array[0] - x и array[1] - y
double[] GetCoordIntersectionOfLines(int[] arrayCoord)
{
    double[] coord = new double[2];
    double b1 = arrayCoord[0];
    double k1 = arrayCoord[1];
    double b2 = arrayCoord[2];
    double k2 = arrayCoord[3];

    double x = (b1 - b2) / (k2 - k1);
    double y = k1 * x + b1;

    coord[0] = x;
    coord[1] = y;

    return coord;
}

// Печатаем координаты точки пересечения двух прямых на плоскости, coordXY[0] - X
// coordXY[1] - Y
void PrintCoord(double[] coordXY)
{
    Console.WriteLine($"Coord is: ({coordXY[0]}; {coordXY[1]})");
}

void main()
{
    Console.WriteLine(" ------- Task-43 -------");

    // Получить строку ввода целых чисел. Формат (порядок) ввода: b1 k1 b2 k1
    // Пример: ввели "-11, 55, 2, -9", коэффициенты: b1 = -11  k1 = 55 b2 = 2 k2 = -9
    string strDigits = InputIntegerDigitsAsString();

    // Получим массив строк, где строка - целое число в виде строки
    string[] wordsOfNumbers = GetStrArrayOfNumvers(strDigits);

    // Конвертируем массив строк в массив целых числех
    int[] arrayCoord = GetConvertStrArrayToArrayInt(wordsOfNumbers);

    // Печатаем коэффициенты, что ввели
    PrintInput(arrayCoord);

    if(IsPerpendicular(arrayCoord) == true)
    {
        Console.WriteLine("\n Lines are Perpendicular, sorry!!!");
        return;        
    }

    if(IsParallel(arrayCoord) == true)
    {
        Console.WriteLine("\n Lines are parallel, sorry!!!");
        return;        
    }

    // Получим координтау пересечения прямых в виде массива, где [0] - Х b [1] - Y
    double[] coordXY = GetCoordIntersectionOfLines(arrayCoord);
    // Печатаем результат (красиво), количество введенных чисел больше нуля
    PrintCoord(coordXY);
}

main();


