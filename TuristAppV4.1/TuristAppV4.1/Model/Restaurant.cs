namespace TuristAppV4._1.Model
{
    class Restaurant
    {
        private string _restaurantNavn;
        private string _bedømmelse;
        private string _hjemmeside;
        private string _beskrivelse;
        private string _telefon;


        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
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
            set { _restaurantNavn = value; }
        }

        public Restaurant(string restaurantNavn, string bedømmelse, string hjemmeside, string beskrivelse, string telefon)
        {
            _restaurantNavn = restaurantNavn;
            _bedømmelse = bedømmelse;
            _hjemmeside = hjemmeside;
            _beskrivelse = beskrivelse;
            _telefon = telefon;
        }
    }
}
