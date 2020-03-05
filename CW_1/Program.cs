using System;
using System.Collections.Generic;
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
            try
            {
                var client = new HttpClient();
                var result = await client.GetAsync("https://www.pja.edu.pl");


                if (!result.IsSuccessStatusCode) return;

                //Kolekcje 
                var zbiory = new HashSet<string>();
                var listy = new List<string>();
                var slownik = new Dictionary<string, int>();

                string html = await result.Content.ReadAsStringAsync();
                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+", RegexOptions.IgnoreCase);

                var mathches = regex.Matches(html);

                foreach (var m in mathches)
                {
                    Console.WriteLine(m);
                }
            }catch(Exception ex)
            {
                string s = string.Format("wystapil blad {0}", ex.ToString()); // tak mozna laczyc strigi 
                Console.WriteLine("Wystapil blad" + ex.ToString()); // tak nie robmy

                Console.WriteLine($"Wystapil blad{ex.ToString()}"); // tak najlpeiej laczyc stringi 
            }

            Console.WriteLine("Koniec!");

        }
    }
}
