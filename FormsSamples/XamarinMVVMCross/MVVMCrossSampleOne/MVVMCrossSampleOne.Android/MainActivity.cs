using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace MVVMCrossSampleOne.Droid
{

    [Activity(Label = "MVVMCrossSampleOne.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher =true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
        }
    }

    //[Activity(Label = "MVVMCrossSampleOne", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    //public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    //{
    //    protected override void OnCreate(Bundle bundle)
    //    {
    //        TabLayoutResource = Resource.Layout.Tabbar;
    //        ToolbarResource = Resource.Layout.Toolbar;

    //        base.OnCreate(bundle);

    //        global::Xamarin.Forms.Forms.Init(this, bundle);
    //        LoadApplication(new App());
    //    }
    //}
}

