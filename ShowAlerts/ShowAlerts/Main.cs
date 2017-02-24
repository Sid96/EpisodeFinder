using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;

namespace ShowAlerts
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckDB(search.Text))
            {
                return;
            }

            EpisodeInformation episode = new EpisodeInformation();
            
            using (WebClient wc = new WebClient())
            {
                try {
                    var json = wc.DownloadString(@"http://api.tvmaze.com/singlesearch/shows?q=" + search.Text);
                    
                    dynamic showJsonObject = JsonConvert.DeserializeObject(json);
                    episode.SetEpisodeName(showJsonObject.name);
                    if (showJsonObject._links.nextepisode != null)
                    {
                        var nextEpisodeLink = showJsonObject._links.nextepisode.href.Value;
                        episode.GetDateFromJson(wc, nextEpisodeLink, true);
                    }  

                    if (showJsonObject._links.previousepisode != null)
                    {
                        var prevEpisodeLink = showJsonObject._links.previousepisode.href.Value;
                        episode.GetDateFromJson(wc, prevEpisodeLink, false);
                    }                              
                    WriteToDB(search.Text, episode);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("404"))
                    {
                        MessageBox.Show("Could not find tv show");

                    }
                    else
                    {
                        MessageBox.Show("An unknown error has occured");
                    }
                }
            }
               
            

        }
        private static bool CheckDB(string searchText)
        {
            var connStr = ConfigurationManager.ConnectionStrings["ShowAlerts.Properties.Settings.ShowDBConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("Select * from [dbo].[Table] where ShowName = @ShowName");
                cmd.Parameters.AddWithValue("@ShowName", searchText);
                cmd.Connection = connection;
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        MessageBox.Show("This is already in the database");
                        return true;
                    }
                }
            }
            return false;
        }
        private static void WriteToDB(string searchText, EpisodeInformation episode)
        {
            var connStr = ConfigurationManager.ConnectionStrings["ShowAlerts.Properties.Settings.ShowDBConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connStr))
            {
                var cmd = new SqlCommand("Insert into [dbo].[Table] Values (@ShowName, @PrevDate, @PrevEpisode,@NextDate, @NextEpisode)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ShowName", episode.EpisodeName);
                cmd.Parameters.AddWithValue("@PrevDate", episode.PrevDate);
                cmd.Parameters.AddWithValue("@PrevEpisode", episode.PrevEpisode);
                cmd.Parameters.AddWithValue("@NextDate",episode.NextDate);
                cmd.Parameters.AddWithValue("@NextEpisode", episode.NextEpisode);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            System.Windows.Forms.MessageBox.Show("Success!");
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
