using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
using Android.Gms.Tasks;
using Android.Support.V7.App;
using Firebase.Storage;
using FireBaseTestPOC.Droid.Services;
using FireBaseTestPOC.Services;
using Java.Lang;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFireBaseService))]
namespace FireBaseTestPOC.Droid.Services
{
    public class FireBaseStorageActionArgs : EventArgs, IFireBaseStorageActionArgs
    {
        public FirebaseReturnType ReturnType { get; set; }
        public string LocalPictureURL { get; set; }
        public byte ByteData { get; set; }
        public Stream StreamData { get; set; }
    }

    //public class AndroidFireBaseService : IFireBaseService//AppCompatActivity, IFireBaseService
    public class AndroidFireBaseService : Java.Lang.Object, IFireBaseService, IOnSuccessListener, IOnCompleteListener, IOnFailureListener, IOnPausedListener, IOnProgressListener //AppCompatActivity, IFireBaseService
    {
        public AndroidFireBaseService(){}

        public event EventHandler<IFireBaseStorageActionArgs> FirebaseActionCompleted;

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
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }
        #endregion

        #region to get single image
        public async Task<string> GetAllImageUrlsFromServer(string fileURL, string fileNameWithOutExtension = "")
        {
            string response = "";
            try
            {
                var firebaseStorageReference = FirebaseStorage.GetInstance("gs://mytestfirebproj.appspot.com").Reference;
                #region multiple ways to get firebase instance
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
                #endregion
                StorageReference storageFilesReference;
                storageFilesReference = firebaseStorageReference.Child(fileURL);               
                var fileURl = storageFilesReference.DownloadUrl;
                #region both works
                /*
                var fileBytes = storageFilesReference.GetBytes(1024 * 1024).
                                                     AddOnCompleteListener(new OnCompleteListener()).
                                                     AddOnFailureListener(new OnFailureListener()).
                                                     AddOnSuccessListener(new OnSuccessListener());
                var fileBytes = storageFilesReference.GetBytes(1024 * 1024).
                                                     AddOnCompleteListener(this).
                                                     AddOnFailureListener(this).
                                                     AddOnSuccessListener(this);
                */
                #endregion
                var fileStream = storageFilesReference.Stream;
                var rere = storageFilesReference.Path;
                var cfgfgf = storageFilesReference.Root.Path;

                var trtf = storageFilesReference.DownloadUrl.AddOnCompleteListener(this).AddOnFailureListener(this).AddOnSuccessListener(this);

            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }
        #endregion

        #region to delete single image
        public async Task<string> DeleteAnImageFromFireBase(string fileURL, string fileNameWithOutExtension = "", string folderStructureName = "")
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
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }
        #endregion

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
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return response;
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            try
            {
                FireBaseStorageActionArgs fireBaseStorageActionArgs = new FireBaseStorageActionArgs();
                switch (result.Class.CanonicalName)
                {
                    case "android.net.Uri.StringUri":
                        var fileURL = result.ToString();
                        fireBaseStorageActionArgs.ReturnType = FirebaseReturnType.StringURL;
                        fireBaseStorageActionArgs.LocalPictureURL = fileURL;
                        FirebaseActionCompleted(this, fireBaseStorageActionArgs);
                        break;
                    case "byte[]":
                        break;
                    default:
                        if(result.Class.CanonicalName.ToLower().Contains("string".ToLower())){}
                        break;
                }
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void OnFailure(Java.Lang.Exception e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void OnPaused(Java.Lang.Object snapshot)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void OnProgress(Java.Lang.Object snapshot)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }

    /*
    public class OnCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        public OnCompleteListener() { }
        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
    public class OnSuccessListener : Java.Lang.Object, IOnSuccessListener
    {
        public OnSuccessListener() { }

        public void OnSuccess(Java.Lang.Object result)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
    public class OnFailureListener : Java.Lang.Object, IOnFailureListener
    {
        public OnFailureListener() { }

        public void OnFailure(Java.Lang.Exception e)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
    public class OnPausedListener : Java.Lang.Object, IOnPausedListener
    {
        public OnPausedListener() { }

        public void OnPaused(Java.Lang.Object snapshot)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
    public class OnProgressListener : Java.Lang.Object, IOnProgressListener
    {
        public OnProgressListener() { }

        public void OnProgress(Java.Lang.Object snapshot)
        {
            try
            {
            }
            catch (System.Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
    */
}