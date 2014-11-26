using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using TuristAppV4._1.Model;

namespace TuristAppV4._1.ViewModel
{
    internal class PersistenceFacade
    {
        private static string jsonFileName = "PersonsAsJson.dat";

        public static async void SavePersonsAsJsonAsync(
            ObservableCollection<ObservableCollection<Restaurant>> _collectionOfRestaurants)
        {
            string personsJsonString = JsonConvert.SerializeObject(_collectionOfRestaurants);
            SerializePersonsFileAsync(personsJsonString, jsonFileName);
        }

        public static async Task<ObservableCollection<ObservableCollection<Restaurant>>> LoadPersonsFromJsonAsync()
        {
            string personsJsonString = await DeSerializePersonsFileAsync(jsonFileName);
            return
                (ObservableCollection<ObservableCollection<Restaurant>>)
                    JsonConvert.DeserializeObject(personsJsonString,
                        typeof (ObservableCollection<ObservableCollection<Restaurant>>));
        }

        public static async void SerializePersonsFileAsync(string PersonsString, string fileName)
        {
            StorageFile localFile =
                await
                    ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                        CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, PersonsString);
        }

        public static async Task<string> DeSerializePersonsFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }
    }

}
