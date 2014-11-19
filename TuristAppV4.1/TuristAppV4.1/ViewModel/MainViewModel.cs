﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using TuristAppV4._1.Annotations;
using TuristAppV4._1.Common;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private static Restaurant _selectedRestaurant;
        //private Katagori _selectedKategori;
        private ObservableCollection<Restaurant> _observableCollectionOfRestaurants1;
        private ObservableCollection<Restaurant> _observableCollectionOfRestaurants2;
        private ObservableCollection<Restaurant> _observableCollectionOfRestaurants3;
        private ObservableCollection<Katagori> _kategoriKatalog;
        private string beskrivelse = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis luctus, quam ut vestibulum mollis, urna augue blandit odio, a dignissim ante magna id lacus. Nullam porttitor id est eget elementum. Nunc ac tristique nibh. Sed nisi massa, aliquet at varius vitae, rhoncus eget odio.";
        private RelayCommand _sletSelectedRestaurantCommand;
        private TilfoejRestaurantHandler _tilfoejRestaurantHandler;
        private RelayCommand _tilfoejRestaurantCommand;

        public RelayCommand TilfoejRestaurantCommand
        {
            get { return _tilfoejRestaurantCommand; }
            set { _tilfoejRestaurantCommand = value; }
        }

        public TilfoejRestaurantHandler TilfoejRestaurantHandler
        {
            get { return _tilfoejRestaurantHandler; }
            set { _tilfoejRestaurantHandler = value; }
        }

        public ObservableCollection<Katagori> KategoriKatalog
        {
            get { return _kategoriKatalog; }
            set { _kategoriKatalog = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestaurants1
        {
            get { return _observableCollectionOfRestaurants1; }
            set { _observableCollectionOfRestaurants1 = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestaurants2
        {
            get { return _observableCollectionOfRestaurants2; }
            set { _observableCollectionOfRestaurants2 = value; }
        }

        public ObservableCollection<Restaurant> ObservableCollectionOfRestaurants3
        {
            get { return _observableCollectionOfRestaurants3; }
            set { _observableCollectionOfRestaurants3 = value; }
        } 
        public static Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set { _selectedRestaurant = value; }
        }

       /* public Katagori SelectedKategori
        {
            get { return _selectedKategori; }
            set { _selectedKategori = value; }
        }*/


        public async void SletRestaurant()
        {
            if (SelectedRestaurant == null) { }
            else
            {
                if (ObservableCollectionOfRestaurants1.Contains(SelectedRestaurant))
                {
                    ObservableCollectionOfRestaurants1.Remove(SelectedRestaurant);
                }
                else if (ObservableCollectionOfRestaurants2.Contains(SelectedRestaurant))
                {
                    ObservableCollectionOfRestaurants2.Remove(SelectedRestaurant);
                }
                else
                {
                    ObservableCollectionOfRestaurants3.Remove(SelectedRestaurant);
                }         
             }
            MessageDialog slet = new MessageDialog("Du har nu slettet en restaurant fra den valgte kategori. Tryk på knappen for at lukke denne notifikation.", "Bemærk! Restaurant blev slettet fra kategorien");
            slet.Commands.Add(new UICommand("Luk notifikation"));
            await slet.ShowAsync();
        }
        public RelayCommand SletSelectedRestaurantCommand
        {
            get { return _sletSelectedRestaurantCommand; }
            set { _sletSelectedRestaurantCommand = value; }
        }

        public MainViewModel()
        {
            ObservableCollectionOfRestaurants1 = new ObservableCollection<Restaurant>();         
            ObservableCollectionOfRestaurants1.Add(new Restaurant("McDonalds", "8", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants1.Add(new Restaurant("Burger King", "1", "http://www.burgerking.dk/", beskrivelse, "33 33 33 33", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants1.Add(new Restaurant("McDonalds", "8", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants1.Add(new Restaurant("Burger King", "1", "http://www.burgerking.dk/", beskrivelse, "33 33 33 33", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants1.Add(new Restaurant("McDonalds", "8", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants1.Add(new Restaurant("Burger King", "1", "http://www.burgerking.dk/", beskrivelse, "33 33 33 33", "../Assets/restaurant.jpeg"));

            ObservableCollectionOfRestaurants2 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestaurants2.Add(new Restaurant("Jensens Bøfshus", "4", "http://www.jensens.com/", beskrivelse, "88 88 88 88", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants2.Add(new Restaurant("Bryggegården", "8", "http://www.restaurantbryggergaarden.dk/", beskrivelse, "99 99 99 99", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants2.Add(new Restaurant("Jensens Bøfshus", "4", "http://www.jensens.com/", beskrivelse, "88 88 88 88", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants2.Add(new Restaurant("Bryggegården", "8", "http://www.restaurantbryggergaarden.dk/", beskrivelse, "99 99 99 99", "../Assets/restaurant.jpeg"));

            ObservableCollectionOfRestaurants3 = new ObservableCollection<Restaurant>();
            ObservableCollectionOfRestaurants3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants3.Add(new Restaurant("Prindsen", "7", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants3.Add(new Restaurant("Prindsen", "7", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants3.Add(new Restaurant("Prindsen", "7", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg"));
            ObservableCollectionOfRestaurants3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg"));

            _kategoriKatalog = new ObservableCollection<Katagori>();
            _kategoriKatalog.Add(new Katagori("Fastfood", ObservableCollectionOfRestaurants1));
            _kategoriKatalog.Add(new Katagori("Familierestauranter", ObservableCollectionOfRestaurants2));
            _kategoriKatalog.Add(new Katagori("Fine restauranter", ObservableCollectionOfRestaurants3));
            
            _sletSelectedRestaurantCommand = new RelayCommand(SletRestaurant);
            _tilfoejRestaurantHandler = new TilfoejRestaurantHandler();
            _tilfoejRestaurantCommand = new RelayCommand(_tilfoejRestaurantHandler.TilfoejRestaurant);
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

