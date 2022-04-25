using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Profile_stats.Models
{
    [Serializable]
    [XmlRoot("Players")]

    public class Players
    {
        public ObservableCollection<Player> _Players;
        public int _PlayersCount;

        public Players()
        {
            this._Players = new ObservableCollection<Player>();
        }

        public Players(Player player)
        {
            _Players = new ObservableCollection<Player>
            {
                player
            };
        }

        public Players(ObservableCollection<Player> players)
        {
            _Players = players;
        }


        public ObservableCollection<string> List_of_Players()
        {
            var my_return = new ObservableCollection<string>();
            foreach (Player p in _Players)
            {
                my_return.Add(p._name);
            }

            return my_return;
        }
        public void Add_Player(Player player)
        {
            _Players.Add(player);
        }

        public Player? Find(string name)
        {
            for (int i = 0; i < _Players.Count; i++)
            {
                Player p = _Players[i];
                if (p._name == name)
                    return p;
            }
            return null;
        }


        public void Serialize()
        {
            Stream stream = File.Create(Environment.CurrentDirectory + "\\Data/listOfPlayers.txt");
            var xmlser = new XmlSerializer(typeof(Players));
            xmlser.Serialize(stream, this);
            stream.Close();
        }

        public void Deserialize()
        {
            var xmlser = new XmlSerializer(typeof(Players));
            if (File.Exists(Environment.CurrentDirectory + "\\Data/listOfPlayers.txt"))
            {
                using FileStream fileStream = new(Environment.CurrentDirectory + "\\Data/listOfPlayers.txt", FileMode.Open);
                var obj = (Players)xmlser.Deserialize(fileStream);
                this._Players = obj._Players;
            }
            else
            {
                this._Players = new ObservableCollection<Player>();
            }
        }


    }
}
