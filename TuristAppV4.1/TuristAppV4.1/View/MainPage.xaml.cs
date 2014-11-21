using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using TuristAppV4._1.View;
using TuristAppV4._1.ViewModel;


namespace TuristAppV4._1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridView1.SelectedIndex == -1 && gridView2.SelectedIndex == -1 && gridView3.SelectedIndex == -1)
            {
                MessageDialog telefonfejl = new MessageDialog("Vælg venligst en restaurant");
                await telefonfejl.ShowAsync();
            }
            else
            {
                this.Frame.Navigate(typeof(Restaurant)); 
            }   
        }

        private async void AppBarButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TilfoejRestaurant));
        }



        private async void gridView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridView1.SelectedIndex > -1)
            {
                gridView2.SelectedIndex = -1;
                gridView3.SelectedIndex = -1;
            }
        }

        private void gridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridView2.SelectedIndex > -1)
            {
                gridView1.SelectedIndex = -1;
                gridView3.SelectedIndex = -1;
            }
        }

        private void gridView3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridView3.SelectedIndex > -1)
            {
                gridView1.SelectedIndex = -1;
                gridView2.SelectedIndex = -1;
            }
        }
    }
}
