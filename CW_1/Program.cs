using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CW_1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            var client = new HttpClient();
            var result =await client.GetAsync("https://www.pja.edu.pl");

            Console.WriteLine("Koniec!");

        }
    }
}
