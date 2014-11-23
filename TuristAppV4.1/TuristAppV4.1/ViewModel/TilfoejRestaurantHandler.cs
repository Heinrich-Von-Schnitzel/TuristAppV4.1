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
        private string _bedømmelse; // twoway bindes til textbox
        private string _hjemmeside; // twoway bindes til textbox
        private string _beskrivelse; // twoway bindes til textbox
        private string _telefon; // twoway bindes til textbox
        private string _billede;
        private double _latitude;
        private double _longitude;
        private Katagori _selectedKategori;

        public async void TilfoejRestaurant()       
        {

            if (String.IsNullOrEmpty(_restaurantNavn))
            {
                MessageDialog navnfejl = new MessageDialog("Restaurantnavnet skal være udfyldt", "Ups! Der skete en fejl!");
                await navnfejl.ShowAsync();
            }
            else if (_restaurantNavn.Length >= 30)
            {
                MessageDialog navnfejl = new MessageDialog("Restaurantnavnet må højst bestå af 30 tegn", "Ups! Der skete en fejl!");
                await navnfejl.ShowAsync();
            }
            else if (String.IsNullOrEmpty(_bedømmelse))
            {
                MessageDialog bedømmelsefejl = new MessageDialog("Vælg en bedømmelse", "Ups! Der skete en fejl!");
                await bedømmelsefejl.ShowAsync();
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
            else if (String.IsNullOrEmpty(_beskrivelse))
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Beskrivelsen skal være udfyldt", "Ups! Der skete en fejl!");
                await beskrivelsefejl.ShowAsync();
            }
            else if (_beskrivelse.Length >= 500)
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Beskrivelsen må højest bestå af 500 tegn", "Ups! Der skete en fejl!");
                await beskrivelsefejl.ShowAsync();
            }
            else if (_selectedKategori == null)
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Vælg en kategori");
                await beskrivelsefejl.ShowAsync();
            }
            else
            {
                Restaurant r = new Restaurant(_restaurantNavn, _bedømmelse, _hjemmeside, _beskrivelse, _telefon, _billede, _latitude, _longitude);
                SelectedKategori.ListeAfRestauranter.Add(r);
            }
        }
        public void CheckRestaurantNavn(string restaurantNavn)
        {
            if (String.IsNullOrEmpty(restaurantNavn) || restaurantNavn.Length >= 30)
            {
                throw new ArgumentException("Restaurantnavnet er null, tomt eller over 30 tegn");
            }
        }
        public void CheckTelefon(string telefon)
        {
            if (String.IsNullOrEmpty(telefon) || (telefon.Length >= 9 || telefon.Length <= 7))
            {
                throw new ArgumentException("Telefon skal være 8 tegn");
            }
        }
        public void CheckBeskrivelse(string beskrivelse)
        {
            if (String.IsNullOrEmpty(beskrivelse) || beskrivelse.Length > 500 || beskrivelse.Length < 20)
            {
                throw new ArgumentException("beskrivelse skal indholde tegn");
            }

        }

        public void CheckBedømmelse(string bedømmelse)
        {
            if (String.IsNullOrEmpty(bedømmelse))
            {
                throw new ArgumentException("bedømmelse");
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
            set
            {
                CheckBedømmelse(value);
                _bedømmelse = value;
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

        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        public double Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        public Katagori SelectedKategori
        {
            get { return _selectedKategori; }
            set { _selectedKategori = value; }
        }
    }
}
