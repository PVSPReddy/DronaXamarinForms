using System;
using System.Threading.Tasks;

namespace FireBaseTestPOC.Services
{
    public interface IFireBaseService
    {
        Task<bool> CreateFireBaseInstance();

        Task<string> GetAllImageUrlsFromServer();

        Task<string> GetAllImageUrlsFromServer(string fileURL);
    }
}
