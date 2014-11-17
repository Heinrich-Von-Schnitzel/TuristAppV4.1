using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using TuristAppV4._1.Annotations;
using TuristAppV4._1.Common;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private static Restaurant _selectedRestaurant;
        private ObservableCollection<Restaurant> _observableCollectionOfRestuarants1;
        private ObservableCollection<Restaurant> _observableCollectionOfRestuarants2;
        private ObservableCollection<Restaurant> _observableCollectionOfRestuarants3;
        private ObservableCollection<Katagori> _kategoriKatalog;
        private string beskrivelse = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis luctus, quam ut vestibulum mollis, urna augue blandit odio, a dignissim ante magna id lacus. Nullam porttitor id est eget elementum. Nunc ac tristique nibh. Sed nisi massa, aliquet at varius vitae, rhoncus eget odio.";
        private RelayCommand _sletSelectedRestaurantCommand;

        public ObservableCollection<Katagori> KategoriKatalog
        {
            get { return _kategoriKatalog; }
            set { _kategoriKatalog = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants1
        {
            get { return _observableCollectionOfRestuarants1; }
            set { _observableCollectionOfRestuarants1 = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants2
        {
            get { return _observableCollectionOfRestuarants2; }
            set { _observableCollectionOfRestuarants2 = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants3
        {
            get { return _observableCollectionOfRestuarants3; }
            set { _observableCollectionOfRestuarants3 = value; }
        } 
        public static Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set { _selectedRestaurant = value; }
        }


        public void SletRestaurant()
        {
            if (SelectedRestaurant == null) { }
            else
            {
                if (ObservableCollectionOfRestuarants1.Contains(SelectedRestaurant))
                {
                    ObservableCollectionOfRestuarants1.Remove(SelectedRestaurant);
                }
                else if (ObservableCollectionOfRestuarants2.Contains(SelectedRestaurant))
                {
                    ObservableCollectionOfRestuarants2.Remove(SelectedRestaurant);
                }
                else
                {
                    ObservableCollectionOfRestuarants3.Remove(SelectedRestaurant);
                }         
             }
        }
        public RelayCommand SletSelectedRestaurantCommand
        {
            get { return _sletSelectedRestaurantCommand; }
            set { _sletSelectedRestaurantCommand = value; }
        }


        public MainViewModel()
        {
            ObservableCollectionOfRestuarants1 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants2 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants3 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants1.Add(new Restaurant("McDonalds", "8", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg"));

            ObservableCollectionOfRestuarants2.Add(new Restaurant("Jensens Bøfshus", "4", "http://www.jensens.com/", beskrivelse, "88 88 88 88", "../Assets/restaurant.jpeg"));

            ObservableCollectionOfRestuarants3.Add(new Restaurant("Bone's", "7", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestuarants3.Add(new Restaurant("Prindsen", "6", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg"));

            _kategoriKatalog = new ObservableCollection<Katagori>();

            _kategoriKatalog.Add(new Katagori("Fastfood"));
            _kategoriKatalog.Add(new Katagori("Familierestauranter"));
            _kategoriKatalog.Add(new Katagori("Fine restauranter"));

            _sletSelectedRestaurantCommand = new RelayCommand(SletRestaurant);
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

