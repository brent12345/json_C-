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
        string x = new StringBuilder(@"TABLE AD10: Do you currently smoke tobacco cigarettes?").ToString(); 
        private const string V1 = @"TABLE AD8: Please indicate whether you would definitely, probably, probably not, or definitely not consider purchasing tobacco or cigarettes from an unlicensed dealer, that is, where the tobacco has not been properly taxed?";

        public List<toRelease> getJSON()
        {
            //JArray releases = new JArray();
            toRelease myReleases = new toRelease();
            int definitely = 0;
            int probably = 0;
            int definitely_not = 0;
            int lines = 0;
            int Probably_not = 0;
            int smoker = 0;
            int nonSmoker = 0;
            int refused = 0;
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
                    if (release.TABLE == V1)
                    {

                        if (release.RESPONSE == "Definitely")
                        {
                            Console.WriteLine(release.RESPONSE);
                            definitely++;
                        }
                        if (release.RESPONSE == "Probably")
                        {
                            Console.WriteLine(release.RESPONSE);
                            probably++;
                        }
                        if (release.RESPONSE == "Definitely not")
                        {
                            Console.WriteLine(release.RESPONSE);
                            definitely_not++;
                        }
                        if (release.RESPONSE == "Probably not")
                        {
                            Console.WriteLine(release.RESPONSE);
                            Probably_not++;
                        }
                    }
                    
                    object y = new StringBuilder(release.TABLE).ToString().Replace(" ", string.Empty);
                    var result = "TABLEAD10:Doyoucurrentlysmoketobaccocigarettes?".Equals(y);
                    
                    if (result)
                    {
                        if (release.RESPONSE == "Yes")
                        {
                            Console.WriteLine("Is a smoker:" + release.RESPONSE);
                            smoker++;
                        } else
                        {
                            nonSmoker++;
                        }

                        if (release.RESPONSE == "Refused")
                            {
                                Console.WriteLine("Refused:" + release.RESPONSE);
                                refused++;
                            }
                            else
                            {
                                
                            }
                    }

                        lines++;
                }
                Console.WriteLine(definitely);
                Console.WriteLine(probably);
                Console.WriteLine(definitely_not);
                Console.WriteLine(Probably_not);
                Console.WriteLine("Is a Smoker:" + smoker);
                Console.WriteLine("Not a Smoker:" + nonSmoker);
                Console.WriteLine("Refused:" + refused);
                Console.WriteLine(lines);
            }
            return releases;
        }



        //foreach (var release in releases)
        //{
        //    Console.WriteLine(release.Root.ToList());



        //}

        public class toRelease
        {
            [DeserializeAs(Name = "TABLE")]
            public string TABLE { get; set; }
            [DeserializeAs(Name = "RESPONSE")]
            public string RESPONSE { get; set; }
        }


    }


}

