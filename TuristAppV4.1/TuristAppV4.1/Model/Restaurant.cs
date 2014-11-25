using System;

namespace TuristAppV4._1.Model
{
    public class Restaurant
    {
        private string _restaurantNavn;
        private string _bedoemmelse;
        private string _hjemmeside;
        private string _beskrivelse;
        private string _telefon;
        private string _billede;
        private double _breddegrad;
        private double _laengdegrad;

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

        public string Bedoemmelse
        {
            get { return _bedoemmelse; }
            set { _bedoemmelse = value; }
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
        public double Breddegrad
        {
            get { return _breddegrad; }
            set { _breddegrad = value; }
        }
        public double Laengdegrad
        {
            get { return _laengdegrad; }
            set { _laengdegrad = value; }
        }

        public Restaurant(string restaurantNavn, string bedoemmelse, string hjemmeside, string beskrivelse, string telefon, string billede, double breddegrad, double laengdegrad)
        {
            _restaurantNavn = restaurantNavn;
            _bedoemmelse = bedoemmelse;
            _hjemmeside = hjemmeside;
            _beskrivelse = beskrivelse;
            _telefon = telefon;
            _billede = billede;
            _breddegrad = breddegrad;
            _laengdegrad = laengdegrad;
        }

        public override string ToString()
        {
            return _bedoemmelse;
        }
    }
}
