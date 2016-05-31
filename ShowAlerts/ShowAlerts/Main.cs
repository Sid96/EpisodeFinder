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

            Tuple<string, string> airDate;
            Tuple<string, string> prevDate;
            
            using (WebClient wc = new WebClient())
            {
                try {
                    var json = wc.DownloadString(@"http://api.tvmaze.com/singlesearch/shows?q=" + search.Text);
                    dynamic showJsonObject = JsonConvert.DeserializeObject(json);
                    if (showJsonObject._links.nextepisode != null)
                    {
                        var nextEpisodeLink = showJsonObject._links.nextepisode.href.Value;
                        airDate = GetDateFromJson(wc, nextEpisodeLink);
                    }
                    else
                    {
                        airDate = new Tuple<string, string>("Unknown", "Unknown");
                    }

                    if (showJsonObject._links.previousepisode != null)
                    {
                        var prevEpisodeLink = showJsonObject._links.previousepisode.href.Value;
                        prevDate = GetDateFromJson(wc, prevEpisodeLink);
                    }
                    else
                    {
                        prevDate = new Tuple<string, string>("Unknown", "Unknown");
                    }
                    WriteToDB(search.Text, prevDate, airDate);
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
        private static void WriteToDB(string searchText, Tuple<string,string> prevDate, Tuple<string,string> airDate)
        {
            var connStr = ConfigurationManager.ConnectionStrings["ShowAlerts.Properties.Settings.ShowDBConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connStr))
            {   
                var cmd = new SqlCommand("Insert into [dbo].[Table] Values (@ShowName, @PrevDate, @PrevEpisode,@NextDate, @NextEpisode)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@ShowName",searchText);
                cmd.Parameters.AddWithValue("@PrevDate", prevDate.Item1);
                cmd.Parameters.AddWithValue("@PrevEpisode", prevDate.Item2);
                cmd.Parameters.AddWithValue("@NextDate", airDate.Item1);
                cmd.Parameters.AddWithValue("@NextEpisode", airDate.Item2);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            System.Windows.Forms.MessageBox.Show("Success!");
        }
        private static Tuple<string,string> GetDateFromJson(WebClient wc, dynamic nextEpisodeLink)
        {
            var json = wc.DownloadString(nextEpisodeLink);
            dynamic jsonObject = JsonConvert.DeserializeObject(json);
            //var a = jsonObject.airstamp.Value;
            var b = new Tuple<string, string>(jsonObject.airstamp.Value.ToString(),"S"+jsonObject.season+"E"+jsonObject.number.ToString("D2"));

            return b;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
