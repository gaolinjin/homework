using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arga;
            arga=new int[3];
            arga[0]=1;
            arga[1]=2;
            arga[2]=4;
            SF.Sfun(arga,out int max,out int min,out double ave,out double sum);
            Console.WriteLine("Max:"+max+" Min:"+min+" Ave:"+ave+" Sum:"+sum);
        } 
    }
    class SF{
        static public void Sfun(int[] a,out int max,out int min,out double ave,out double sum){
            max=a[0];
            min=a[0];
            sum=0;
            foreach (int num in a)
            {
                if(num>max) max=num;
                if(num<min) min=num;
                sum+=num;
            }
            ave=sum/a.Length;
        }
    }
}
