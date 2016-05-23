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
    class Program
    {
        //API: 9158E1025A950341
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of a TV Show");
            var input = Console.ReadLine();
            var airDate = "Invalid";
            var prevDate = "Invalid";                             
            using (WebClient wc = new WebClient())
            {                    
                var json = wc.DownloadString(@"http://api.tvmaze.com/singlesearch/shows?q="+ input);
                dynamic showJsonObject = JsonConvert.DeserializeObject(json);
                if (showJsonObject._links.nextepisode != null)
                {
                    var nextEpisodeLink = showJsonObject._links.nextepisode.href.Value;
                    airDate = GetDateFromJson(wc, nextEpisodeLink);
                }
                else
                {                                                      
                    airDate = "Future episodes unknown"; 
                }
                
                if (showJsonObject._links.previousepisode!= null)
                {
                    var prevEpisodeLink = showJsonObject._links.previousepisode.href.Value;
                    prevDate = GetDateFromJson(wc, prevEpisodeLink);
                }
                else
                {
                    prevDate = "No previous episodes";
                }
            }
            Console.WriteLine("Next Episode: "+ airDate);
            Console.WriteLine("Prev Episode: "+prevDate);
            Console.ReadKey();
        }

        private static string GetDateFromJson(WebClient wc, dynamic nextEpisodeLink)
        {
            var json = wc.DownloadString(nextEpisodeLink);
            dynamic jsonObject = JsonConvert.DeserializeObject(json);
            var a = jsonObject.airstamp.Value;
            return "S"+jsonObject.season+"E"+jsonObject.number.ToString("D2")+" - "+a.ToString();
        }
    }
}
