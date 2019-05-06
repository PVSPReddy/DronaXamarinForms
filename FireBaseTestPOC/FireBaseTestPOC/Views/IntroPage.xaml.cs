using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                //DependencyService.Get<IFireBaseService>().GetAllImageUrlsFromServer();
                //Navigation.PushModalAsync(new BikeNumberSelectionPage());
                Navigation.PushModalAsync(new TestPages());
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
}