using System;

namespace TuristAppV4._1.Model
{
    public class Restaurant
    {
        private string _restaurantNavn;
        private string _bedømmelse;
        private string _hjemmeside;
        private string _beskrivelse;
        private string _telefon;
        private string _billede;
        private double _latitude;
        private double _longitude;

        public string Telefon
        {
            get { return _telefon; }
            set
            {
                _telefon = value;
            }
        }

        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set { _beskrivelse = value; }
        }

        public string Hjemmeside
        {
            get { return _hjemmeside; }
            set { _hjemmeside = value; }
        }

        public string Bedømmelse
        {
            get { return _bedømmelse; }
            set { _bedømmelse = value; }
        }

        public string RestaurantNavn
        {
            get { return _restaurantNavn; }
            set
            {
                _restaurantNavn = value;
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

        public Restaurant(string restaurantNavn, string bedømmelse, string hjemmeside, string beskrivelse, string telefon, string billede, double latitude, double longitude)
        {
            _restaurantNavn = restaurantNavn;
            _bedømmelse = bedømmelse;
            _hjemmeside = hjemmeside;
            _beskrivelse = beskrivelse;
            _telefon = telefon;
            _billede = billede;
            _latitude = latitude;
            _longitude = longitude;
        }

        public override string ToString()
        {
            return _bedømmelse;
        }
    }
}
