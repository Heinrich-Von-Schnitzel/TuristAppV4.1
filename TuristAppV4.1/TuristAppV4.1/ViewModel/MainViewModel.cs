using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TuristAppV4._1.Annotations;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
     private Restaurant _selectedRestaurant;
        private ObservableCollection<Restaurant> _observableCollectionOfRestuarants1;
        private ObservableCollection<Restaurant> _observableCollectionOfRestuarants2;
        private ObservableCollection<Restaurant> _observableCollectionOfRestuarants3;

        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants1
        {
            get { return _observableCollectionOfRestuarants1; }
            set { _observableCollectionOfRestuarants1 = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants2
        {
            get { return _observableCollectionOfRestuarants2; }
            set { _observableCollectionOfRestuarants2 = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestuarants3
        {
            get { return _observableCollectionOfRestuarants3; }
            set { _observableCollectionOfRestuarants3 = value; }
        } 
        public Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set { _selectedRestaurant = value; OnPropertyChanged(); }
        }

        public void SletRestaurant()
        {
            if (SelectedRestaurant == null) { }
            else
            {
                if (ObservableCollectionOfRestuarants1.Contains(SelectedRestaurant))
                {
                    ObservableCollectionOfRestuarants1.Remove(SelectedRestaurant);
                }
                else if (ObservableCollectionOfRestuarants2.Contains(SelectedRestaurant))
                {
                    ObservableCollectionOfRestuarants2.Remove(SelectedRestaurant);
                }
                else
                {
                    ObservableCollectionOfRestuarants3.Remove(SelectedRestaurant);
                }         
             }
        }

        public MainViewModel()
        {
            ObservableCollectionOfRestuarants1 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants2 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants3 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestuarants1.Add(new Restaurant("testNavn", "testBedømmelse", "testHjemmeside", "testBeskrivelse", "testTelefon"));
            ObservableCollectionOfRestuarants2.Add(new Restaurant("testNavn", "testBedømmelse", "testHjemmeside", "testBeskrivelse", "testTelefon"));
            ObservableCollectionOfRestuarants3.Add(new Restaurant("testNavn", "testBedømmelse", "testHjemmeside", "testBeskrivelse", "testTelefon"));
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
       
        #endregion
    }
}

