using Connect4Help.C4H_Webservice;
using Connect4Help.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Connect4Help.Managers
{
    public static class SecurityManager
    {

        private static string fileName = "ClientAuthentication";
        private static DonorProfile user;

        public static string GetClientName()    
        {
            return user == null ? "N/A" : user.FullName;
        }

        #region Local

        //Checks if the user is currently logged in
        public static bool CheckIfSignedIn()                            
        {
            return user != null;
        }

        //Signout locally from this phone
        public static void Signout()                                    
        {
            user = null;
            DeleteLocalAuthenticationInformation();
            FollowedCharities.ClearCart();
        }

        //Loads the authentication information on startup if exists
        public static async Task LoadLocalAuthenticaionInformation()    
        {
            try
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(DonorProfile));
                    var data = (DonorProfile)serializer.ReadObject(inStream.AsStreamForRead());

                    if (data != null)
                        user = data;
                }
            }
            catch { }
        }

        //Saves locally the authentication information after successful sign in
        public static async Task SetLocalAuthenticationInformation
            (DonorProfile User)                                         
        {
            user = User;
            try
            {
                MemoryStream sessionData = new MemoryStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(DonorProfile));
                serializer.WriteObject(sessionData, user);

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
        private static async Task SaveLocalAuthenticationInformation()  
        {
            try
            {
                MemoryStream sessionData = new MemoryStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(DonorProfile));
                serializer.WriteObject(sessionData, user);

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

        //Deletes the locally stored authentication information
        private static void DeleteLocalAuthenticationInformation()      
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
