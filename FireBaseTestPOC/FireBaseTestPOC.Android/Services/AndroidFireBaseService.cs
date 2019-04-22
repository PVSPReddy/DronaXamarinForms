using System;
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

        public async Task<string> GetAllImageUrlsFromServer()
        {
            string response = "";
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

