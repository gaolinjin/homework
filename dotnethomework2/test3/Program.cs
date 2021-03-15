using System;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {
            int divisor=2;
            int []a=new int[99];
            for(int i=0;i<a.Length;i++){
                a[i]=i+2;
            }
            while (divisor<10)
            {
                for(int i=0;i<a.Length;i++){
                    if(a[i]/divisor>1&&a[i]%divisor==0) a[i]=0;
                }
                divisor++;
            }
            for(int i=0;i<a.Length;i++){
                if(a[i]!=0) Console.Write(" "+a[i]);
            }
        }
    }
}
