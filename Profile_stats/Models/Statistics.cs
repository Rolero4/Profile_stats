using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Profile_stats.Models
{
    [Serializable]
    public class Statistics
    {
        public List<string[]> Statistcs { get; set; }
        public DateTime _date;


        public Statistics()
        {
            Statistcs = new List<string[]>();
            _date = DateTime.Now;
        }

        //List: [mmr, position], [wins, losses, draws] [winrate, lei], sk[matches, wins], sc[], mo[], nr[], ng[], sy[]
        public Statistics(string url)
        {
            //overall stats
            Statistcs = new List<string[]>();
            var stats_to_edit = Scrapper.GetStats(url);
            string[] mmr_position = new string[2] { stats_to_edit[15], stats_to_edit[16] };
            Statistcs.Add(mmr_position);
            string[] matches_stats = new string[3] { stats_to_edit[0], stats_to_edit[1], stats_to_edit[2],};
            Statistcs.Add(matches_stats);
            double wr = 0.0;
            if ((double.Parse(stats_to_edit[0]) + double.Parse(stats_to_edit[1]) + double.Parse(stats_to_edit[2])) != 0)
            {
                wr = Math.Round((double.Parse(stats_to_edit[0]) * 100) / (double.Parse(stats_to_edit[0]) + double.Parse(stats_to_edit[1]) + double.Parse(stats_to_edit[2])), 2);
            }



            //factions
            string[] skellige = new string[2] { stats_to_edit[5], stats_to_edit[13] };
            string[] scoia = new string[2] { stats_to_edit[6], stats_to_edit[12] };
            string[] monsters = new string[2] { stats_to_edit[7], stats_to_edit[9] };
            string[] nrealms = new string[2] { stats_to_edit[4], stats_to_edit[11] };
            string[] nilfgaard = new string[2] { stats_to_edit[8], stats_to_edit[10] };
            string[] syndicate = new string[2] { stats_to_edit[3], stats_to_edit[14] };


            //lei


            string[] wr_lei = new string[2] { wr.ToString() + "%", "Na" };

            Statistcs.Add(wr_lei);
            Statistcs.Add(skellige);
            Statistcs.Add(scoia);
            Statistcs.Add(monsters);
            Statistcs.Add(nrealms);
            Statistcs.Add(nilfgaard);
            Statistcs.Add(syndicate);

            int counter = 0;
            for (int i = 3; i < Statistcs.Count; i++)
            {
                if (int.Parse(Statistcs[i][0]) >= 25)
                {
                    counter++;
                }

            }

            if (counter >= 4)
            {
                string lei = Math.Round((double.Parse(Statistcs[0][0]) - 9600) / Math.Sqrt(double.Parse(stats_to_edit[0]) + double.Parse(stats_to_edit[1]) + double.Parse(stats_to_edit[2])), 2).ToString();
                Statistcs[2][1] = lei;
            }


            var src = DateTime.Now;
            var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);
            _date = hm;

        }

        public override string ToString()
        {
            string my_return = "";

            my_return += "Mmr: " + Statistcs[0][0] + " ";
            my_return += "Position: " + Statistcs[0][1] + "\n";

            my_return += "Wins: " + Statistcs[1][0] + "\n";
            my_return += "Losses: " + Statistcs[1][1] + "\n";
            my_return += "Draws: " + Statistcs[1][2] + "\n";

            my_return += "Winrate: " + Statistcs[2][0] + " ";
            my_return += "Lei: " + Statistcs[2][1] + "\n";

            string[] factions = new string[6] { "Skellige: ", "Scoia'tael: ", "Monsters: ", "Northern Realms: ", "Nilfgaard: ", "Syndicate: "};

            for (int i = 3; i < Statistcs.Count; i++)
            {
                my_return += factions[i - 3];

                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        my_return += Statistcs[i][j] + " matches";
                    }
                    else if (j == 1)
                    {
                        my_return += " " + Statistcs[i][j] + " wins";
                    }
                }
                my_return += "\n";
            }
            my_return += "Date of log: " + _date.ToString();
            return my_return;
        }


    }
}

//stats with ints
//_statistcs = new List<int[]>();
//var stats_to_edit = Scrapper.GetStats(url);
//int[] mmr_position = new int[2] { int.Parse(stats_to_edit[15]), int.Parse(stats_to_edit[16]) };
//_statistcs.Add(mmr_position);
//int[] matches_stats = new int[3] { int.Parse(stats_to_edit[0]), int.Parse(stats_to_edit[1]), int.Parse(stats_to_edit[2]), };
//_statistcs.Add(matches_stats);
//int[] wr_lei = new int[2] { int.Parse(stats_to_edit[0]) / (int.Parse(stats_to_edit[0]) + int.Parse(stats_to_edit[1]) + int.Parse(stats_to_edit[2])), int.Parse(stats_to_edit[16]) };
//_statistcs.Add(wr_lei);
//int[] skellige = new int[2] { int.Parse(stats_to_edit[5]), int.Parse(stats_to_edit[13]) };
//int[] scoia = new int[2] { int.Parse(stats_to_edit[6]), int.Parse(stats_to_edit[12]) };
//int[] monsters = new int[2] { int.Parse(stats_to_edit[7]), int.Parse(stats_to_edit[9]) };
//int[] nrealms = new int[2] { int.Parse(stats_to_edit[4]), int.Parse(stats_to_edit[11]) };
//int[] nilfgaard = new int[2] { int.Parse(stats_to_edit[8]), int.Parse(stats_to_edit[10]) };
//int[] syndicate = new int[2] { int.Parse(stats_to_edit[3]), int.Parse(stats_to_edit[14]) };

//var src = DateTime.Now;
//var hm = new DateTime(src.Year, src.Month, src.Day, src.Hour, src.Minute, 0);
