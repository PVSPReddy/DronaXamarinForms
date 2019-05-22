using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.Models.FirebaseModels;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class TestPageThree : ContentPage
    {
        List<long> sumDigits;

        public TestPageThree()
        {
            InitializeComponent();
            sumDigits = new List<long>();
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
                var owner = (Button)sender;
                switch (owner.Text)
                {
                    case "Done":
                        var isValid = await Validate();
                        if(isValid)
                        {
                            UsersRequestObject requestObject = null;
                            requestObject = await GetValues(requestObject);
                            if (requestObject != null)
                            {

                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        async Task<UsersRequestObject> GetValues(UsersRequestObject requestObject)
        {
            try
            {
                long defaultLongValue = 0;
                int defaultIntValue = 0;


                requestObject = new UsersRequestObject();
                requestObject.aadharCardID.aadhar_card_no = (Int64.TryParse(entryAadharNumber.Value, out defaultLongValue)) ? Convert.ToInt64(entryAadharNumber.Value) : defaultLongValue;
                requestObject.aadharCardID.city_current = entryCurrentCity.Value;
                requestObject.aadharCardID.country_current = entryCurrentCountry.Value;
                requestObject.aadharCardID.email_id = entryEmailID.Value;
                requestObject.aadharCardID.first_name = entryFirstname.Value;
                requestObject.aadharCardID.last_name = entryLastName.Value;
                requestObject.aadharCardID.mobile_no_alternative = sumDigits;
                requestObject.aadharCardID.mobile_no_primary = (Int64.TryParse(entryMobileNumber.Value, out defaultLongValue)) ? Convert.ToInt64(entryMobileNumber.Value) : defaultLongValue;
                requestObject.aadharCardID.pincode_current = (Int32.TryParse(entryCurrentAddressPIN.Value, out defaultIntValue)) ? Convert.ToInt32(entryCurrentAddressPIN.Value) : defaultIntValue;
                requestObject.aadharCardID.pincode_permanent = (Int32.TryParse(entryPermanentAddressPIN.Value, out defaultIntValue)) ? Convert.ToInt32(entryPermanentAddressPIN.Value) : defaultIntValue;
                requestObject.aadharCardID.state_current= entryCurrentState.Value;
                requestObject.aadharCardID.street_address = entryCurrentStreetAddress.Value;
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return requestObject;
        }

        void IsSwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            try
            {
                var owner = (CustomSwitchLabelGroup)sender;
                if (owner == switchAlternateMobileNumbers)
                {
                    //stackSingleNumber.IsVisible = !owner.IsToggled;
                    //stackRangeNumbers.IsVisible = owner.IsToggled;
                    stackAlternateMobileNumbers.IsVisible = owner.IsToggled;
                    //if (!owner.IsToggled)
                    //{
                    //    switchSumNumbers.IsToggled = owner.IsToggled;
                    //    entryStartNumber.Value = string.Empty;
                    //    entryEndNumber.Value = string.Empty;
                    //}
                    //else
                    //{
                    //    entryNumber.Value = string.Empty;
                    //}
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
                    var entryLuckyNumber = new CustomEntryGroup(MainFieldType.EntryField)
                    {
                        Style = (Style)Resources["entryStyles"],
                        CustomPlaceholder = "Enter Number",
                        CustomKeyboard = Keyboard.Numeric
                    };
                    entryLuckyNumber.OnCustomTextChanged += SumDigitsTextChangedEvents;
                    stackAlternateMobileNumbers.Children.Add(entryLuckyNumber);
                }
                else
                {
                    if ((stackAlternateMobileNumbers.Children.Count - 1) > -1)
                    {
                        var child = (CustomEntryGroup)stackAlternateMobileNumbers.Children[stackAlternateMobileNumbers.Children.Count - 1];
                        if (child != null)
                        {
                            stackAlternateMobileNumbers.Children.RemoveAt(stackAlternateMobileNumbers.Children.Count - 1);
                            if (sumDigits.Count > 0)
                            {
                                UpdateAlternateNumbersList();
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
                UpdateAlternateNumbersList();
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public void UpdateAlternateNumbersList()
        {
            try
            {
                var luckyNumsHolders = stackAlternateMobileNumbers.Children;
                sumDigits.Clear();
                foreach (var item in luckyNumsHolders)
                {
                    var owner = (CustomEntryGroup)item;
                    long defaultLongValue = 0;
                    if (Int64.TryParse(owner.Value, out defaultLongValue))
                    {
                        if (!(string.IsNullOrEmpty(owner.Value)))
                        {
                            sumDigits.Add(Convert.ToInt64(owner.Value));
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

        async Task<bool> Validate()
        {
            bool isValidate = true;
            if (string.IsNullOrEmpty(entryFirstname.Value))
            {
                isValidate = false;
                entryFirstname.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryLastName.Value))
            {
                isValidate = false;
                entryLastName.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryMobileNumber.Value))
            {
                isValidate = false;
                entryMobileNumber.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryEmailID.Value))
            {
                isValidate = false;
                entryEmailID.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryAadharNumber.Value))
            {
                isValidate = false;
                entryAadharNumber.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryPermanentAddressPIN.Value))
            {
                isValidate = false;
                entryPermanentAddressPIN.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryCurrentStreetAddress.Value))
            {
                isValidate = false;
                entryCurrentStreetAddress.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryCurrentAddressPIN.Value))
            {
                isValidate = false;
                entryCurrentAddressPIN.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryCurrentCity.Value))
            {
                isValidate = false;
                entryCurrentCity.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryCurrentState.Value))
            {
                isValidate = false;
                entryCurrentState.BorderColor = Color.Maroon;
            }
            if (string.IsNullOrEmpty(entryCurrentCountry.Value))
            {
                isValidate = false;
                entryCurrentCountry.BorderColor = Color.Maroon;
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