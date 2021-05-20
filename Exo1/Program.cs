using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exo1
{
    class Program
    {
        static void Main(string[] args)
        {            
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://restcountries.eu/rest/v2/alpha?codes=col;no;ee;fr;gb;ch");
            var reponse = client.GetAsync("");
            reponse.Wait();
            var result = reponse.Result;
            if (result.IsSuccessStatusCode)
            {
                var reader = result.Content.ReadAsStringAsync();
                reader.Wait();

                var data = JsonConvert.DeserializeObject<Pays[]>(reader.Result);

                foreach (var pays in data)
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
    }

}
