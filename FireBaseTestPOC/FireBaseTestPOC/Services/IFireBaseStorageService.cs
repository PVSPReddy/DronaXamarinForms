using System;
using System.Threading.Tasks;

namespace FireBaseTestPOC.Services
{
    public interface IFireBaseStorageService
    {
        Task<bool> CreateFireBaseInstance();

        Task<string> GetAllImageUrlsFromServer();

        Task<string> GetAnImageUrlFromServer(string fileURL, string fileNameWithOutExtension = "");

        Task<string> GetAllImageUrlsFromServer(string fileURL, string fileNameWithOutExtension = "");

        Task<string> UploadAnImageToFireBase(string fileURL, string fileNameWithOutExtension = "", string folderStructureName = "");

        Task<string> DeleteAnImageFromFireBase(string fileURL, string fileNameWithOutExtension = "", string folderStructureName = "");

        event EventHandler<IFireBaseStorageActionArgs> FirebaseActionCompleted;
    }

    public interface IFireBaseStorageActionArgs
    {
        FirebaseReturnType ReturnType { get; set; }
        string LocalPictureURL { get; set; }
        byte ByteData { get; set; }
        System.IO.Stream StreamData { get; set; }
    }

    public enum FirebaseReturnType
    {
        StringURL, ByteData, StreamData
    }
}
