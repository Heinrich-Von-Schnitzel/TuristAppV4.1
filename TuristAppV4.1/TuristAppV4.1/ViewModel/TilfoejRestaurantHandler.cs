using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    public class TilfoejRestaurantHandler
    {
        private string _restaurantNavn; // twoway bindes til textbox
        private string _bedoemmelse; // twoway bindes til textbox
        private string _hjemmeside; // twoway bindes til textbox
        private string _beskrivelse; // twoway bindes til textbox
        private string _telefon; // twoway bindes til textbox
        private string _billede;
        private double _breddegrad;
        private double _laengdegrad;
        private Katagori _selectedKategori;
        private MainViewModel _mainViewModel;

        public async void TilfoejRestaurant()       
        {

            if (String.IsNullOrEmpty(_restaurantNavn))
            {
                MessageDialog navnfejl = new MessageDialog("Restaurantnavnet skal være udfyldt", "Ups! Der skete en fejl!");
                await navnfejl.ShowAsync();
            }
            else if (_restaurantNavn.Length < 2)
            {
                MessageDialog navnfejl = new MessageDialog("Restaurantnavn skal være mindst 2 tegn");
                await navnfejl.ShowAsync();
            }
            else if (_restaurantNavn.Length >= 30)
            {
                MessageDialog navnfejl = new MessageDialog("Restaurantnavnet må højst bestå af 30 tegn", "Ups! Der skete en fejl!");
                await navnfejl.ShowAsync();
            }
            else if (String.IsNullOrEmpty(_bedoemmelse))
            {
                MessageDialog bedoemmelsefejl = new MessageDialog("Vælg en Bedoemmelse", "Ups! Der skete en fejl!");
                await bedoemmelsefejl.ShowAsync();
            }
            else if (String.IsNullOrEmpty(_beskrivelse))
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Beskrivelsen skal være udfyldt", "Ups! Der skete en fejl!");
                await beskrivelsefejl.ShowAsync();
            }
            else if (_beskrivelse.Length <= 20)
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Beskrivelsen skal være mindst 20 tegn", "Ups! Der skete en fejl!");
                await beskrivelsefejl.ShowAsync();
            }
            else if (_beskrivelse.Length >= 500)
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Beskrivelsen må højest bestå af 500 tegn", "Ups! Der skete en fejl!");
                await beskrivelsefejl.ShowAsync();
            }
            else if (String.IsNullOrEmpty(_telefon))
            {
                MessageDialog telefonfejl = new MessageDialog("Telefonnumeret skal være udfyldt", "Ups! Der skete en fejl!");
                await telefonfejl.ShowAsync();
            }
            else if (_telefon.Length != 8)
            {
                MessageDialog telefonfejl = new MessageDialog("Telefonnumeret skal bestå af 8 tegn", "Ups! Der skete en fejl!");
                await telefonfejl.ShowAsync();
            }
            else if (_breddegrad <= 0.0)
            {
                MessageDialog breddegradfejl = new MessageDialog("Breddegrad skal være større end 0", "Ups! Der skete en fejl!");
                await breddegradfejl.ShowAsync();
            }
            else if (_laengdegrad <= 0.0)
            {
                MessageDialog laengdegradfejl = new MessageDialog("Længdegrad skal være større end 0", "Ups! Der skete en fejl!");
                await laengdegradfejl.ShowAsync();
            }
            else if (_selectedKategori == null)
            {
                MessageDialog kategorifejl = new MessageDialog("Vælg en kategori", "Ups! Der skete en fejl!");
                await kategorifejl.ShowAsync();
            }
            else
            {
                if (String.IsNullOrEmpty(_billede))
                {
                    Restaurant r = new Restaurant(_restaurantNavn, _bedoemmelse, _hjemmeside, _beskrivelse, _telefon, "../Assets/noimage.png", _breddegrad, _laengdegrad);
                    SelectedKategori.ListeAfRestauranter.Add(r);
                    SavePersonsAsync();
                }
                else
                {
                    Restaurant r = new Restaurant(_restaurantNavn, _bedoemmelse, _hjemmeside, _beskrivelse, _telefon, _billede, _breddegrad, _laengdegrad);
                    SelectedKategori.ListeAfRestauranter.Add(r);
                    SavePersonsAsync();
                }

            }
        }
        public void CheckRestaurantNavn(string restaurantNavn)
        {
            if (String.IsNullOrEmpty(restaurantNavn) || restaurantNavn.Length >= 30 || restaurantNavn.Length < 2)
            {
                throw new ArgumentException("Restaurantnavnet er null, tomt eller over 30 tegn");
            }
        }

        public void CheckBreddegrad(double breddegrad)
        {
            if (breddegrad <= 0.0)
            {
                throw new ArgumentException("breddegrad");
            }
        }
        public void CheckLaengdegrad(double laengdegrad)
        {
            if (laengdegrad <= 0.0)
            {
                throw new ArgumentException("laengdegrad");
            }
        }
        public void CheckBedoemmelse(string bedoemmelse)
        {
            if (String.IsNullOrEmpty(bedoemmelse))
            {
                throw new ArgumentException("Bedoemmelse");
            }
        }
        public void CheckBeskrivelse(string beskrivelse)
        {
            if (String.IsNullOrEmpty(beskrivelse) || beskrivelse.Length > 500 || beskrivelse.Length < 20)
            {
                throw new ArgumentException("beskrivelse skal indholde tegn");
            }

        }
        public void CheckTelefon(string telefon)
        {
            if (String.IsNullOrEmpty(telefon) || (telefon.Length >= 9 || telefon.Length <= 7))
            {
                throw new ArgumentException("Telefon skal være 8 tegn");
            }
        }
        public void CheckKategori(Katagori kategori)
        {
            if (kategori == null)
            {
                throw new ArgumentException("Vælg en kategori");
            }
        }

        public TilfoejRestaurantHandler(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public async void SavePersonsAsync()
        {
            PersistenceFacade.SavePersonsAsJsonAsync(_mainViewModel.SamlingAfKategorier);
        }

        public async void LoadPersonsAsync()
        {
            ObservableCollection<ObservableCollection<Restaurant>> _collectionOfCollectionOfRestaurants = await PersistenceFacade.LoadPersonsFromJsonAsync();
            _mainViewModel.Kategori1.Clear();
            _mainViewModel.Kategori2.Clear();
            _mainViewModel.Kategori3.Clear();
            ObservableCollection<Restaurant> _katalog1 = (ObservableCollection<Restaurant>)_collectionOfCollectionOfRestaurants[0];
            ObservableCollection<Restaurant> _katalog2 = (ObservableCollection<Restaurant>)_collectionOfCollectionOfRestaurants[1];
            ObservableCollection<Restaurant> _katalog3 = (ObservableCollection<Restaurant>)_collectionOfCollectionOfRestaurants[2];

            foreach (var restaurant in _katalog1)
            {
                _mainViewModel.Kategori1.Add(restaurant);
            }
            foreach (var restaurant in _katalog2)
            {
                _mainViewModel.Kategori2.Add(restaurant);
            }
            foreach (var restaurant in _katalog3)
            {
                _mainViewModel.Kategori3.Add(restaurant);
            }
        }

        public TilfoejRestaurantHandler()
        {

        }

        public string RestaurantNavn
        {
            get { return _restaurantNavn; }
            set
            {
               CheckRestaurantNavn(value);
                _restaurantNavn = value;
            }
        }

        public string Bedoemmelse
        {
            get { return _bedoemmelse; }
            set
            {
               CheckBedoemmelse(value);
                _bedoemmelse = value;
            }
        }

        public string Hjemmeside
        {
            get { return _hjemmeside; }
            set { _hjemmeside = value; }
        }

        public string Telefon
        {
            get { return _telefon; }
            set
            {
                CheckTelefon(value);
                _telefon = value;    
            }
        }

        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set
            {
               CheckBeskrivelse(value);
                _beskrivelse = value;
            }
        }

        public string Billede
        {
            get { return _billede; }
            set { _billede = value; }
        }

        public double Breddegrad
        {
            get { return _breddegrad; }
            set
            {
               CheckBreddegrad(value);
                _breddegrad = value;
            }
        }

        public double Laengdegrad
        {
            get { return _laengdegrad; }
            set
            {
                CheckLaengdegrad(value);
                _laengdegrad = value;
            }
        }

        public Katagori SelectedKategori
        {
            get { return _selectedKategori; }
            set
            {  CheckKategori(value);
                _selectedKategori = value;
            }
        }

    }
}
