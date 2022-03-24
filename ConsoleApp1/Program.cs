using System;

namespace ConsoleApp1
{
    public class Program
    {
        public static double add(double a, double b)
        {
            return a + b;
        }
        public static double subtract(double a, double b)
        {
            return a - b;
        }
        public static double multiply(double a, double b)
        {
            return a * b;
        }
        public static double divide(double a, double b)
        {
            if (b == 0)
            {
                throw new Exception("CANNOT DIVIDE BY 0");
            }
            return a / b;
        }
        static void Main(string[] args)
        {
            int choice = -1;
            Console.WriteLine("Choose operation: \n1.a+b \n2.a-b \n3.a*b \n4.a/b\n");

            do
            {
                Console.WriteLine("Your choice:");
                choice = Convert.ToInt32(Console.ReadLine());
            } while (choice != 1 && choice != 2 && choice != 3 && choice != 4);

            Console.WriteLine("a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("b = ");
            double b = Convert.ToDouble(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine(a + " + " + b + " = " + add(a, b));
                    break;
                case 2:
                    Console.WriteLine(a + " - " + b + " = " + subtract(a, b));
                    break;
                case 3:
                    Console.WriteLine(a + " * " + b + " = " + multiply(a, b));
                    break;
                case 4:
                    Console.WriteLine(a + " / " + b + " = " + divide(a, b));
                    break;
            }
        }

    }
}
