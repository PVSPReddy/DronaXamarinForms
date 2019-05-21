using System;
using System.Collections.Generic;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class TestPageTwo : ContentPage
    {
        string localFileURL = "";
        public TestPageTwo()
        {
            InitializeComponent();//FireBaseTestImageOne.png
            DependencyService.Get<ICameraGalleryService>().PictureActionCompleted += (object sender, IPictureActionArgs e) =>
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine(e.LocalPictureURL);
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
                try
                {
                    obtainedImage.Source = ImageSource.FromFile(e.LocalPictureURL);//FromUri(e.LocalPictureURL)
                    localFileURL = e.LocalPictureURL;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
            DependencyService.Get<IFireBaseStorageService>().FirebaseActionCompleted += (object sender, IFireBaseStorageActionArgs e) =>
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine(e.LocalPictureURL);
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
                try
                {
                    if (e.ReturnType == FirebaseReturnType.StringURL)
                    {
                        var timeStamp = DateTime.Today.Ticks;
                        var imageURL = e.LocalPictureURL + "&timeStamp=" + timeStamp;
                        obtainedImage.Source = new UriImageSource()
                        {
                            CachingEnabled = false,
                            Uri = new Uri(imageURL)
                        };
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };
        }

        void BackButonClicked(object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        async void DoneButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                var owner = (Button)sender;
                switch (owner.Text)
                {
                    case "Upload":
                        if (!(string.IsNullOrEmpty(localFileURL)))
                        {
                            await DependencyService.Get<IFireBaseStorageService>().UploadAnImageToFireBase(localFileURL, "", "TemporaryTestFiles/");
                        }
                        else
                        {

                        }
                        break;
                    case "Download":
                        var _url = "TemporaryTestFiles/TestFileOne.jpg";
                        await DependencyService.Get<IFireBaseStorageService>().GetAnImageUrlFromServer(_url);
                        break;
                    case "Done":
                        //if (!(string.IsNullOrEmpty(url)))
                        //{
                        //    await DependencyService.Get<IFireBaseService>().UploadAnImageToFireBase(url, "", "TemporaryTestFiles/");
                        //}
                        //else
                        //{
                        //}
                        break;
                    case "Access DB":
                        await DependencyService.Get<IFirebaseDatabaseService>().SetDataToDB();
                        break;
                    case "Gallery":
                        DependencyService.Get<ICameraGalleryService>().SelectImage();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
}