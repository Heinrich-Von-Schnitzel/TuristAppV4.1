using System.Collections.ObjectModel;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    class OpretRestaurantHandler
    {
        private string _restaurantNavn; // twoway bindes til textbox
        private string _bedømmelse;  // twoway bindes til textbox
        private string _hjemmeside;   // twoway bindes til textbox
        private string _beskrivelse;   // twoway bindes til textbox
        private string _telefon;   // twoway bindes til textbox
        private string _billede;
        private MainViewModel _reference = new MainViewModel(); //reference til collection


        public void OpretRestaurantKategori1(ObservableCollection<Restaurant> observableCollection)
        {
            _reference.ObservableCollectionOfRestuarants1.Add(new Restaurant(_restaurantNavn, _bedømmelse, _hjemmeside, _beskrivelse, _telefon, _billede));
        }

        public void OpretRestaurantKategori2(ObservableCollection<Restaurant> observableCollection)
        {
            _reference.ObservableCollectionOfRestuarants2.Add(new Restaurant(_restaurantNavn, _bedømmelse, _hjemmeside, _beskrivelse, _telefon, _billede));
        }

        public void OpretRestaurantKategori3(ObservableCollection<Restaurant> observableCollection)
        {
            _reference.ObservableCollectionOfRestuarants3.Add(new Restaurant(_restaurantNavn, _bedømmelse, _hjemmeside, _beskrivelse, _telefon, _billede));
        }
    }
}
