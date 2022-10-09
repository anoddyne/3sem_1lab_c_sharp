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
            double x, func, sum, last = 0, r, e; 
            int n, n_e, n_e10;

            Console.WriteLine("Задание 1\n");

            Console.Write("Введите значение аргумента: ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Задайте число слагаемых: ");
            n = Convert.ToInt32(Console.ReadLine());

            //вычисление точного значения функции
            func = Math.Sinh(x);
            Console.WriteLine("\nТочное значение функции равно: " + func);

            //цикл, который вычисляет частичную сумму ряда
            //присваиваем сумме ряда и временной переменной r, которая считает слагаемую дробь в каждом проходе, значение x, так как оно пропускается в цикле
            sum = x;
            r = x;
            for (int i = 1; i < n; i++)
            {
                r *= (x * x) / (2*i * (2*i + 1));
                sum += r;
                last = r;
            }
            Console.WriteLine("Частичная сумма ряда равна: " + sum);

            //вычисление абсолютного значения погрешности между точным значением функции и частичной суммой ряда
            double pogreshnost = Math.Abs(func - sum);
            Console.WriteLine("Абсолютная погрешность равна: " + pogreshnost + "\n");

            switch (pogreshnost > last)
            {
                case true:
                    Console.WriteLine("Погрешность больше чем последнее слагаемое.");
                    Console.WriteLine("Погрешность = " + pogreshnost + "; последнее слагаемое = " + last);
                    break;
                case false:
                    Console.WriteLine("Последнее слагаемое больше чем погрешность.");
                    Console.WriteLine("Погрешность = " + pogreshnost + "; последнее слагаемое = " + last);
                    break;
            }

            Console.WriteLine("\n" + "\n" + "Задание 2\n");

            Console.Write("Введите значение аргумента: ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.Write("Задайте точность вычислений: ");
            e = Convert.ToDouble(Console.ReadLine());

            func = Math.Sinh(x);
            Console.WriteLine("\nТочное значение функции равно: " + func);
            if (e <= 1 && e >= -1)
            {
                last = x;
                sum = x;
                for (n_e = 1; last > e; n_e++)
                {
                    last *= (x * x) / (2 * n_e * (2 * n_e + 1));
                    sum += last;
                }
                Console.WriteLine("Частичная сумма ряда c заданной точностью равна: " + sum);
                Console.WriteLine("Учтено " + n_e + " членов ряда" + "\n");

                last = x;
                sum = x;
                for (n_e10 = 1; last > (e / 10); n_e10++)
                {
                    last *= (x * x) / (2 * n_e10 * (2 * n_e10 + 1));
                    sum += last;
                }
                Console.WriteLine("Частичная сумма ряда c точностью, большей в 10 раз, равна " + sum);
                Console.WriteLine("Учтено " + n_e10 + " членов ряда");

                if (n_e > n_e10)
                {
                    Console.WriteLine("Слагаемых при обычной E больше");
                }
                else if (n_e < n_e10)
                { 
                    Console.WriteLine("Слагаемых при E/10 больше");
                } else
                {
                    Console.WriteLine("Слагаемых поровну");
                }

                Console.ReadLine();
            } else
            {
                Console.WriteLine("Введите число E в отрезке от -1 до 1!");
                Console.ReadLine();
            }
        }
    }
}
