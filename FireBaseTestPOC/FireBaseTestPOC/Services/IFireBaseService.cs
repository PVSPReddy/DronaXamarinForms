using System;
using System.Threading.Tasks;

namespace FireBaseTestPOC.Services
{
    public interface IFireBaseService
    {
        Task<bool> CreateFireBaseInstance();

        Task<string> GetAllImageUrlsFromServer();

        Task<string> GetAllImageUrlsFromServer(string fileURL, string fileNameWithOutExtension = "");

        Task<string> UploadAnImageToFireBase(string fileURL, string fileNameWithOutExtension = "", string folderStructureName = "");
    }
}
