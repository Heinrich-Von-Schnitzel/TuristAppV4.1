using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using TuristAppV4._1.Annotations;
using TuristAppV4._1.Common;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private static Restaurant _selectedRestaurant;
        private ObservableCollection<Restaurant> _kategori1;
        private ObservableCollection<Restaurant> _kategori2;
        private ObservableCollection<Restaurant> _kategori3;
        private ObservableCollection<Katagori> _kategoriKatalog;
        private string beskrivelse = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis luctus, quam ut vestibulum mollis, urna augue blandit odio, a dignissim ante magna id lacus. Nullam porttitor id est eget elementum. Nunc ac tristique nibh. Sed nisi massa, aliquet at varius vitae, rhoncus eget odio.";
        private RelayCommand _sletSelectedRestaurantCommand;
        private TilfoejRestaurantHandler _tilfoejRestaurantHandler;
        private RelayCommand _tilfoejRestaurantCommand;
        private ObservableCollection<string> _nrListe;

        public ObservableCollection<string> NrListe1
        {
            get { return _nrListe; }
            set { _nrListe = value; }
        }

        public RelayCommand TilfoejRestaurantCommand
        {
            get { return _tilfoejRestaurantCommand; }
            set { _tilfoejRestaurantCommand = value; }
        }

        public TilfoejRestaurantHandler TilfoejRestaurantHandler
        {
            get { return _tilfoejRestaurantHandler; }
            set { _tilfoejRestaurantHandler = value; }
        }

        public ObservableCollection<Katagori> KategoriKatalog
        {
            get { return _kategoriKatalog; }
            set { _kategoriKatalog = value; }
        }

        public ObservableCollection<Restaurant> Kategori1
        {
            get { return _kategori1; }
            set { _kategori1 = value; }
        }

        public ObservableCollection<Restaurant> Kategori2
        {
            get { return _kategori2; }
            set { _kategori2 = value; }
        }

        public ObservableCollection<Restaurant> Kategori3
        {
            get { return _kategori3; }
            set { _kategori3 = value; }
        } 
        public static Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set { _selectedRestaurant = value; }
        }

        public async void SletRestaurant()
        {
            if (SelectedRestaurant == null)
            {
                MessageDialog slet = new MessageDialog("Du har ikke valgt en restaurant. Vælg først en restaurant og tryk dernæst på slet-knappen", "Der er ikke blevet valgt en restaurant");
                slet.Commands.Add(new UICommand("Luk notifikation"));
                await slet.ShowAsync();
            }
            else
            {
                if (Kategori1.Contains(SelectedRestaurant))
                {
                    Kategori1.Remove(SelectedRestaurant);
                }
                else if (Kategori2.Contains(SelectedRestaurant))
                {
                    Kategori2.Remove(SelectedRestaurant);
                }
                else
                {
                    Kategori3.Remove(SelectedRestaurant);
                }
                MessageDialog slet = new MessageDialog("Du har nu slettet en restaurant fra den valgte kategori. Tryk på knappen for at lukke denne notifikation.", "Bemærk! Restaurant blev slettet fra kategorien");
                slet.Commands.Add(new UICommand("Luk notifikation"));
                await slet.ShowAsync();
             }

        }
        public RelayCommand SletSelectedRestaurantCommand
        {
            get { return _sletSelectedRestaurantCommand; }
            set { _sletSelectedRestaurantCommand = value; }
        }

        public MainViewModel()
        {
            Kategori1 = new ObservableCollection<Restaurant>();
            Kategori1.Add(new Restaurant("McDonalds", "3", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg", 55.634303, 12.073764));
            Kategori1.Add(new Restaurant("Burger King", "1", "http://www.burgerking.dk/", beskrivelse, "33 33 33 33", "../Assets/restaurant.jpeg", 55.626591, 12.091798));
            Kategori1.Add(new Restaurant("McDonalds", "4", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg", 55.642303, 12.115755));

            Kategori2 = new ObservableCollection<Restaurant>();
            Kategori2.Add(new Restaurant("Jensens Bøfshus", "4", "http://www.jensens.com/", beskrivelse, "88 88 88 88", "../Assets/restaurant.jpeg", 55.640808, 12.076909));
            Kategori2.Add(new Restaurant("Bryggegården", "3", "http://www.restaurantbryggergaarden.dk/", beskrivelse, "99 99 99 99", "../Assets/restaurant.jpeg", 55.641169, 12.084252));
            Kategori2.Add(new Restaurant("Jensens Bøfshus", "4", "http://www.jensens.com/", beskrivelse, "88 88 88 88", "../Assets/restaurant.jpeg", 55.640808, 12.076909));
            Kategori2.Add(new Restaurant("Bryggegården", "1", "http://www.restaurantbryggergaarden.dk/", beskrivelse, "99 99 99 99", "../Assets/restaurant.jpeg", 55.641169, 12.084252));

            Kategori3 = new ObservableCollection<Restaurant>();
            Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg", 55.640619, 12.090005));
            Kategori3.Add(new Restaurant("Prindsen", "4", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg", 55.641140, 12.083443));
            Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg", 55.640619, 12.090005));
            Kategori3.Add(new Restaurant("Prindsen", "2", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg", 55.641140, 12.083443));
            Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg",55.640619, 12.090005));
            Kategori3.Add(new Restaurant("Prindsen", "4", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg", 55.641140, 12.083443));
            Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg", 55.640619, 12.090005));

            _kategoriKatalog = new ObservableCollection<Katagori>();
            _kategoriKatalog.Add(new Katagori("Fastfood", Kategori1));
            _kategoriKatalog.Add(new Katagori("Familierestauranter", Kategori2));
            _kategoriKatalog.Add(new Katagori("Fine restauranter", Kategori3));

            _nrListe = new ObservableCollection<string>();
            _nrListe.Add("1");
            _nrListe.Add("2");
            _nrListe.Add("3");
            _nrListe.Add("4");
            _nrListe.Add("5");

            
            _sletSelectedRestaurantCommand = new RelayCommand(SletRestaurant);
            _tilfoejRestaurantHandler = new TilfoejRestaurantHandler();
            _tilfoejRestaurantCommand = new RelayCommand(_tilfoejRestaurantHandler.TilfoejRestaurant);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
       
        #endregion
    }
}

