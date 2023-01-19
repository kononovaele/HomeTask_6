//
// Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
// Примеры ввода: 0, 7, 8, -2, -2 -> 2 и 1, -7, 567, 89, 223-> 3
//
// Изменим ввод на ввод строки чисел с разделителем - запятая и пробел(ы) и с разделителем пробл(ы), без запятой
// Т. к., при вводе большого количества чисел, вводить запятую не всегда бывает удобно
//

// Ввод чисел.Разделитель между числами или пробел(ы)(табуляция) или запятая и пробел(ы)
// Возвращает строку целых чисел из консоли.
string InputIntegerDigitsAsString()
{
    Console.Write(" --- Input digits of integers (as example: 12 45 89 -12 101 or 11, 4, 5, 111, 777) ");
    Console.Write("\n --- The number separator is a comma (optional), space and or Tab!");

    Console.Write("\nInput digits, please: ");

    string? strArray = Console.ReadLine();
    if( String.IsNullOrEmpty(strArray) == true)
        strArray = "";

    // Из строки, которая может иметь значение NULL, делаем строку без NULL. Чтобы не использовать string?
    string str = string.Concat("", strArray);
    return str;
}

// Получает на входе строку чисел из консоли ввода.
// Если разделителем чисел была запятая ",", то удаляем ее.
// Возвращает строку целых чисел, где разделитель между числами - пробел
string GetNormilizeStrOfIntegers(string strArray)
{
    return strArray.Replace(",", "");
}

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

// Перебирает массив целых чисел и суммирует количество чисел больше нуля.
// Возвращает количество чисел из масива, больше нуля
int GetCountDigitsBiggerZero(int[] arrayDigits)
{
    int count = 0;

    for(int i = 0; i < arrayDigits.Length; ++i)
    {
        if(arrayDigits[i] > 0)
        {
            count = count + 1;
        }
    }

    return count;
}

void PrintRezult(int countDigitsBiggerZero)
{
    Console.WriteLine($"\n Count of digits bigger than zero is: {countDigitsBiggerZero}");
}

void main()
{
    Console.WriteLine(" ------- Task-41 -------");

    // Получить строку ввода целых чисел. Это строка вида: "11 71 88 -10 -12 33" или с разделителем
    // запятая ",": "-11, 55, 2, -9"
    string strDigits = InputIntegerDigitsAsString();
    Console.WriteLine($"\n You input digits: {strDigits}");

    // Для отладки
    //Console.WriteLine($"countElements: {countElements}");

    // Если были введены целые числа с разделителем запятая "," то заменяем запятую на пробел " "
    strDigits = GetNormilizeStrOfIntegers(strDigits);

    // Получим массив строк, где строка - целое число в виде строки
    string[] wordsOfNumbers = GetStrArrayOfNumvers(strDigits);

    // Конвертируем массив строк в массив целых числех
    int[] arrayOfDigits = GetConvertStrArrayToArrayInt(wordsOfNumbers);

    // Получим количество чисел больше нуля из массива целых чисел
    int countDigitsBiggerZero = GetCountDigitsBiggerZero(arrayOfDigits);

    // Печатаем результат (красиво), количество введенных чисел больше нуля
    PrintRezult(countDigitsBiggerZero);
}

main();


