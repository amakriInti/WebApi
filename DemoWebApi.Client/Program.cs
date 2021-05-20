using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://restcountries.eu/rest/v2/all
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://restcountries.eu/rest/v2/");
            var reponse = client.GetAsync("all");
            reponse.Wait();
            var result = reponse.Result;
            if (result.IsSuccessStatusCode)
            {
                var reader = result.Content.ReadAsStringAsync();
                reader.Wait();

                var data = JsonConvert.DeserializeObject<Pays[]>(reader.Result);

                foreach (var pays in data.Where(p => p.Region == "Africa"))
                {
                    Console.WriteLine(pays.Name);
                }
                Console.ReadLine();
            }
        }
    }
    public class Pays
    {
        public string Name;
        public string Region;
    }
}
