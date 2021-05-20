using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.Client2
{
    class Test
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            // http://localhost:65447/api/Values/
            var client = new HttpClient();
            // Avec Id
            //client.BaseAddress = new Uri("http://localhost:65447/api/Values/333");
            // Sans Id
            //client.BaseAddress = new Uri("http://localhost:65447/api/Values/");

            // Get
            //var reponse = client.GetAsync("");

            // Post
            var httpContent = new StringContent("Test");
            var reponse = client.PostAsync("http://localhost:65447/api/Values/",  httpContent);
            reponse.Wait();

            var result = reponse.Result;
            if (result.IsSuccessStatusCode)
            {
                var reader = result.Content.ReadAsStringAsync();
                reader.Wait();

                // Appel à Get sans id
                //var data = JsonConvert.DeserializeObject<string[]>(reader.Result);
                //foreach (var s in data)
                //{
                //    Console.WriteLine(s);
                //}

                // Appel à Get avec id
                var data = reader.Result;
                Console.WriteLine(data);

                Console.ReadLine();
            }
        }
    }
}
