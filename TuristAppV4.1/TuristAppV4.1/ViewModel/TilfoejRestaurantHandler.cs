using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using Windows.UI.Xaml.Controls;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    public class TilfoejRestaurantHandler
    {
        private string _restaurantNavn; // twoway bindes til textbox
        private string _bedømmelse; // twoway bindes til textbox
        private string _hjemmeside; // twoway bindes til textbox
        private string _beskrivelse; // twoway bindes til textbox
        private string _telefon; // twoway bindes til textbox
        private string _billede;
        private Katagori _selectedKategori;

        public void TilfoejRestaurant()       
        {
            Restaurant r = new Restaurant(_restaurantNavn, _bedømmelse, _hjemmeside, _beskrivelse, _telefon, "../Assets/restaurant.jpeg");
            SelectedKategori.ListeAfRestauranter.Add(r);
        }
        public void CheckRestaurantNavn(string navn)
        {
            if (String.IsNullOrEmpty(navn) || navn.Length >= 30)
            {
                throw new ArgumentException("Navnet er for kort. Det skal være længere end 2 tegn");
            }
        }
        public void CheckRestaurantTelefon(string telefon)
        {
            if (telefon.Length == 7)
            {
                throw new ArgumentException("Telefon nr. er for kort. Det skal være på 8 tegn");
            }
        }
        public void CheckBeskrivelse(string beskrivelse)
        {
            if (String.IsNullOrEmpty(beskrivelse) || beskrivelse.Length >= 500)
            {
                throw new ArgumentException("Navnet er for kort. Det skal være længere end 2 tegn");
            }
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

        public string Bedømmelse
        {
            get { return _bedømmelse; }
            set { _bedømmelse = value; }
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
                CheckRestaurantTelefon(value);
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

        public Katagori SelectedKategori
        {
            get { return _selectedKategori; }
            set { _selectedKategori = value; }
        }
    }
}
