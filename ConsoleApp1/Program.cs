using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;

namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            JArray releases = new JArray();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                string url = "https://data.novascotia.ca/resource/dy4w-s8zb.json";

                RestSharpGet myGetURL = new RestSharpGet();

                myGetURL.getURL(url);

                var client = new RestClient(url);

                //var response = httpClient.GetStringAsync(new Uri(url)).Result;
                IRestResponse response = client.Execute(new RestRequest());

                releases = JArray.Parse(response.Content);
            }


            //foreach (var release in releases)
            //{
            //    Console.WriteLine(release.Root.ToList());


                
            //}

            foreach(var newrelease in releases.ToList())
            {
                Console.WriteLine(newrelease);
                Console.ReadLine();
            }


        }

        public class RestSharpGet {

            //RestSharpGet getInfo = new RestSharpGet();
            
            public string getURL (string URL)
            {
                return URL;
            }

            }
    }
}
