using System;
using System.Collections.Generic;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public partial class BikeNumberResultsDisplayPage : ContentPage
    {
        public List<DigitsListData> DigitsList { get; set; }
        public BikeNumberResultsDisplayPage(List<DigitsListData> _digitsList)
        {
            DigitsList = _digitsList;
            BindingContext = this;
            InitializeComponent();
        }

        void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            try
            {
                var selectedItem = ((ListView)sender).SelectedItem;
                if(selectedItem == null)
                {
                    return;
                }
                ((ListView)sender).SelectedItem = null;
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
    }
}
