using System.Diagnostics.CodeAnalysis;

namespace Assignment
{
    internal class Program
    {
        static int number1()
        {
            int num1 = Convert.ToInt32(Console.ReadLine());
            return num1;
        }
       
        static void AddTwoNumber()
        {
            Console.WriteLine("Please enter a number");
            int num1 = number1();
            Console.WriteLine("Please enter a number");
            int num2 = number1();
            int sum = num1+num2;
            Console.WriteLine($"Sum of {num1} and {num2} is {sum}");
        }
        static void BiggestNumber()
        {
            Console.WriteLine("Please enter a number");
            int num1 = number1();
            Console.WriteLine("Please enter a number");
            int num2 = number1();
            if(num1 > num2)
                Console.WriteLine($"The biggest number is {num1}");
            else
                Console.WriteLine($"The biggest number is {num2}");
        }
        static void CheckIfItEven()
        {
            Console.WriteLine("Please enter a number");
            int num1 = number1();
            if(num1%2==0)
                Console.WriteLine("The given number is even number");
            else
                Console.WriteLine("The given number is not a even number");
        }
        static void CheckPrimeNumber()
        {
            Console.WriteLine("Please enter a number");
            int num1 = number1();
            int temp = 0;
            for(int i = 2; i < num1 / 2; i++)
            {
                if (num1 % i == 0)
                    temp++;
            }
            if(temp==0)
                Console.WriteLine("The given number is Prime Number");
            else
                Console.WriteLine("The given number is not a Prime Number");
        }
        static void FindSquare()
        {
            Console.WriteLine("Please enter a number");
            int num1 = number1();
            int square = num1 * num1;
            Console.WriteLine($"The square of given number is {square}");
        }
        static void FindAverage()
        {
            int num1,sum=0;
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Please enter a number");
                num1 = number1();
                sum += num1;
            }
            int average=sum/10;
            Console.WriteLine($"The average of ten number is {average}");
        }
        static void Main(string[] args)
        {
            AddTwoNumber();
            BiggestNumber();
            CheckIfItEven();
            CheckPrimeNumber();
            FindSquare();
            FindAverage();
        }
    }
}