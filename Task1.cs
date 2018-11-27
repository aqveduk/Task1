/*

VLADIMIR RAEVSKIY GEEKBRAINS LESSON6
TASK1 

1. Изменить программу вывода функции так, 
чтобы можно было передавать функции типа double (double,double).
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

*/

using System;


namespace ConsoleApp2
{
    public delegate double Fun(double x, double a);

    class Program
    {
        public static void Table(Fun F, double x, double b, double a)
        {

            Console.WriteLine(" ----- X ----- Y ----- ");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x,a));
                x += 1;
            }
            Console.WriteLine("---------------------");

        }
        public static double MyFunc(double x, double a)
        {
            return a * (x * x);
        }
        public static double SinFun(double x, double a)
        {
            return a * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            int a = 0;
            Console.WriteLine(" Table of function MyFunc (a * x ^ 2): ");
            Table(MyFunc, -6, 6, 5);

            Console.WriteLine(" Table of funcion a * Sin(x) (x = rad): ");
            Table(SinFun, -6, 6, 5);


            Console.ReadKey();
        }
    }
}
