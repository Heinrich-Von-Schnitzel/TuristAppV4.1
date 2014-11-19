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

        public void CheckRestaurantNavn(string navn)
        {
            if (navn.Length < 2)
            {
                throw new ArgumentException("Navnet er for kort. Det skal være længere end 2 tegn");
            }
        }
        public void CheckRestaurantTelefon(string telefon)
        {
            if (telefon.Length == 8)
            {
                throw new ArgumentException("Telefon nr. er for kort. Det skal være på 8 tegn");
            }
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
                CheckRestaurantNavn(value);
                _restaurantNavn = value;
            }
        }
        public string Billede
        {
            get { return _billede; }
            set { _billede = value; }
        }

        public Restaurant(string restaurantNavn, string bedømmelse, string hjemmeside, string beskrivelse, string telefon, string billede)
        {
            _restaurantNavn = restaurantNavn;
            _bedømmelse = bedømmelse;
            _hjemmeside = hjemmeside;
            _beskrivelse = beskrivelse;
            _telefon = telefon;
            _billede = billede;
        }

        public override string ToString()
        {
            return _bedømmelse;
        }
    }
}
