using System;
using BehaviorsAndTriggers.Views.SampleOne;
using BehaviorsAndTriggers.Views.SampleTwo;
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
                MainPage = new TestTriggerSampleOne();
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
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
