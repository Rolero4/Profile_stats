using Profile_stats.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Profile_stats.ViewModel
{
    class PlayersViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //Players
        private Players _playersViewModel;

        private Player _profile;


        //Konstruktor
        public PlayersViewModel()
        {
            _playersViewModel = new Players();
            _playersViewModel.Deserialize();
            //InfoText = playersViewModel._Players[0]._stats[1].ToString();

        }

        public Player Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        public ObservableCollection<Player> Players => _playersViewModel._Players;

        private ICommand _playerChanged;
        public ICommand PlayerChanged
        {
            get
            {
                if (_playerChanged == null)
                {
                    _playerChanged = new RelayCommand(
                        arg => {
                            InfoText = Profile.ToString();

                            //zgłoszenie zmiany właściwości               
                            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InfoText)));
                        },

                        arg => true

                        );
                }
                return _playerChanged;
            }
        }
        public string InfoText { get; set; }
    }
}
