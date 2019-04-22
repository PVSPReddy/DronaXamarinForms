using System;
using System.Collections.Generic;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        void DoneButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                //Navigation.PushModalAsync(new DynamicGridPage());
                DependencyService.Get<IFireBaseService>().GetAllImageUrlsFromServer();
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
}
