using System.Collections.ObjectModel;
using Windows.Networking.Sockets;

namespace TuristAppV4._1.Model
{
    public class Katagori
    {
        private string _kategoriNavn;
        private ObservableCollection<Restaurant> _listeAfRestauranter;

        public ObservableCollection<Restaurant> ListeAfRestauranter
        {
            get { return _listeAfRestauranter; }
            set { _listeAfRestauranter = value; }
        }

        public string KategoriNavn
        {
            get { return _kategoriNavn; }
            set { _kategoriNavn = value; }
        }

        public Katagori(string kategoriNavn, ObservableCollection<Restaurant> listeAfRestaurants)
        {
            _kategoriNavn = kategoriNavn;
            _listeAfRestauranter = listeAfRestaurants;
        }

        public override string ToString()
        {
            return _kategoriNavn;
        }
    }
}
