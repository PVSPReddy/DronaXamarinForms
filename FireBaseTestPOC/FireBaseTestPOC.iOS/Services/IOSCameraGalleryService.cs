using System;
using System.IO;
using AssetsLibrary;
using FireBaseTestPOC.iOS.Services;
using FireBaseTestPOC.Services;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSCameraGalleryService))]
namespace FireBaseTestPOC.iOS.Services
{
    public class PictureActionArgs : EventArgs, IPictureActionArgs
    {
        public string LocalPictureURL { get; set; }
    }

    public class IOSCameraGalleryService : ICameraGalleryService
    {
        public IOSCameraGalleryService(){ }

        public event EventHandler<IPictureActionArgs> PictureActionCompleted;

        public void CapturePicture()
        {
            try
            {
                var parent = UIApplication.SharedApplication.KeyWindow.RootViewController;
                var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.Camera };
                parent.PresentViewController(imagePicker, true, null);
                imagePicker.TakePicture();
                //(this, (obj)=>
                //{
                //});
                imagePicker.FinishedPickingMedia += (sender, e) =>
                {
                    var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tmp.png");
                    var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
                    #region
                    image.AsPNG().Save(filepath, false);
                    var path = filepath;

                    //tco.ShowImage(path);
                    #endregion


                    #region
                    var metadata = (NSDictionary)e.Info.ObjectForKey(new NSString("UIImagePickerControllerMediaMetadata"));
                    ALAssetsLibrary library = new ALAssetsLibrary();
                    library.WriteImageToSavedPhotosAlbum(image.CGImage, metadata, (NSUrl arg1, NSError arg2) =>
                    {
                        var paths = arg1.ToString();
                    });
                    //library.WriteImageToSavedPhotosAlbum(photo.CGImage, meta, (assetUrl, error)
                    #endregion


                    /*#region
                    var imagetoalbum = UIImage.FromFile(path);
                    imagetoalbum.SaveToPhotosAlbum((UIImage image, NSError error) => 
                    {
                        var o = image;
                    });
                    #endregion*/


                    //tco.ShowImage(path);
                    PictureActionArgs args = new PictureActionArgs()
                    {
                        LocalPictureURL = path
                    };
                    PictureActionCompleted(this, args);
                    //XamCustomImage.xamCustomImage.SetImage(path);
                    if (image.AsPNG().Save(filepath, false))
                    {

                    }
                    imagePicker.DismissViewController(true, (Action)null);
                };
                imagePicker.Canceled += (sender, e) =>
                {
                    ((UIImagePickerController)sender).DismissViewController(true, null);
                };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void CropImage()
        {
            try
            {

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void SelectImage()
        {
            try
            {
                var parent = UIApplication.SharedApplication.KeyWindow.RootViewController;
                var imagePicker = new UIImagePickerController { SourceType = UIImagePickerControllerSourceType.PhotoLibrary };
                parent.PresentViewController(imagePicker, true, null);
                imagePicker.FinishedPickingMedia += (sender, e) =>
                {
                    var filepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tmp.png");
                    var image = (UIImage)e.Info.ObjectForKey(new NSString("UIImagePickerControllerOriginalImage"));
                    image.AsPNG().Save(filepath, false);
                    var path = filepath;

                    //tco.ShowImage(path);
                    PictureActionArgs args = new PictureActionArgs()
                    {
                        LocalPictureURL = path
                    };
                    PictureActionCompleted(this, args);
                    //XamCustomImage.xamCustomImage.SetImage(path);
                    if (image.AsPNG().Save(filepath, false))
                    {

                    }
                    imagePicker.DismissViewController(true, (Action)null);
                };
                imagePicker.Canceled += (sender, e) =>
                {
                    ((UIImagePickerController)sender).DismissViewController(true, null);
                };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}