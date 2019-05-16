using System;
namespace FireBaseTestPOC.Services
{
    public interface ICameraGalleryService
    {
        void CapturePicture();

        void SelectImage();

        void CropImage();

        event EventHandler<IPictureActionArgs> PictureActionCompleted;
    }

    public interface IPictureActionArgs
    {
        string LocalPictureURL { get; set; }
    }
}
