using System;
using FireBaseTestPOC.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSFirebaseDatabaseService))]
namespace FireBaseTestPOC.iOS.Services
{
    public class IOSFirebaseDatabaseService : ContentPage
    {
        public IOSFirebaseDatabaseService(){}
    }
}

