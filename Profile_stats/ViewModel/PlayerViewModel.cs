using Profile_stats.Models;

namespace Profile_stats.ViewModel
{
    public class PlayerViewModel
    {

        private Player mPlayer;
        private string description;


        public PlayerViewModel() 
        {
            mPlayer = new Player();
            description = this.ToString();

        }

        public PlayerViewModel(string name)
        {
            mPlayer = new Player(name);
            description = this.ToString();
        }

        public override string ToString()
        {
            return mPlayer.ToString();
        }

    }
}
