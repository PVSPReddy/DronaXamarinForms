using System;
using FireBaseTestPOC.Droid.Services;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidFirebaseDatabaseService))]
namespace FireBaseTestPOC.Droid.Services
{
    public class AndroidFirebaseDatabaseService : IFirebaseDatabaseService
    {
        public AndroidFirebaseDatabaseService(){}
    }
}

