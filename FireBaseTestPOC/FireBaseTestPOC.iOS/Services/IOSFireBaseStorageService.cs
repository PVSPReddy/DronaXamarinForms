using System;
using System.Threading.Tasks;
using FireBaseTestPOC.iOS.Services;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

[assembly : Dependency(typeof(IOSFireBaseStorageService))]
namespace FireBaseTestPOC.iOS.Services
{

    public class FireBaseStorageActionArgs : EventArgs, IFireBaseStorageActionArgs
    {
        public FirebaseReturnType ReturnType { get; set; }
        public string LocalPictureURL { get; set; }
        public byte ByteData { get; set; }
        public System.IO.Stream StreamData { get; set; }
    }

    public class IOSFireBaseStorageService : IFireBaseStorageService
    {
        public IOSFireBaseStorageService(){}

        public event EventHandler<IFireBaseStorageActionArgs> FirebaseActionCompleted;

        public Task<bool> CreateFireBaseInstance()
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAnImageFromFireBase(string fileURL, string fileNameWithOutExtension = "", string folderStructureName = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllImageUrlsFromServer()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllImageUrlsFromServer(string fileURL, string fileNameWithOutExtension = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAnImageUrlFromServer(string fileURL, string fileNameWithOutExtension = "")
        {
            throw new NotImplementedException();
        }

        public Task<string> UploadAnImageToFireBase(string fileURL, string fileNameWithOutExtension = "", string folderStructureName = "")
        {
            throw new NotImplementedException();
        }
    }
}

