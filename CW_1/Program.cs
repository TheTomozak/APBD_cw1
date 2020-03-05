using System;
using System.Net.Http;
using System.Text.RegularExpressions;
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


            if (!result.IsSuccessStatusCode) return;

            string html = await result.Content.ReadAsStringAsync();
            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+", RegexOptions.IgnoreCase);

            var mathches = regex.Matches(html);

            foreach(var m in mathches)
            {
                Console.WriteLine(m);
            }


            Console.WriteLine("Koniec!");

        }
    }
}
