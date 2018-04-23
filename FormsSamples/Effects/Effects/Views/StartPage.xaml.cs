using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Effects
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void SubmitClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new TestPageOne());
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }
    }
}
