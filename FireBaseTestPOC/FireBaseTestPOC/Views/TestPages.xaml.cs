﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class TestPages : ContentPage

    {
        List<int> sumDigits;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            stackRangeNumbers.IsVisible = switchNumberRange.IsToggled;
            stackRangeNumbers.Opacity = 1;
        }

        public TestPages()
        {
            InitializeComponent();
            sumDigits = new List<int>();

            labelSingleNumberResult.Text = "Number : 0 \nSum : 0";

            entryNumber.OnCustomTextChanged += EntryCustomTextChangedEvent;
            //stackRangeNumbers.IsVisible = switchNumberRange.IsToggled;
            stackSumDigits.IsVisible = switchNumberRange.IsToggled;


            //pickerNumber.ItemsSource = new List<int>()
            //{
            //    1,2,3,4,5,6,7,8,9,10
            //};
            pickerNumber.ItemsSource = new List<string>()
            {
                "","1","2","3","4","5","6","7","8","9","10"
            };

        }

        private async void EntryCustomTextChangedEvent(object sender, EventArgs e)
        {
            try
            {
                int Num = 0;
                if (!(string.IsNullOrEmpty(entryNumber.Value)))
                {
                    Num = Convert.ToInt32(entryNumber.Value);
                }
                else
                {
                    Num = 0;
                }
                BikeNumberSelector bikeNumberSelector = new BikeNumberSelector();
                var number = await bikeNumberSelector.GetNumbersList(Num);
                labelSingleNumberResult.Text = "Number : " + number.Digits.ToString() + "\nSum : " + number.DigitsSum.ToString();
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

        void IsSwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            try
            {
                var owner = (CustomSwitchLabelGroup)sender;
                if (owner == switchNumberRange)
                {
                    stackSingleNumber.IsVisible = !owner.IsToggled;
                    stackRangeNumbers.IsVisible = owner.IsToggled;
                    stackSumDigits.IsVisible = owner.IsToggled;
                    if (!owner.IsToggled)
                    {
                        switchSumNumbers.IsToggled = owner.IsToggled;
                        entryStartNumber.Value = string.Empty;
                        entryEndNumber.Value = string.Empty;
                    }
                    else
                    {
                        entryNumber.Value = string.Empty;
                    }
                }
                else if (owner == switchSumNumbers)
                {
                    stackRequiredSum.IsVisible = owner.IsToggled;
                    stackAddRemoveButton.IsVisible = owner.IsToggled;
                    if (!owner.IsToggled)
                    {
                        stackRequiredSum.Children.Clear();
                        sumDigits.Clear();
                    }
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
                    if (stackRequiredSum.Children.Count < 9)
                    {
                        var entryLuckyNumber = new CustomEntryGroup(MainFieldType.EntryField)
                        {
                            Style = (Style)Resources["entryStyles"],
                            CustomPlaceholder = "Enter Number",
                            CustomKeyboard = Keyboard.Numeric
                        };
                        entryLuckyNumber.OnCustomTextChanged += SumDigitsTextChangedEvents;
                        stackRequiredSum.Children.Add(entryLuckyNumber);
                    }
                    else
                    {
                        DisplayAlert("Alert", "Max limit Reached", "OK");
                    }
                }
                else
                {
                    if ((stackRequiredSum.Children.Count - 1) > -1)
                    {
                        var child = (CustomEntryGroup)stackRequiredSum.Children[stackRequiredSum.Children.Count - 1];
                        if (child != null)
                        {
                            stackRequiredSum.Children.RemoveAt(stackRequiredSum.Children.Count - 1);
                            if (sumDigits.Count > 0)
                            {
                                UpdateLuckyNumbersList();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        private void SumDigitsTextChangedEvents(object sender, EventArgs e)
        {
            try
            {
                UpdateLuckyNumbersList();
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void UpdateLuckyNumbersList()
        {
            try
            {
                var luckyNumsHolders = stackRequiredSum.Children;
                sumDigits.Clear();
                foreach (var item in luckyNumsHolders)
                {
                    var owner = (CustomEntryGroup)item;
                    if (!(string.IsNullOrEmpty(owner.Value)))
                    {
                        sumDigits.Add(Convert.ToInt32(owner.Value));
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
                if (isValidate)
                {
                    BikeNumberSelector bikeNumberSelector = new BikeNumberSelector();
                    if (stackRangeNumbers.IsVisible)
                    {
                        var startNum = Convert.ToInt32(entryStartNumber.Value);
                        var endNum = Convert.ToInt32(entryEndNumber.Value);
                        var startNumber = (startNum < endNum) ? startNum : endNum;
                        var endNumber = (startNum < endNum) ? endNum : startNum;
                        int[] _sumDigits = null;
                        if (sumDigits.Count > 0)
                        {
                            _sumDigits = new int[sumDigits.Count];
                            for (int i = 0; i < sumDigits.Count; i++)
                            {
                                _sumDigits[i] = sumDigits[i];
                            }
                        }
                        var numbersList = await bikeNumberSelector.GetNumbersList(startNumber, endNumber, _sumDigits, DigitsOrder.ExactAscendingWihAdjacentRepitition, false);

                        if (numbersList.Count > 0)
                        {
                            await Navigation.PushModalAsync(new BikeNumberResultsDisplayPage(numbersList));
                        }
                    }
                }
                else
                { }
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
            if ((stackSingleNumber.IsVisible) && string.IsNullOrEmpty(entryNumber.Value))
            {
                isValidate = false;
                entryNumber.BorderColor = Color.Maroon;
            }
            if ((stackRangeNumbers.IsVisible) && string.IsNullOrEmpty(entryStartNumber.Value))
            {
                isValidate = false;
                entryStartNumber.BorderColor = Color.Maroon;
            }
            if ((stackRangeNumbers.IsVisible) && string.IsNullOrEmpty(entryEndNumber.Value))
            {
                isValidate = false;
                entryEndNumber.BorderColor = Color.Maroon;
            }
            //if ((stackSumDigits.IsVisible) && (entryEndNumber.Value))
            //{
            //    isValidate = false;
            //    entryEndNumber.BorderColor = Color.Maroon;
            //}
            return isValidate;
        }
    }
}