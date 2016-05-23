using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShowFinder
{
    class Links
    {
        Link self;
        Link previousepisode;
        Link nextepisode;
    }
    class Link
    {
        string href;
    }
    class Program
    {
        //API: 9158E1025A950341
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of a TV Show");
            var input = Console.ReadLine();
            var airDate = "Invalid";                                
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(@"http://api.tvmaze.com/singlesearch/shows?q="+ input);
                dynamic jsonObject = JsonConvert.DeserializeObject(json);
                var nextEpisodeLink = jsonObject._links.nextepisode.href.Value;
                json = wc.DownloadString(nextEpisodeLink);
                jsonObject = JsonConvert.DeserializeObject(json);
                airDate = jsonObject.airdate.Value+" "+jsonObject.airtime.Value+"EST";                     

            }
            Console.WriteLine(airDate);
        }
    }
}
