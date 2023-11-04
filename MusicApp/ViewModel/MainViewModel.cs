using MusicApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace MusicApp.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            musicList = GetMusics();
            recentMusic = musicList.Where(x => x.IsRecent == true).FirstOrDefault();
        }

        ObservableCollection<Music> musicList;
        public ObservableCollection<Music> MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
                OnPropertyChanged();
            }
        }

        private Music recentMusic;
        public Music RecentMusic
        {
            get { return recentMusic; }
            set
            {
                recentMusic = value;
                OnPropertyChanged();
            }
        }

        private Music selectedMusic;
        public Music SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMusic);

        private void PlayMusic()
        {
            if (selectedMusic != null)
            {
                var viewModel = new PlayerViewModel(selectedMusic, musicList);
                var playerPage = new PlayerPage { BindingContext = viewModel };

                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playerPage, true);
            }
        }



        private ObservableCollection<Music> GetMusics()
        {
            return new ObservableCollection<Music> 
            {
                //music from NCS.io (nocpyrightsounds)
                new Music { Title = "Dancing On the Moon", Artist = "Luke Burr, Unknown Brain", Url = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/820/dancing-on-the-moon-1599217228-vual57Vf1E.mp3" , CoverImage = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/820/850x850/dancing-on-the-moon-1599217225-5lQzAHfpOq.jpg"},
                new Music { Title = "Devil", Artist = "Barren Gates", Url = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/813/devil-1597924828-ZaFzhQ6OyL.mp3", CoverImage = "https://linkstorage.linkfire.com/medialinks/images/420c24c1-4895-4f7c-a467-16be77b60c0c/artwork-440x440.jpg"},
                new Music { Title = "Better Off", Artist = "Slashtaq, Wanden", Url = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/780/better-off-1597319410-vHK5QNbOt2.mp3", CoverImage = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/815/325x325/murderer-1598356826-Rp0M7TmOM7.jpg", IsRecent = true},
                new Music { Title = "Everyday", Artist = "Ashley Apollodor, Beatcore", Url = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/699/everyday-1586960534-yFdltahwSU.mp3"},
                new Music { Title = "Apocalypse", Artist = "Midranger", Url = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/827/apocalypse-1600776029-SD10P62Tu0.mp3"},
                new Music { Title = "Afterlife", Artist = "EMM, Besomorph", Url = "https://ncsmusic.s3.eu-west-1.amazonaws.com/tracks/000/000/814/afterlife-1598115629-tD7CYuGQIq.mp3"}
            };
        }
    }
}
