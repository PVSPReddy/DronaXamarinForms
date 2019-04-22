using System;
using System.Threading.Tasks;
using FireBaseTestPOC.iOS.Services;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

[assembly : Dependency(typeof(IOSFireBaseService))]
namespace FireBaseTestPOC.iOS.Services
{
    public class IOSFireBaseService : IFireBaseService
    {
        public IOSFireBaseService(){}

        public Task<bool> CreateFireBaseInstance()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAllImageUrlsFromServer()
        {
            throw new NotImplementedException();
        }
    }
}

