using System;
using System.Collections.Generic;
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
        /// make the power times 2
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double SecondPow(double x)
        {
            return x * x;
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

        public static void Menu(out double minL)
        {
            minL = 0;
            var delList = new List<Fun> { F, SecondPow, ThirdPow };
            string min = "";
            string max = "";
            bool flag = true;
            Console.WriteLine("Welcome! Please select a function: \n1. X^2 - 50*x + 10\n2.x^2\n3.x^3");
            while (flag)
            {
                try
                {
                    string answer = Console.ReadLine();


                if (int.Parse(answer) <= 3 && int.Parse(answer) > 0)
                {
                    Console.WriteLine("Please enter the first value to set the range:");
                    min = Console.ReadLine();
                    Console.WriteLine("Please enter the second value to set the range:");
                    max = Console.ReadLine();
                }

                    switch (answer)
                    {
                        case "1":


                            SaveFunc("data.bin", delList[0], double.Parse(min), double.Parse(max), 1);
                            PrintArray(Load("data.bin", out minL));
                            flag = false;
                            break;

                        case "2":

                            SaveFunc("data.bin", delList[1], double.Parse(min), double.Parse(max), 1);  //power times 2
                            PrintArray(Load("data.bin", out minL));
                            flag = false;
                            break;

                        case "3":

                            SaveFunc("data.bin", delList[2], double.Parse(min), double.Parse(max), 1);  //power times 3
                            PrintArray(Load("data.bin", out minL));
                            flag = false;
                            break;

                        default:
                            Console.WriteLine("Wrong value! Try again!");
                            break;

                    }
                }
                catch { Console.WriteLine("You've entered unacceptable value!"); }
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

        public static List<double> Load(string fileName, out double minL)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            
            minL = double.MaxValue;
            int count = 1;
            List<double> arr = new List<double>();

            double d;

            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                d = bw.ReadDouble();
                arr.Add(d);
                if (d < minL)  minL = d;
                count++;
            }
            bw.Close();
            fs.Close();
            return arr;
        }

        public static void PrintArray(List<double> arr)
        {
            Console.Write("\n\nElements of array: [ ");
            foreach (double elem in arr)
            {
                Console.Write( elem + "  ");
            }
            Console.Write("]");

        }

        static void Main(string[] args)
        {
            double min;
            Menu(out min);

            Console.WriteLine("\nThe minimum of function is  : {0}", min);

            Console.ReadKey();
        }
    }


}
