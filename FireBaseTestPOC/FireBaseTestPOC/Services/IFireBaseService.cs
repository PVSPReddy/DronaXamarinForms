using System;
using System.Threading.Tasks;

namespace FireBaseTestPOC.Services
{
    public interface IFireBaseService
    {
        Task<bool> CreateFireBaseInstance();
    }
}
