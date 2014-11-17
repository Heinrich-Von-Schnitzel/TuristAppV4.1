using System.Collections.ObjectModel;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    internal class MainViewModel
    {
        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants1 { get; set; } //lav til backing field
        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants2 { get; set; } //same
        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants3 { get; set; } //same
        private Restaurant _selectedRestaurant;

        public Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set
            {
                _selectedRestaurant = value; //OnNotifyPropertyChanged()
            }
        }

        public void SletRestaurant() { }

        public MainViewModel()
        {
            ObservableCollectionOfRestuarants1 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants2 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants3 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants1.Add(new Restaurant("testNavn", "testBedømmelse", "testHjemmeside", "testBeskrivelse", "testTelefon"));
            ObservableCollectionOfRestuarants2.Add(new Restaurant("testNavn", "testBedømmelse", "testHjemmeside", "testBeskrivelse", "testTelefon"));
            ObservableCollectionOfRestuarants3.Add(new Restaurant("testNavn", "testBedømmelse", "testHjemmeside", "testBeskrivelse", "testTelefon"));
        }
    }


}
