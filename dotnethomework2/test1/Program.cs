using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("素数分解你的数!");
            int num = Int32.Parse(Console.ReadLine());
            int divisor = 2;
            while(divisor<=num){
                if(num % divisor==0){
                    num /= divisor;
                    Console.WriteLine(divisor);
                }else{
                    divisor++;
                }
            }
        }
    }
}
