using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;
using RestSharp.Deserializers;

namespace ConsoleApp1
{
    class Tobacco
    {


        public List<toRelease> getJSON()
        {
            //JArray releases = new JArray();
            toRelease myReleases = new toRelease();
            int i = 0;
            List<toRelease> releases = new List<toRelease>();
            //IRestResponse<List<Release> response = new IRestResponse<List<Release>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                string url = "https://data.novascotia.ca/resource/n8h5-t3dm.json";

                RestSharpGet myGetURL = new RestSharpGet();

                myGetURL.getURL(url);

                var client = new RestClient(url);

                //var response = httpClient.GetStringAsync(new Uri(url)).Result;
                var response = client.Execute<List<toRelease>>(new RestRequest());

                releases = response.Data;
                //releases = JArray.Parse(response.Content);
                foreach (var release in releases)
                {
                    if (release.RESPONSE == "Definitely")
                    {
                        Console.WriteLine(release.RESPONSE);
                        i++;
                    }
                }
                Console.WriteLine(i);
                Console.ReadLine();
            }
            return releases;
        }



        //foreach (var release in releases)
        //{
        //    Console.WriteLine(release.Root.ToList());



        //}

        public class toRelease
        {
            [DeserializeAs(Name = "RESPONSE")]
            public string RESPONSE { get; set; }
        }


    }


}

