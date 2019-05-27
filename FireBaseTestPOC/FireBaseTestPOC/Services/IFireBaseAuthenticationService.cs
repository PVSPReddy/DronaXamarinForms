using System;
using System.Threading.Tasks;

namespace FireBaseTestPOC.Services
{
    public interface IFireBaseAuthenticationService
    {
        Task<bool> AuthenticateUser();
    }
}
