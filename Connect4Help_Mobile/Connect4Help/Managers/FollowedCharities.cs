using Connect4Help.Structure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Connect4Help.Managers
{
    public static class FollowedCharities
    {

        private static string fileName = "ClientCart";
        public static ObservableCollection<C4H_Webservice.CharityProfile> FollowedCharitiesList;

        public static int GetFollowedCharitiesCount()   
        {
            return FollowedCharitiesList == null ? 0 : FollowedCharitiesList.Count();
        }

        #region Local

        public static bool CheckIfAddedToCart(int ID)                       
        {
            if (FollowedCharitiesList == null)
                return false;

            foreach (C4H_Webservice.CharityProfile items in FollowedCharitiesList)
                if (items.UserID == ID)
                    return true;

            return false;
        }
        public static void AddToCart(C4H_Webservice.CharityProfile Item)    
        {
            if (FollowedCharitiesList == null)
                FollowedCharitiesList = new ObservableCollection<C4H_Webservice.CharityProfile>();

            if (CheckIfAddedToCart(Item.UserID))
                return;

            FollowedCharitiesList.Add(Item);
            SaveLocalWatchListInformation();
        }
        public static void ClearCart()                                      
        {
            FollowedCharitiesList = null;
            DeleteWatchListInformation();
        }

        //Loads the cart information on startup if exists
        public static async Task LoadLocalWatchlistInformation()            
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<C4H_Webservice.CharityProfile>));
                    var data = (ObservableCollection<C4H_Webservice.CharityProfile>)serializer.ReadObject(inStream.AsStreamForRead());

                    if (data != null)
                        FollowedCharitiesList = data;
                }
            }
            catch { }
        }

        //Saves locally the cart information after each add item
        private static async Task SaveLocalWatchListInformation()           
        {
            DeleteWatchListInformation();
            try
            {
                MemoryStream sessionData = new MemoryStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(ObservableCollection<C4H_Webservice.CharityProfile>));
                serializer.WriteObject(sessionData, FollowedCharitiesList);

                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName);
                using (Stream fileStream = await file.OpenStreamForWriteAsync())
                {
                    sessionData.Seek(0, SeekOrigin.Begin);
                    await sessionData.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }
            }
            catch { }
        }

        //Deletes the locally stored cart information
        private static void DeleteWatchListInformation()                    
        {
            try
            {
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication();
                storage.DeleteFile(fileName);

            }
            catch { }
        } 

        #endregion

    }
}
