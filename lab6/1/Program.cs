using System;

namespace lab6_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Задание 1.1 ThreeIntegers ===");
            _TestThreeIntegers();

            Console.WriteLine();
            Console.WriteLine("=== Задание 1.2 RGBColor ===");
            _TestRGBColor();
        }

        private static void _TestThreeIntegers()
        {
            ThreeIntegers defaultObj = new ThreeIntegers();
            Console.WriteLine("Конструктор по умолчанию:");
            Console.WriteLine(defaultObj.ToString());
            Console.WriteLine("Минимальная из последних цифр: " + defaultObj.GetMinLastDigit());
            Console.WriteLine();

            Console.WriteLine("Введите три целых числа для создания объекта ThreeIntegers:");
            int first = _ReadInt("Первое число: ");
            int second = _ReadInt("Второе число: ");
            int third = _ReadInt("Третье число: ");

            ThreeIntegers userObj = new ThreeIntegers(first, second, third);
            Console.WriteLine();
            Console.WriteLine("Конструктор с параметрами:");
            Console.WriteLine(userObj.ToString());
            Console.WriteLine("Минимальная из последних цифр: " + userObj.GetMinLastDigit());
            Console.WriteLine();

            ThreeIntegers copyObj = new ThreeIntegers(userObj);
            Console.WriteLine("Конструктор копирования:");
            Console.WriteLine(copyObj.ToString());
            Console.WriteLine("Минимальная из последних цифр: " + copyObj.GetMinLastDigit());
        }

        private static void _TestRGBColor()
        {
            RGBColor defaultColor = new RGBColor();
            Console.WriteLine("Конструктор по умолчанию (чёрный цвет):");
            Console.WriteLine(defaultColor.ToString());
            Console.WriteLine("Является серым: " + defaultColor.IsGrayscale());
            Console.WriteLine("HEX: " + defaultColor.ToHexString());
            Console.WriteLine();

            Console.WriteLine("Введите три целых числа (0–255) для создания цвета RGB:");
            int red = _ReadIntInRange("Красный (R, 0–255): ", 0, 255);
            int green = _ReadIntInRange("Зелёный (G, 0–255): ", 0, 255);
            int blue = _ReadIntInRange("Синий (B, 0–255): ", 0, 255);

            RGBColor userColor = new RGBColor(red, green, blue);
            Console.WriteLine();
            Console.WriteLine("Конструктор с параметрами:");
            Console.WriteLine(userColor.ToString());
            Console.WriteLine("Является серым: " + userColor.IsGrayscale());
            Console.WriteLine("HEX: " + userColor.ToHexString());
            Console.WriteLine();

            RGBColor invertedColor = userColor.InvertColor();
            Console.WriteLine("Инвертированный цвет:");
            Console.WriteLine(invertedColor.ToString());
            Console.WriteLine();

            RGBColor copyColor = new RGBColor(userColor);
            Console.WriteLine("Конструктор копирования:");
            Console.WriteLine(copyColor.ToString());

            Console.WriteLine();
            Console.WriteLine("Тест с выходом за пределы диапазона (300, -50, 128):");
            RGBColor clampedColor = new RGBColor(300, -50, 128);
            Console.WriteLine(clampedColor.ToString());
            Console.WriteLine("HEX: " + clampedColor.ToHexString());
        }

        private static int _ReadInt(string prompt)
        {
            int result;
            Console.Write(prompt);

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Ошибка ввода. Введите целое число: ");
            }

            return result;
        }

        private static int _ReadIntInRange(string prompt, int minValue, int maxValue)
        {
            int result;
            Console.Write(prompt);

            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.Write("Ошибка ввода. Введите целое число: ");
                    continue;
                }

                if (result < minValue || result > maxValue)
                {
                    Console.Write($"Число должно быть от {minValue} до {maxValue}. Повторите ввод: ");
                    continue;
                }

                break;
            }

            return result;
        }
    }
}
