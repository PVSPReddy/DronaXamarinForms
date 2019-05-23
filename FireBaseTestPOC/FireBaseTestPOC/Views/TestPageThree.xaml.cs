using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FireBaseTestPOC.CustomControls;
using FireBaseTestPOC.Models.FirebaseModels;
using FireBaseTestPOC.RESTServices;
using FireBaseTestPOC.RESTServices.BusinessLayer;
using FireBaseTestPOC.RESTServices.InterfaceLayer;
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
                                using (IFireBaseWebServices fireBaseWebServices = new FireBaseWebServices())
                                {
                                    var reponse = await fireBaseWebServices.POST_UserDataToDatabase(requestObject);
                                }
                                //if (requestObject.aadharCardID != null)
                                //{
                                //    using (IFireBaseWebServices fireBaseWebServices = new FireBaseWebServices())
                                //    {
                                //        var reponse = fireBaseWebServices.PATCH_UserDataToDatabase(requestObject);
                                //    }
                                //}
                            }
                        }
                        else
                        {
                            await DisplayAlert("Alert", "Some fields are not valid", "OK");
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

                requestObject.aadhar_card_no = (Int64.TryParse(entryAadharNumber.Value, out defaultLongValue)) ? Convert.ToInt64(entryAadharNumber.Value) : defaultLongValue;
                requestObject.city_current = entryCurrentCity.Value;
                requestObject.country_current = entryCurrentCountry.Value;
                requestObject.email_id = entryEmailID.Value;
                requestObject.first_name = entryFirstname.Value;
                requestObject.last_name = entryLastName.Value;
                requestObject.mobile_no_alternative = sumDigits;
                requestObject.mobile_no_primary = (Int64.TryParse(entryMobileNumber.Value, out defaultLongValue)) ? Convert.ToInt64(entryMobileNumber.Value) : defaultLongValue;
                requestObject.pincode_current = (Int32.TryParse(entryCurrentAddressPIN.Value, out defaultIntValue)) ? Convert.ToInt32(entryCurrentAddressPIN.Value) : defaultIntValue;
                requestObject.pincode_permanent = (Int32.TryParse(entryPermanentAddressPIN.Value, out defaultIntValue)) ? Convert.ToInt32(entryPermanentAddressPIN.Value) : defaultIntValue;
                requestObject.state_current = entryCurrentState.Value;
                requestObject.street_address = entryCurrentStreetAddress.Value;

                //requestObject.aadharCardID = new AAdharCardID();
                //requestObject.aadharCardID.aadhar_card_no = (Int64.TryParse(entryAadharNumber.Value, out defaultLongValue)) ? Convert.ToInt64(entryAadharNumber.Value) : defaultLongValue;
                //requestObject.aadharCardID.city_current = entryCurrentCity.Value;
                //requestObject.aadharCardID.country_current = entryCurrentCountry.Value;
                //requestObject.aadharCardID.email_id = entryEmailID.Value;
                //requestObject.aadharCardID.first_name = entryFirstname.Value;
                //requestObject.aadharCardID.last_name = entryLastName.Value;
                //requestObject.aadharCardID.mobile_no_alternative = sumDigits;
                //requestObject.aadharCardID.mobile_no_primary = (Int64.TryParse(entryMobileNumber.Value, out defaultLongValue)) ? Convert.ToInt64(entryMobileNumber.Value) : defaultLongValue;
                //requestObject.aadharCardID.pincode_current = (Int32.TryParse(entryCurrentAddressPIN.Value, out defaultIntValue)) ? Convert.ToInt32(entryCurrentAddressPIN.Value) : defaultIntValue;
                //requestObject.aadharCardID.pincode_permanent = (Int32.TryParse(entryPermanentAddressPIN.Value, out defaultIntValue)) ? Convert.ToInt32(entryPermanentAddressPIN.Value) : defaultIntValue;
                //requestObject.aadharCardID.state_current= entryCurrentState.Value;
                //requestObject.aadharCardID.street_address = entryCurrentStreetAddress.Value;

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
                    stackAddRemoveButton.IsVisible = owner.IsToggled;
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
            if (!(await entryFirstname.Validate()))
            {
                entryFirstname.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryLastName.Validate()))
            {
                entryLastName.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryMobileNumber.Validate()))
            {
                entryMobileNumber.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryEmailID.Validate()))
            {
                entryEmailID.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryAadharNumber.Validate()))
            {
                entryAadharNumber.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryPermanentAddressPIN.Validate()))
            {
                entryPermanentAddressPIN.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryCurrentStreetAddress.Validate()))
            {
                entryCurrentStreetAddress.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryCurrentAddressPIN.Validate()))
            {
                entryCurrentAddressPIN.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryCurrentCity.Validate()))
            {
                entryCurrentCity.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryCurrentState.Validate()))
            {
                entryCurrentState.BorderColor = Color.Maroon;
                return false;
            }
            else if (!(await entryCurrentCountry.Validate()))
            {
                entryCurrentCountry.BorderColor = Color.Maroon;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}