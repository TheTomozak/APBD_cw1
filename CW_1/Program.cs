using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CW_1
{

    public class Student
    {
        public string Imie { get; set; }

        private string _nazwisko;

        public string Nazwsiko
        {
            get { return _nazwisko; }
            set
            {
                //if (value == null) throw new ArgumentException();
                _nazwisko = value;
            }
        }
    }
    public class Program
    {
        public static async Task Main(string[] args)
        {

            string url = args.Length > 0 ? args [0] : "https://www.pja.edu.pl";


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
