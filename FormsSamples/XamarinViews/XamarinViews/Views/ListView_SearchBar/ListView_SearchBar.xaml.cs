using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Runtime.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinViews
{
    public partial class ListView_SearchBar : ContentPage
    {
        List<EmployeeDetails> empDetails;
        public ListView_SearchBar()
        {
            InitializeComponent();
            empDetails = new List<EmployeeDetails>()
            {
                new EmployeeDetails() { empName = "Sivaprasad Reddy", empDesignation = "Xamarin developer", empExperienc = "1.5"},
                new EmployeeDetails() { empName = "Alok Das", empDesignation = "SEO", empExperienc="1.7"},
                new EmployeeDetails() { empName = "Venkateswarulu Nagella", empDesignation = "Xamarin developer", empExperienc="3"},
                new EmployeeDetails() { empName = "Bala Krishna", empDesignation = ".Net developer", empExperienc="5"},
                new EmployeeDetails() { empName = "Prasad", empDesignation = ".Net developer", empExperienc="3.5"},
                new EmployeeDetails() { empName = "Sivaprasad Reddy", empDesignation = "Xamarin developer", empExperienc="1.5"},
                new EmployeeDetails() { empName = "Sivaprasad Reddy", empDesignation = "Xamarin developer", empExperienc="1.5"},
                new EmployeeDetails() { empName = "Sivaprasad Reddy", empDesignation = "Xamarin developer", empExperienc="1.5"},
                new EmployeeDetails() { empName = "Sivaprasad Reddy", empDesignation = "Xamarin developer", empExperienc="1.5"},
                new EmployeeDetails() { empName = "Sivaprasad Reddy", empDesignation = "Xamarin developer", empExperienc="1.5"},
                new EmployeeDetails() { empName = "Sivaprasad Reddy", empDesignation = "Xamarin developer", empExperienc="1.5"}

            };
            lvListView.ItemsSource = empDetails;
            lvListView.ItemSelected += async (object sender, SelectedItemChangedEventArgs e) =>
            {
                var lvSelectedItem = ((ListView)sender).SelectedItem as EmployeeDetails;
                try
                {
                    if (lvSelectedItem == null)
                    {
                        return;
                    }
                    else
                    {
                        await DisplayAlert("SelectedItem", "EmployeeName: " + lvSelectedItem.empName + " \n" + "Working as: " + lvSelectedItem.empDesignation + " \n" + "Experience: " + lvSelectedItem.empExperienc + " \n", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
                ((ListView)sender).SelectedItem = null;
            };
            lvSearchBar.TextChanged += async (object sender, TextChangedEventArgs e) =>
            {
                lvListView.BeginRefresh();
                try
                {
                    if (!string.IsNullOrEmpty(lvSearchBar.Text))
                    {
                        var newSource = empDetails.Where(X => X.empName.Contains(lvSearchBar.Text) || X.empDesignation.Contains(lvSearchBar.Text) || X.empExperienc.Contains(lvSearchBar.Text)).ToList();
                        await Task.Delay(1000);
                        lvListView.ItemsSource = newSource;
                    }
                    else
                    {
                        lvListView.ItemsSource = empDetails;
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
                lvListView.EndRefresh();
            };
        }

        void backBtnClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync(false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        void startPageBtnClicked(object sender, EventArgs e)
        {
            try
            {
                App.Current.MainPage = new LabelDemo();
                //Navigation.PushModalAsync(new LabelDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }


        void nextBtnClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new WebViewDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }

    public class EmployeeDetails
    {

        public string empName { get; set; }

        public string empDesignation { get; set; }

        public string empExperienc { get; set; }

    }
}
