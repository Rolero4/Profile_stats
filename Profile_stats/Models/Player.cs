using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Profile_stats.Models
{
	[Serializable]
	public class Player
    {
		[XmlAttribute("Name")]
		public string _name;
		[XmlAttribute("Url")]
		public string _url;
		[XmlArray("Stats")]
		public List<Statistics> _stats;

		public Player()
		{
			_name = "Not found";
			_url = "https://www.playgwent.com/en/profile/notfound";
			_stats = new List<Statistics>();
		}		

		public Player(string name)
		{
			_name = name;
			_url = "https://www.playgwent.com/en/profile/"+name;
			_stats = new List<Statistics>();
			AddLog();
		}

        public void AddLog()
        {
            var stats_object = new Statistics(this._url);
            _stats.Add(stats_object);
        }

		public int Logs()
        {
			return this._stats.Count;
        }

		public override string ToString()
        {
			return this._name;
        }


		//public string ToString()
  //      {
		//	string str = "";
		//	foreach (Statistics stat in _stats)
  //          {
		//		str += stat.ToString();
  //          }
		//	return str;
		//}

		public string ToString(int x)
		{
			return _stats[x].ToString();
		}


	}
}
