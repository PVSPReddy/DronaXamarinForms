using System;
using System.Threading.Tasks;
using Firebase.Database;
using FireBaseTestPOC.Droid.Services;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFirebaseDatabaseService))]
namespace FireBaseTestPOC.Droid.Services
{
    public class AndroidFirebaseDatabaseService : IFirebaseDatabaseService
    {
        public AndroidFirebaseDatabaseService(){}

        public async Task<bool> SetDataToDB()
        {
            bool response = true;
            try
            {

                var dbInstance = FirebaseDatabase.GetInstance("https://mytestfirebproj.firebaseio.com/");//https://mytestfirebproj.firebaseio.com/

                var dsfsf = dbInstance.Reference.Database;

                //var firebaseStorageReference = FirebaseStorage.GetInstance(FirebaseAppInstance).Reference;
                //StorageReference storageFilesReference;
                //storageFilesReference = firebaseStorageReference.Child(fileURL);
                //var fileURl = storageFilesReference.DownloadUrl.AddOnCompleteListener(this).AddOnFailureListener(this).AddOnSuccessListener(this);
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }
    }
}

