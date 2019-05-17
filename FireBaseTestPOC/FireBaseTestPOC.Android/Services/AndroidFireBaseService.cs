using System;
using System.IO;
using System.Threading.Tasks;
using Android.App;
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

        public async Task<string> GetAllImageUrlsFromServer(string fileURL)
        {
            string response = "";
            try
            {
                Stream streamResponse = new MemoryStream();
                AndroidConversionService androidConversionService = new AndroidConversionService();
                //var streamResponse = await androidConversionService.GetStreamFromLocalFileURL(fileURL);
                Firebase.FirebaseApp fireBaseApp = Firebase.FirebaseApp.Instance;
                //var storageImage = FirebaseStorage.GetInstance(fireBaseApp, "gs://mytestfirebproj.appspot.com").Reference.Child("TemporaryTestFiles").Child("TestFileOne").PutStream(streamResponse);
                FileStream fs = new FileStream(fileURL, FileMode.Open, FileAccess.Read);
                using (System.IO.Stream stream = new FileStream(fileURL, FileMode.Open, FileAccess.Read))
                {
                    streamResponse = stream;
                }
                //var storageImage = FirebaseStorage.GetInstance(fireBaseApp, "gs://mytestfirebproj.appspot.com").Reference.Child("TemporaryTestFiles").Child("TestFileOne.jpg").PutStream(streamResponse);
                var storageImage = FirebaseStorage.GetInstance(fireBaseApp, "gs://mytestfirebproj.appspot.com").Reference.Child("TemporaryTestFiles").Child("TestFileOne.jpg");
                var cre = storageImage.PutStream(streamResponse);
                //var rer = new FirebaseStorage("");
                //await Task.Delay(12000);
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

