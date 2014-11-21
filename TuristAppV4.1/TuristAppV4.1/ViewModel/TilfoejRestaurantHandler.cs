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
                Restaurant r = new Restaurant(_restaurantNavn, _bedømmelse, _hjemmeside, _beskrivelse, _telefon, _billede);
                SelectedKategori.ListeAfRestauranter.Add(r);
            }
        }
        public async void CheckRestaurantNavn(string navn)
        {
            if (String.IsNullOrEmpty(RestaurantNavn))
            {
                MessageDialog navnfejl = new MessageDialog("Navnet skal være udfyldt");
                await navnfejl.ShowAsync();
            }
            if (RestaurantNavn.Length >= 30)
            {     
                MessageDialog navnfejl = new MessageDialog("Navnet må højst være 30 tegn");
                await navnfejl.ShowAsync();
            }
        }
        public void CheckRestaurantNavn1(string restaurantNavn)
        {
            if (String.IsNullOrEmpty(restaurantNavn) || restaurantNavn.Length >= 30)
            {
                throw new ArgumentException("Restaurantnavnet er null, tomt eller over 30 tegn");
            }
        }
        public async void CheckRestaurantTelefon(string telefon)
        {
            if (telefon.Length != 8)
            {
                MessageDialog telefonfejl = new MessageDialog("Telefon skal være 8 tegn");
                await telefonfejl.ShowAsync();
            }
        }
        public async void CheckBeskrivelse(string beskrivelse)
        {
            if (String.IsNullOrEmpty(beskrivelse))
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Beskrivelsen skal være udfyldt og må være 500 tegn");
                await beskrivelsefejl.ShowAsync();
            }
            if (beskrivelse.Length >= 500)
            {
                MessageDialog beskrivelsefejl = new MessageDialog("Beskrivelsen skal være udfyldt og må være 500 tegn");
                await beskrivelsefejl.ShowAsync();
                
            }
        }

        public string RestaurantNavn
        {
            get { return _restaurantNavn; }
            set
            {
                CheckRestaurantNavn1(value);
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
               // CheckRestaurantTelefon(value);
                _telefon = value;    
            }
        }

        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set
            {
              //  CheckBeskrivelse(value);
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
