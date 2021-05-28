using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient hc = new HttpClient();
            string html=hc.GetStringAsync("https://localhost:44334/api/Order?i=1?c=ds").Result;
            Console.WriteLine(html);
            Console.ReadKey();


        }
    }
}
