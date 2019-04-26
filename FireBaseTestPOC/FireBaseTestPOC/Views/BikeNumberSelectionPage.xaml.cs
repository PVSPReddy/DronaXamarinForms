using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class BikeNumberSelectionPage : ContentPage
    {
        public BikeNumberSelectionPage()
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

        async void DoneButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                var isValidate = await Validate();
                if(isValidate)
                {
                    var valueOne = testOne.TextColor;
                    var valueTwo = testTwo.TextColor;
                }
                else
                {}
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        async Task<bool> Validate()
        {
            bool isValidate = true;
            return isValidate;
        }
    }
}
