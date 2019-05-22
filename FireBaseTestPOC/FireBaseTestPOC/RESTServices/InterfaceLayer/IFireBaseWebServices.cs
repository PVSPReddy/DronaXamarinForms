using System;
using System.Threading.Tasks;
using FireBaseTestPOC.Models.FirebaseModels;

namespace FireBaseTestPOC.RESTServices.InterfaceLayer
{
    public interface IFireBaseWebServices : IDisposable
    {
        Task<UsersRequestObject> AddUserToDatabase(UsersRequestObject requestObject);
    }
}
