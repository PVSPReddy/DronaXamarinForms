using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using FireBaseTestPOC.CustomControls;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class BikeNumberSelectionPage : ContentPage
    {
        public BikeNumberSelectionPage()
        {
            InitializeComponent();
            testTwo.PropertyChanged += EntryPropertyChangedEvent;
        }

        private void EntryPropertyChangedEvent(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                var owner = (CustomEntryGroup)sender;
                if(e.PropertyName == "Value")
                {
                    if(!(string.IsNullOrEmpty(owner.Value)))
                    {
                        owner.BorderColor = Color.Gray;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
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
                    //var valueOne = testOne.TextColor;
                    //var valueTwo = testTwo.TextColor;
                    Navigation.PushModalAsync(new BikeNumberResultsDisplayPage());
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
            if(string.IsNullOrEmpty(entryStartNumber.Value))
            {
                isValidate = false;
                entryStartNumber.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryEndNumber.Value))
            {
                isValidate = false;
                entryEndNumber.BorderColor = Color.Maroon;
            }
            return isValidate;
        }
    }
}
