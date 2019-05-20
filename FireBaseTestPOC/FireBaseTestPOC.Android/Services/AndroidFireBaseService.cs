using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Gms.Tasks;
using Android.Support.V7.App;
using Firebase.Storage;
using FireBaseTestPOC.Droid.Services;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFireBaseService))]
namespace FireBaseTestPOC.Droid.Services
{
    public class AndroidFireBaseService : IFireBaseService//AppCompatActivity, IFireBaseService
    {

        public AndroidFireBaseService(){}

        public async Task<bool> CreateFireBaseInstance()
        {
            bool response = false;
            //try
            //{
            //    Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
            //    FirebaseStorage storage = FirebaseStorage.GetInstance(fireBaseApp);
            //}
            //catch(Exception ex)
            //{
            //    var msg = ex.Message + "\n" + ex.StackTrace;
            //    System.Diagnostics.Debug.WriteLine(msg);
            //}
            return response;
        }


        #region to send a single photo to server
        public async Task<string> UploadAnImageToFireBase(string fileURL, string fileNameWithOutExtension = "", string folderStructureName = "")
        {
            string response = "";
            try
            {
                Stream streamResponse = new MemoryStream();
                FileStream fs = new FileStream(fileURL, FileMode.Open, FileAccess.Read);

                using (System.IO.Stream stream = new FileStream(fileURL, FileMode.Open, FileAccess.Read))
                {
                    streamResponse = stream;
                    var firebaseStorageReference = FirebaseStorage.GetInstance("gs://mytestfirebproj.appspot.com").Reference;
                    StorageReference storageFilesReference;
                    if (string.IsNullOrEmpty(fileNameWithOutExtension))
                    {
                        string fileNameWithExtension = Path.GetFileName(fileURL);
                        storageFilesReference = firebaseStorageReference.Child(folderStructureName + fileNameWithExtension);// ("TemporaryTestFiles/" + fileNameWithExtension);
                    }
                    else
                    {
                        string fileExtension = Path.GetExtension(fileURL);
                        storageFilesReference = firebaseStorageReference.Child(folderStructureName + fileNameWithOutExtension + fileExtension);// ("TemporaryTestFiles/" + fileNameWithOutExtension + fileExtension);
                    }
                    AndroidConversionService androidConversionService = new AndroidConversionService();
                    var urlBytes = await androidConversionService.GetBytesFromStream(streamResponse);
                    if (urlBytes != null)
                    {
                        UploadTask uploadTask = storageFilesReference.PutBytes(urlBytes);
                        //uploadTask.AddOnCompleteListener()
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }
        #endregion


        public async Task<string> GetAllImageUrlsFromServer(string fileURL, string fileNameWithOutExtension = "")
        {
            string response = "";
            try
            {
                var firebaseStorageReference = FirebaseStorage.GetInstance("gs://mytestfirebproj.appspot.com").Reference;
                /*
                // Create a storage reference from our app
                StorageReference storageRef = storage.getReference();

                // Create a reference with an initial file path and name
                StorageReference pathReference = storageRef.child("images/stars.jpg");

                // Create a reference to a file from a Google Cloud Storage URI
                StorageReference gsReference = storage.getReferenceFromUrl("gs://bucket/images/stars.jpg");

                // Create a reference from an HTTPS URL
                // Note that in the URL, characters are URL escaped!
                StorageReference httpsReference = storage.getReferenceFromUrl("https://firebasestorage.googleapis.com/b/bucket/o/images%20stars.jpg");
                */
                StorageReference storageFilesReference;
                storageFilesReference = firebaseStorageReference.Child(fileURL);

                //storageFilesReference.DownloadUrl.AddOnCompleteListener()
                //storageFilesReference.GetBytes(1024 * 1024);

                var fileURl = storageFilesReference.DownloadUrl;
                //var file = storageFilesReference.GetFile(new Android.Net.Uri());
                //var uro = new Android.Net.Uri();

                //File localFile = new File.Create("");

                //var file;



            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }

        public async Task<string> GetAllImageUrlsFromServer()
        {
            string response = "";
            /*
            try
            {
                Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
                FirebaseStorage storageImage = FirebaseStorage.GetInstance(fireBaseApp, "gs://mytestfirebproj.appspot.com");
                //storageImage.Reference.Child()
                ////Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
                ////FirebaseStorage storage = FirebaseStorage.GetInstance(fireBaseApp);
                //var stroageImage = await new FirebaseStorage("xamarinfirebase-d3352.appspot.com")  
                //.Child("XamarinMonkeys")  
                //.Child("image.jpg")  
                //.PutAsync(imageStream);
                //string imgurl = stroageImage; 
                //return imgurl;
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            */
            try
            {
                AndroidConversionService androidConversionService = new AndroidConversionService();
                var streamResponse = await androidConversionService.GetStreamFromLocalFileURL("");
                Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
                //FirebaseStorage storageImage = FirebaseStorage.GetInstance(fireBaseApp, "gs://mytestfirebproj.appspot.com");
                var storageImage = FirebaseStorage.GetInstance(fireBaseApp, "gs://mytestfirebproj.appspot.com").Reference.Child("FireBaseTestImageOne");
                //storageImage.Reference.Child()
                ////Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
                ////FirebaseStorage storage = FirebaseStorage.GetInstance(fireBaseApp);
                //var stroageImage = await new FirebaseStorage("xamarinfirebase-d3352.appspot.com")  
                //.Child("XamarinMonkeys")  
                //.Child("image.jpg")  
                //.PutAsync(imageStream);
                //string imgurl = stroageImage; 
                //return imgurl;
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }

        //public async Task<bool> CreateFireBaseInstance()
        //{
        //    bool response = false;
        //    try
        //    {
        //    }
        //    catch (Exception ex)
        //    {
        //        var msg = ex.Message + "\n" + ex.StackTrace;
        //        System.Diagnostics.Debug.WriteLine(msg);
        //    }
        //    return response;
        //}
    }
}

