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
    class Program
    {
        

        static void Main(string[] args)
        {
            //JArray releases = new JArray();
            abRelease myReleases = new abRelease();
            int i = 0;
            Tobacco tobacco = new Tobacco();
            List<Tobacco.toRelease> tobaccoHolder = new List<Tobacco.toRelease>();
            //IRestResponse<List<Release> response = new IRestResponse<List<Release>();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                string url = "https://data.novascotia.ca/resource/dy4w-s8zb.json";

                RestSharpGet myGetURL = new RestSharpGet();

                myGetURL.getURL(url);

                var client = new RestClient(url);

                //var response = httpClient.GetStringAsync(new Uri(url)).Result;
                var response = client.Execute<List<abRelease>>(new RestRequest());

                var releases = response.Data;
                //releases = JArray.Parse(response.Content);
                foreach (var release in releases)
                {
                    if (release.Absence_Type_Category == "Sick_Unpaid") {
                        Console.WriteLine(release.Absence_Type);
                        Console.WriteLine(release.Employee_Type);
                        i++;
                    }
                }
                Console.WriteLine(i);
                
            }

            tobaccoHolder = tobacco.getJSON();
            Console.ReadLine();
        }
        


            //foreach (var release in releases)
            //{
            //    Console.WriteLine(release.Root.ToList());



            //}

        public class abRelease
        {
            [DeserializeAs(Name = "Gender")]
            public string Gender { get; set; }
            [DeserializeAs(Name = "Absence_Type")]
            public string Absence_Type { get; set; }
            [DeserializeAs(Name = "Employee_Type")]
            public string Employee_Type { get; set; }
            [DeserializeAs(Name = "Absence_Type_Category")]
            public string Absence_Type_Category { get; set; }
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

