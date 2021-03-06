using System;

namespace dotnetcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入第一个数字!");
            double num1=Double.Parse(Console.ReadLine());
            Console.WriteLine("请输入第二个数字!");
            double num2=Double.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符!");
            string cal=Console.ReadLine();
            double result=0;
            switch (cal)
            {
                case "+":result=num1+num2;break;
                case "-":result=num1-num2;break;
                case "*":result=num1*num2;break;
                case "/":result=num1/num2;break;
                default:break;
            }
            Console.WriteLine(result);
        }
    }
}
