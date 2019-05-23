using System;
using System.Threading.Tasks;
using FireBaseTestPOC.Models.FirebaseModels;

namespace FireBaseTestPOC.RESTServices.InterfaceLayer
{
    public interface IFireBaseWebServices : IDisposable
    {
        Task<UsersRequestObject> PATCH_UserDataToDatabase(UsersRequestObject requestObject);
        Task<UsersRequestObject> POST_UserDataToDatabase(UsersRequestObject requestObject);
    }
}
