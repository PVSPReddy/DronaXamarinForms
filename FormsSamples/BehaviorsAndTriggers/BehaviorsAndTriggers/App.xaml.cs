using System;
using BehaviorsAndTriggers.Views.SampleOne;
using Xamarin.Forms;

namespace BehaviorsAndTriggers
{
    public partial class App : Application
    {
        public static int screenHeight, screenWidth;
        public App()
        {
            InitializeComponent();

            try
            {
                MainPage = new TestSampleTwo();
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
