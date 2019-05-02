using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class BikeNumberResultsDisplayPage : ContentPage
    {
        public BikeNumberResultsDisplayPage()
        {
            InitializeComponent();
        }

        void BackButonClicked(object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }
    }
}
