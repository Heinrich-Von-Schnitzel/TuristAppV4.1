namespace TuristAppV4._1.Model
{
    class Katagori
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
    }
}
