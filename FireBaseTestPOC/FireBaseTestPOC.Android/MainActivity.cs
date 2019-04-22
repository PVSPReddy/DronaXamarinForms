using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using FireBaseTestPOC.Views;
using Firebase;

namespace FireBaseTestPOC.Droid
{
    [Activity(Label = "FireBaseTestPOC", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            //AccessPreRequirements();
            base.OnCreate(savedInstanceState); 
            AccessPreRequirements();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            #region to init firebase
            FirebaseApp.InitializeApp(this);
            #endregion

            LoadApplication(new App());
        }

        void AccessPreRequirements()
        {
            #region to set orientations dynamically
            MessagingCenter.Subscribe<DynamicGridPage>(this, "LandScape", (DynamicGridPage obj) =>
            {
                RequestedOrientation = ScreenOrientation.Landscape;
            });
            MessagingCenter.Subscribe<DynamicGridPage>(this, "Portrait", (DynamicGridPage obj) =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });
            MessagingCenter.Subscribe<DynamicGridPage>(this, "Sensor", (DynamicGridPage obj) =>
            {
                RequestedOrientation = ScreenOrientation.Sensor;
            });
            #endregion

        }
    }
}