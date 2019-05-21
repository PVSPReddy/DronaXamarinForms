using System;
using System.Threading.Tasks;

namespace FireBaseTestPOC.Services
{
    public interface IFirebaseDatabaseService
    {
        Task<bool> SetDataToDB();
    }
}

