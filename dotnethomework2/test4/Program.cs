using System;

namespace test4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arg1={{1,2,3,4},{2,1,3,4},{2,3,1,4}};
            Console.WriteLine("arg1:"+Func.fun(arg1));
            int[,] arg2={{1,2,3,4},{2,1,3,4},{2,3,2,4}};
            Console.WriteLine("arg2:"+Func.fun(arg2));
        }
    }
    class Func
    {
        static public bool fun(int[,] a){
            bool b = true;
            int m=0;
            while (m<a.GetLength(0)&&m<a.GetLength(1))
            {
                if(a[0,0]!=a[m,m]) b=false;
                m++;
            }
            return b;
        }
    }
}
