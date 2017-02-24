using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShowAlerts
{
    public class EpisodeInformation
    {
        public string EpisodeName { get; private set; }
        public string PrevDate { get; private set; }
        public string PrevEpisode { get; private set; }
        public string NextDate { get; private set; }
        public string NextEpisode { get; private set; }



        public EpisodeInformation()
        {
            PrevDate = "Unknown";
            PrevEpisode = "Unknown";
            NextDate = "Unknown";
            NextEpisode = "Unknown";
        }

        public bool GetDateFromJson(WebClient wc, dynamic episodeLink, bool isNextDate)
        {
            var json = wc.DownloadString(episodeLink);
            dynamic jsonObject = JsonConvert.DeserializeObject(json);
            //var a = jsonObject.airstamp.Value;
            if (isNextDate)
            {
                NextDate = jsonObject.airstamp.Value.ToString();
                NextEpisode = "S" + jsonObject.season + "E" + jsonObject.number.ToString("D2");
            }
            else
            {
                PrevDate = jsonObject.airstamp.Value.ToString();
                PrevEpisode = "S" + jsonObject.season + "E" + jsonObject.number.ToString("D2");
            }

            return true;
        }

        internal void SetEpisodeName(dynamic name)
        {
            EpisodeName = name;
        }
    }    
}
