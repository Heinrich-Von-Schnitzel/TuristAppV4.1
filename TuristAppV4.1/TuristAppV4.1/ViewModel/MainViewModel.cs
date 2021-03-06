﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
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
        private ObservableCollection<Restaurant> _kategori1;
        private ObservableCollection<Restaurant> _kategori2;
        private ObservableCollection<Restaurant> _kategori3;
        private ObservableCollection<ObservableCollection<Restaurant>> _samlingAfKategorier;
        private ObservableCollection<Katagori> _kategoriKatalog;
        private string beskrivelse = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu porttitor ex, ut suscipit est. Fusce vitae velit accumsan, accumsan risus vitae, congue urna. Etiam vel lorem id arcu eleifend elementum. Nunc vehicula quis nisi at sollicitudin. Phasellus neque nunc, varius in ante ut, eleifend placerat eros. In lacinia tortor id neque mattis, vitae malesuada ante volutpat. Suspendisse viverra mi sed arcu elementum luctus.\n\n Aliquam magna turpis, pellentesque et urna id, ullamcorper scelerisque metus. In dictum ultrices arcu, eget lobortis odio porttitor iaculis. Nam ut dignissim enim. In porta at lectus a euismod. Nam bibendum sem ac ligula varius, ac vehicula leo eleifend. Curabitur dictum urna congue massa tempor accumsan.\n\n Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu porttitor ex, ut suscipit est. Fusce vitae velit accumsan, accumsan risus vitae, congue urna. Etiam vel lorem id arcu eleifend elementum. Nunc vehicula quis nisi at sollicitudin. Phasellus neque nunc, varius in ante ut, eleifend placerat eros. In lacinia tortor id neque mattis, vitae malesuada ante volutpat. Suspendisse viverra mi sed arcu elementum luctus.\n\n Aliquam magna turpis, pellentesque et urna id, ullamcorper scelerisque metus. In dictum ultrices arcu, eget lobortis odio porttitor iaculis. Nam ut dignissim enim. In porta at lectus a euismod. Nam bibendum sem ac ligula varius, ac vehicula leo eleifend. Curabitur dictum urna congue massa tempor accumsan.";
        private RelayCommand _sletSelectedRestaurantCommand;
        private TilfoejRestaurantHandler _tilfoejRestaurantHandler;
        private RelayCommand _tilfoejRestaurantCommand;
        private ObservableCollection<string> _nrListe;
        private ICommand _saveCommand;
        private ICommand _loadCommand;

        public ObservableCollection<ObservableCollection<Restaurant>> SamlingAfKategorier
        {
            get { return _samlingAfKategorier; }
            set { _samlingAfKategorier = value; }
        }
        public ObservableCollection<string> NrListe1
        {
            get { return _nrListe; }
            set { _nrListe = value; }
        }

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

        public ObservableCollection<Restaurant> Kategori1
        {
            get { return _kategori1; }
            set { _kategori1 = value; }
        }

        public ObservableCollection<Restaurant> Kategori2
        {
            get { return _kategori2; }
            set { _kategori2 = value; }
        }

        public ObservableCollection<Restaurant> Kategori3
        {
            get { return _kategori3; }
            set { _kategori3 = value; }
        }
        public static Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set { _selectedRestaurant = value; }
        }

        public async void SletRestaurant()
        {
            if (SelectedRestaurant == null)
            {
                MessageDialog slet = new MessageDialog("Du har ikke valgt en restaurant. Vælg først en restaurant og tryk dernæst på slet-knappen", "Der er ikke blevet valgt en restaurant");
                slet.Commands.Add(new UICommand("Luk notifikation"));
                await slet.ShowAsync();
            }
            else
            {
                if (Kategori1.Contains(SelectedRestaurant))
                {
                    Kategori1.Remove(SelectedRestaurant);
                }
                else if (Kategori2.Contains(SelectedRestaurant))
                {
                    Kategori2.Remove(SelectedRestaurant);
                }
                else
                {
                    Kategori3.Remove(SelectedRestaurant);
                }
                MessageDialog slet = new MessageDialog("Du har nu slettet en restaurant fra den valgte kategori. Tryk på knappen for at lukke denne notifikation.", "Bemærk! Restaurant blev slettet fra kategorien");
                slet.Commands.Add(new UICommand("Luk notifikation"));
                await slet.ShowAsync();
                _tilfoejRestaurantHandler.SavePersonsAsync();
            }

        }
        public RelayCommand SletSelectedRestaurantCommand
        {
            get { return _sletSelectedRestaurantCommand; }
            set { _sletSelectedRestaurantCommand = value; }
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new RelayCommand(TilfoejRestaurantHandler.SavePersonsAsync);
                return _saveCommand;
            }
            set { _saveCommand = value; }
        }

        public ICommand LoadCommand
        {
            get
            {
                if (_loadCommand == null)
                    _loadCommand = new RelayCommand(TilfoejRestaurantHandler.LoadPersonsAsync);
                return _loadCommand;
            }
            set { _loadCommand = value; }
        }

        public MainViewModel()
        {
            Kategori1 = new ObservableCollection<Restaurant>();
            /*Kategori1.Add(new Restaurant("McDonalds", "3", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg", 55.634303, 12.073764));
            Kategori1.Add(new Restaurant("Burger King", "1", "http://www.burgerking.dk/", beskrivelse, "33 33 33 33", "../Assets/restaurant.jpeg", 55.626591, 12.091798));
            Kategori1.Add(new Restaurant("McDonalds", "4", "http://www.mcdonalds.dk/", beskrivelse, "44 44 44 44", "../Assets/restaurant.jpeg", 55.642303, 12.115755));
            */
            Kategori2 = new ObservableCollection<Restaurant>();
            /*Kategori2.Add(new Restaurant("Jensens Bøfshus", "4", "http://www.jensens.com/", beskrivelse, "88 88 88 88", "../Assets/restaurant.jpeg", 55.640808, 12.076909));
            Kategori2.Add(new Restaurant("Bryggegården", "3", "http://www.restaurantbryggergaarden.dk/", beskrivelse, "99 99 99 99", "../Assets/restaurant.jpeg", 55.641169, 12.084252));
            Kategori2.Add(new Restaurant("Jensens Bøfshus", "4", "http://www.jensens.com/", beskrivelse, "88 88 88 88", "../Assets/restaurant.jpeg", 55.640808, 12.076909));
            Kategori2.Add(new Restaurant("Bryggegården", "1", "http://www.restaurantbryggergaarden.dk/", beskrivelse, "99 99 99 99", "../Assets/restaurant.jpeg", 55.641169, 12.084252));
            */
            Kategori3 = new ObservableCollection<Restaurant>();
            /*Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg", 55.640619, 12.090005));
            Kategori3.Add(new Restaurant("Prindsen", "4", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg", 55.641140, 12.083443));
            Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg", 55.640619, 12.090005));
            Kategori3.Add(new Restaurant("Prindsen", "2", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg", 55.641140, 12.083443));
            Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg", 55.640619, 12.090005));
            Kategori3.Add(new Restaurant("Prindsen", "4", "http://www.hotelprindsen.dk/", beskrivelse, "22 22 22 22", "../Assets/restaurant.jpeg", 55.641140, 12.083443));
            Kategori3.Add(new Restaurant("Bone's", "5", "http://www.bones.dk/", beskrivelse, "11 11 11 11", "../Assets/restaurant.jpeg", 55.640619, 12.090005));
            */
            _kategoriKatalog = new ObservableCollection<Katagori>();
            _kategoriKatalog.Add(new Katagori("Fastfood", Kategori1));
            _kategoriKatalog.Add(new Katagori("Familierestauranter", Kategori2));
            _kategoriKatalog.Add(new Katagori("Fine restauranter", Kategori3));

            _nrListe = new ObservableCollection<string>();
            _nrListe.Add("1");
            _nrListe.Add("2");
            _nrListe.Add("3");
            _nrListe.Add("4");
            _nrListe.Add("5");

            _samlingAfKategorier = new ObservableCollection<ObservableCollection<Restaurant>>();
            _samlingAfKategorier.Add(Kategori1);
            _samlingAfKategorier.Add(Kategori2);
            _samlingAfKategorier.Add(Kategori3);

            _sletSelectedRestaurantCommand = new RelayCommand(SletRestaurant);
            _tilfoejRestaurantHandler = new TilfoejRestaurantHandler(this);
            _tilfoejRestaurantCommand = new RelayCommand(_tilfoejRestaurantHandler.TilfoejRestaurant);
            //_tilfoejRestaurantHandler.SavePersonsAsync();
            _tilfoejRestaurantHandler.LoadPersonsAsync();
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

