//Задача 1, вариант 16, Бесшапошников Владимир
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _3sem_1lab_c_sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление значений функции sinh(x):");
            double x, func, sum = 0, last = 0, r, e; int n;
            Console.WriteLine("Задание 1\n");
            Console.Write("Введите значение аргумента: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Задайте число слагаемых: ");
            n = int.Parse(Console.ReadLine());
            func = Math.Sinh(x);
            Console.WriteLine("\nТочное значение функции равно: " + func);

            sum = x;
            r = x;
            for (int i = 1; i < n; i++)
            {
                r *= (x * x) / (2*i * (2*i + 1));
                sum += r;
                last = r;
            }
            Console.WriteLine("Частичная сумма ряда равна: " + sum);

            double pogreshnost = Math.Abs(func - sum);
            Console.WriteLine("Абсолютная погрешность равна: " + pogreshnost + "\n");
            if (pogreshnost > last)
            {
                Console.WriteLine("Погрешность больше чем последнее слагаемое.");
                Console.WriteLine("Погрешность = " + pogreshnost + "; последнее слагаемое = " + last);
            }
            else
            {
                Console.WriteLine("Последнее слагаемое больше чем погрешность.");
                Console.WriteLine("Погрешность = " + pogreshnost + "; последнее слагаемое = " + last + "\n");
            }

            Console.WriteLine("Задание 2\n");
            Console.Write("Введите значение аргумента: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Задайте точность вычислений: ");
            e = double.Parse(Console.ReadLine());

            Console.WriteLine("\nТочное значение функции равно: " + func);

            last = x;
            sum = x;
            for (n = 1; last > e; n++)
            {
                last *= (x * x) / (2 * n * (2 * n + 1));
                sum += last; 
            }
            Console.WriteLine("Частичная сумма ряда c заданной точностью равна: " + sum);
            Console.WriteLine("Учтено " + n + " членов ряда");

            last = x;
            sum = x;
            for (n = 1; last > e/10; n++)
            {
                last *= (x * x) / (2 * n * (2 * n + 1));
                sum += last;
            }
            Console.WriteLine("Частичная сумма ряда c точностью, большей в 10 раз, равна " + sum);
            Console.WriteLine("Учтено " + n + " членов ряда");

            Console.ReadLine();
        }
    }
}
