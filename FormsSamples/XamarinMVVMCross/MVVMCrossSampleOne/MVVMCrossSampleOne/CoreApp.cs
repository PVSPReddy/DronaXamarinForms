using System;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MVVMCrossSampleOne.ViewModels;
using Xamarin.Forms;

namespace MVVMCrossSampleOne
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MvxFormsViewModel>();
        }
    }
}

