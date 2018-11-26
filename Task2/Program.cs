using System;
using System.IO;

namespace DoubleBinary
{
    class Program
    {
        /// <summary>
        /// delegate functions with 1 parametr x
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public delegate double Fun(double x);

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        /// <summary>
        /// make the power times 3
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double ThirdPow(double x)
        {
            return x * x * x;
        }

        public static void Menu()
        {
            bool flag = true;
            Console.WriteLine("Welcome! Please select a function: \n1. X^2 - 50*x + 10\n2.x^3");
            while (flag)
            {
                string answer = Console.ReadLine();


                Console.WriteLine("Please enter the first value for range beginning: ");
                string min = Console.ReadLine();

                Console.WriteLine("Please enter the second value for range end: ");
                string max = Console.ReadLine();


                if (answer == "1")
                {

                    Console.Write("Result: ");
                    SaveFunc("data.bin", F, double.Parse(min), double.Parse(max), 1);
                    Console.WriteLine(Load("data.bin"));
                    flag = false;
                }
                else if (answer == "2")
                {
                    Console.Write("Result: ");
                    SaveFunc("data.bin", ThirdPow, double.Parse(min), double.Parse(max), 1);  //power times 3
                    Console.WriteLine(Load("data.bin"));
                    flag = false;
                }
                else
                    Console.WriteLine("Wrong value! Try again!");
            }
        }

        public static void SaveFunc(string fileName, Fun Fu, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(Fu(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            Menu();

            Console.ReadKey();
        }
    }


}
