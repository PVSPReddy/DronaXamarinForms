using System;
using System.Collections.Generic;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class TestPageTwo : ContentPage
    {
        string url = "";
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
                    //obtainedImage.Source = new UriImageSource()
                    //{
                    //    CachingEnabled = false,
                    //    Uri = new Uri(e.LocalPictureURL)
                    //};
                    obtainedImage.Source = ImageSource.FromFile(e.LocalPictureURL);//FromUri(e.LocalPictureURL)
                    url = e.LocalPictureURL;
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
                    case "Done":
                        if (!(string.IsNullOrEmpty(url)))
                        {
                            await DependencyService.Get<IFireBaseService>().GetAllImageUrlsFromServer(url);
                        }
                        else
                        {

                        }
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