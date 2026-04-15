using System;

namespace lab6._23
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Задания 2 и 3. QuadraticEquation ===");
            Console.WriteLine();

            _TestConstructors();
            _TestSolveMethod();
            _TestUnaryOperators();
            _TestTypeConversions();
            _TestBinaryOperators();
        }

        private static void _TestConstructors()
        {
            Console.WriteLine("--- Тестирование конструкторов ---");

            QuadraticEquation defaultEq = new QuadraticEquation();
            Console.WriteLine("Конструктор по умолчанию: " + defaultEq.ToString());

            Console.WriteLine();
            Console.WriteLine("Введите коэффициенты квадратного уравнения ax^2 + bx + c = 0:");
            double a = _ReadDouble("Коэффициент a: ");
            double b = _ReadDouble("Коэффициент b: ");
            double c = _ReadDouble("Коэффициент c: ");

            QuadraticEquation userEq = new QuadraticEquation(a, b, c);
            Console.WriteLine("Конструктор с параметрами: " + userEq.ToString());

            QuadraticEquation copyEq = new QuadraticEquation(userEq);
            Console.WriteLine("Конструктор копирования: " + copyEq.ToString());

            Console.WriteLine("Оригинал == Копия: " + (userEq == copyEq));

            Console.WriteLine();
        }

        private static void _TestSolveMethod()
        {
            Console.WriteLine("--- Тестирование метода Solve ---");

            QuadraticEquation eqTwoRoots = new QuadraticEquation(1, -5, 6);
            Console.WriteLine("Уравнение: " + eqTwoRoots.ToString());
            _PrintRoots(eqTwoRoots);
            Console.WriteLine();

            QuadraticEquation eqOneRoot = new QuadraticEquation(1, -4, 4);
            Console.WriteLine("Уравнение: " + eqOneRoot.ToString());
            _PrintRoots(eqOneRoot);
            Console.WriteLine();

            QuadraticEquation eqNoRoots = new QuadraticEquation(1, 0, 1);
            Console.WriteLine("Уравнение: " + eqNoRoots.ToString());
            _PrintRoots(eqNoRoots);
            Console.WriteLine();

            QuadraticEquation eqInvalid = new QuadraticEquation(0, 2, 3);
            Console.WriteLine("Уравнение: " + eqInvalid.ToString());
            try
            {
                _PrintRoots(eqInvalid);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Исключение: " + ex.Message);
            }

            Console.WriteLine();
        }

        private static void _TestUnaryOperators()
        {
            Console.WriteLine("--- Тестирование унарных операций ++ и -- ---");

            QuadraticEquation eq = new QuadraticEquation(2, 3, 1);
            Console.WriteLine("Исходное уравнение: " + eq.ToString());

            eq++;
            Console.WriteLine("После ++: " + eq.ToString());

            eq--;
            Console.WriteLine("После --: " + eq.ToString());

            QuadraticEquation incremented = ++eq;
            Console.WriteLine("Префиксный ++eq: " + incremented.ToString());
            Console.WriteLine("Исходный eq: " + eq.ToString());

            QuadraticEquation decremented = --eq;
            Console.WriteLine("Префиксный --eq: " + decremented.ToString());

            Console.WriteLine();
        }

        private static void _TestTypeConversions()
        {
            Console.WriteLine("--- Тестирование операций приведения типа ---");

            QuadraticEquation eq1 = new QuadraticEquation(1, -5, 6);
            double discriminant = eq1;
            Console.WriteLine("Уравнение: " + eq1.ToString());
            Console.WriteLine("Неявное приведение к double (дискриминант): " + discriminant);

            bool hasRoots1 = (bool)eq1;
            Console.WriteLine("Явное приведение к bool (корни существуют): " + hasRoots1);
            Console.WriteLine();

            QuadraticEquation eq2 = new QuadraticEquation(1, 0, 1);
            double disc2 = eq2;
            Console.WriteLine("Уравнение: " + eq2.ToString());
            Console.WriteLine("Дискриминант: " + disc2);
            bool hasRoots2 = (bool)eq2;
            Console.WriteLine("Корни существуют: " + hasRoots2);
            Console.WriteLine();

            QuadraticEquation eq3 = new QuadraticEquation(0, 2, 1);
            bool hasRoots3 = (bool)eq3;
            Console.WriteLine("Уравнение: " + eq3.ToString());
            Console.WriteLine("Корни существуют (a=0): " + hasRoots3);

            Console.WriteLine();
        }

        private static void _TestBinaryOperators()
        {
            Console.WriteLine("--- Тестирование бинарных операций == и != ---");

            QuadraticEquation eq1 = new QuadraticEquation(1, -5, 6);
            QuadraticEquation eq2 = new QuadraticEquation(1, -5, 6);
            QuadraticEquation eq3 = new QuadraticEquation(2, 3, 1);

            Console.WriteLine("eq1: " + eq1.ToString());
            Console.WriteLine("eq2: " + eq2.ToString());
            Console.WriteLine("eq3: " + eq3.ToString());
            Console.WriteLine();

            Console.WriteLine("eq1 == eq2: " + (eq1 == eq2));
            Console.WriteLine("eq1 != eq2: " + (eq1 != eq2));
            Console.WriteLine("eq1 == eq3: " + (eq1 == eq3));
            Console.WriteLine("eq1 != eq3: " + (eq1 != eq3));

            Console.WriteLine();
        }

        private static void _PrintRoots(QuadraticEquation eq)
        {
            double[] roots = eq.Solve();

            if (roots.Length == 0)
            {
                Console.WriteLine("Корней нет (D < 0).");
            }
            else if (roots.Length == 1)
            {
                Console.WriteLine("Один корень: x = " + roots[0]);
            }
            else
            {
                Console.WriteLine("Два корня: x1 = " + roots[0] + ", x2 = " + roots[1]);
            }
        }

        private static double _ReadDouble(string prompt)
        {
            double result;
            Console.Write(prompt);

            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Ошибка ввода. Введите вещественное число: ");
            }

            return result;
        }
    }
}
