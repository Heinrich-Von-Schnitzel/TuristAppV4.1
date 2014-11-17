using System.Collections.ObjectModel;
using Windows.Networking.Sockets;

namespace TuristAppV4._1.Model
{
    public class Katagori
    {
        private string _kategoriNavn;

        public string KategoriNavn
        {
            get { return _kategoriNavn; }
            set { _kategoriNavn = value; }
        }

        public Katagori(string kategoriNavn)
        {
            _kategoriNavn = kategoriNavn;
        }

        public override string ToString()
        {
            return  _kategoriNavn;
        }
    }
}
