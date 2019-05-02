using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class BikeNumberSelectionPage : ContentPage
    {
        public BikeNumberSelectionPage()
        {
            InitializeComponent();

            entryStartNumber.IsVisible = switchNumberRange.IsToggled;
            entryEndNumber.IsVisible = switchNumberRange.IsToggled;
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

        void IsSwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            try
            {
                var owner = (Switch)sender;
                if(owner == switchNumberRange)
                {
                    entryNumber.IsVisible = !owner.IsToggled;
                    entryStartNumber.IsVisible = owner.IsToggled;
                    entryEndNumber.IsVisible = owner.IsToggled;
                }
                else if (owner == switchSumNumbers)
                {
                    stackRequiredSum.IsVisible = owner.IsToggled;
                    stackAddRemoveButton.IsVisible = owner.IsToggled;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        void AddRemoveButton(object sender, System.EventArgs e)
        {
            try
            {
                var owner = (Label)sender;
                if (owner.Text == "+")
                {
                    var trrtr = new CustomEntryGroup()
                    {
                        Style = (Style)Resources["entryStyles"],
                        CustomPlaceholder = "Enter Number",
                        CustomKeyboard = Keyboard.Numeric
                    };
                    stackRequiredSum.Children.Add(trrtr);
                }
                else
                {
                    if ((stackRequiredSum.Children.Count - 1) > -1)
                    {
                        stackRequiredSum.Children.RemoveAt(stackRequiredSum.Children.Count - 1);
                    }
                }
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
                    BikeNumberSelector bikeNumberSelector = new BikeNumberSelector();
                    var startNum = Convert.ToInt32(entryStartNumber.Value);
                    var endNum = Convert.ToInt32(entryEndNumber.Value);
                    var startNumber = (startNum < endNum) ? startNum : endNum;
                    var endNumber = (startNum < endNum) ? endNum : startNum;
                    var numbersList = await bikeNumberSelector.GetNumbersList(startNumber, endNumber, null, DigitsOrder.ExactAscendingWihAdjacentRepitition, false);
                    if(numbersList.Count > 0)
                    {
                        await Navigation.PushModalAsync(new BikeNumberResultsDisplayPage(numbersList));
                    }
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