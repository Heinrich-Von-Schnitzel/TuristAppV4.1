using System.Collections.ObjectModel;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    class OpretRestuarantHandler
    {
        private string _restaurantNavn;
        private string _bedømmelse;
        private string _hjemmeside;
        private string _beskrivelse;
        private string _telefon;
        private MainViewModel _reference = new MainViewModel(); //reference til collection


        public void OpretRestaurant(ObservableCollection<Restaurant> observableCollection)
        {

            _reference.ObservableCollectionOfRestuarants1.Add(new Restaurant(_restaurantNavn, _bedømmelse, _hjemmeside, _beskrivelse, _telefon));
            // problem med at den tilføjer en restaurant til alle tre OC's
            // kan ikke vælge specifik OC
        }
    }
}
