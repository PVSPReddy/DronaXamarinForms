using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinMVVM
{
    public class BaseContentPage : ContentPage
    {
        public AbsoluteLayout contentLayout;
        public ActivityIndicator aiLoader;
        public StackLayout pageLoading, stackAlertHolder, pageControlsStackLayout;
        Label lblErrorTitle, lblErrorMsg;

        public static int screenHeight, screenWidth;

        public BaseContentPage()
        {
            this.BackgroundColor = Color.Transparent;

            aiLoader = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Color = Color.White,
                IsEnabled = true,
                IsVisible = true,
                IsRunning = true,
            };

            contentLayout = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            var pageLoadingChild = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent,
                IsVisible = true,
                Children = { aiLoader }
            };
            pageLoading = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromRgba(0, 0, 0, 0.4),
                IsVisible = false,
                Children = { pageLoadingChild }
            };
            lblErrorTitle = new Label()
            {
                Text = "Alert",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),//13
                MinimumHeightRequest = (screenHeight * 20) / 100,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromHex("#000000")
            };
            lblErrorMsg = new Label()
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),//15
                MinimumHeightRequest = (screenHeight * 20) / 100,
                TextColor = Color.FromHex("#000000")
            };
            Button btnAcceptMSG = new Button()
            {
                Text = "OK",
            };
            btnAcceptMSG.Clicked += CloseMsgDisplay;

            Grid gridErrorMsgHolder = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto},
                    new RowDefinition{ Height = GridLength.Auto}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{ Width=new GridLength(1, GridUnitType.Star)},
                },
                RowSpacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            gridErrorMsgHolder.Children.Add(lblErrorTitle, 0, 4, 0, 1);
            gridErrorMsgHolder.Children.Add(lblErrorMsg, 0, 4, 1, 2);

            Frame frameAlertBackground = new Frame()
            {
                HasShadow = false,
                BindingContext = gridErrorMsgHolder,
                BackgroundColor = Color.White,
                OutlineColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            Grid gridAlertHolder = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star)},
                },
                RowSpacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            gridAlertHolder.Children.Add(frameAlertBackground, 0, 0);
            gridAlertHolder.Children.Add(gridErrorMsgHolder, 0, 0);

            stackAlertHolder = new StackLayout()
            {
                Children = { gridAlertHolder },
                IsVisible = false,
            };

            if (Device.OS == TargetPlatform.iOS)
            {
                gridAlertHolder.WidthRequest = (screenWidth * 70) / 100;
                gridAlertHolder.Padding = new Thickness((screenWidth * 5) / 100, 0, (screenWidth * 5) / 100, 0);
                frameAlertBackground.CornerRadius = 10;
                frameAlertBackground.BackgroundColor = Color.FromHex("#F9F9F9");
                frameAlertBackground.WidthRequest = (screenWidth * 70) / 100;
                gridErrorMsgHolder.WidthRequest = (screenWidth * 70) / 100;
                gridErrorMsgHolder.Padding = new Thickness((screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 0) / 100);
                lblErrorTitle.HorizontalTextAlignment = TextAlignment.Center;
                lblErrorTitle.VerticalTextAlignment = TextAlignment.Center;
                lblErrorTitle.HorizontalOptions = LayoutOptions.CenterAndExpand;
                lblErrorTitle.VerticalOptions = LayoutOptions.CenterAndExpand;
                lblErrorMsg.HorizontalTextAlignment = TextAlignment.Center;
                lblErrorMsg.VerticalTextAlignment = TextAlignment.Center;
                lblErrorMsg.HorizontalOptions = LayoutOptions.FillAndExpand;
                lblErrorMsg.VerticalOptions = LayoutOptions.CenterAndExpand;
                stackAlertHolder.BackgroundColor = Color.FromHex("#25000000");
                btnAcceptMSG.HeightRequest = (screenHeight * 6) / 100;
                btnAcceptMSG.BackgroundColor = Color.Transparent;
                btnAcceptMSG.TextColor = Color.FromHex("#1316FF");
                btnAcceptMSG.HorizontalOptions = LayoutOptions.FillAndExpand;
                btnAcceptMSG.VerticalOptions = LayoutOptions.CenterAndExpand;
                gridErrorMsgHolder.Children.Add(btnAcceptMSG, 0, 4, 2, 3);
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                gridAlertHolder.WidthRequest = (screenWidth * 90) / 100;
                gridAlertHolder.Padding = new Thickness((screenWidth * 3) / 100, 0, (screenWidth * 3) / 100, 0);
                frameAlertBackground.CornerRadius = 3;
                frameAlertBackground.BackgroundColor = Color.FromHex("#F0F0F0");
                frameAlertBackground.WidthRequest = (screenWidth * 90) / 100;
                gridErrorMsgHolder.WidthRequest = (screenWidth * 90) / 100;
                gridErrorMsgHolder.Padding = new Thickness((screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 5) / 100, (screenWidth * 2) / 100);
                lblErrorTitle.HorizontalTextAlignment = TextAlignment.Start;
                lblErrorTitle.VerticalTextAlignment = TextAlignment.Center;
                lblErrorTitle.HorizontalOptions = LayoutOptions.StartAndExpand;
                lblErrorTitle.VerticalOptions = LayoutOptions.CenterAndExpand;
                lblErrorMsg.HorizontalTextAlignment = TextAlignment.Start;
                lblErrorMsg.VerticalTextAlignment = TextAlignment.Center;
                lblErrorMsg.HorizontalOptions = LayoutOptions.StartAndExpand;
                lblErrorMsg.VerticalOptions = LayoutOptions.CenterAndExpand;
                stackAlertHolder.BackgroundColor = Color.FromHex("#30000000");
                btnAcceptMSG.HeightRequest = (screenHeight * 8) / 100;
                btnAcceptMSG.BackgroundColor = Color.FromHex("#E1E1E1");
                btnAcceptMSG.TextColor = Color.FromHex("#008F7D");
                btnAcceptMSG.HorizontalOptions = LayoutOptions.End;
                btnAcceptMSG.VerticalOptions = LayoutOptions.Center;
                gridErrorMsgHolder.Children.Add(btnAcceptMSG, 3, 4, 2, 3);
            }
            else
            {
            }
            pageControlsStackLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
                Spacing = 0
            };
            AbsoluteLayout.SetLayoutFlags(pageControlsStackLayout, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(pageControlsStackLayout, new Rectangle(0, 0, 1, 1));
            contentLayout.Children.Add(pageControlsStackLayout);

            AbsoluteLayout.SetLayoutFlags(stackAlertHolder, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(stackAlertHolder, new Rectangle(0.5, 0.5, 1, 1));
            contentLayout.Children.Add(stackAlertHolder);

            AbsoluteLayout.SetLayoutFlags(pageLoading, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(pageLoading, new Rectangle(0.5, 0.5, 1, 1));
            contentLayout.Children.Add(pageLoading);
            Content = contentLayout;
        }

        public void DisplayCustomAlert(string Title, FormattedString message)
        {
            lblErrorTitle.Text = Title;
            lblErrorMsg.FormattedText = message;
            stackAlertHolder.IsVisible = true;
        }

        void CloseMsgDisplay(object sender, EventArgs e)
        {
            stackAlertHolder.IsVisible = false;
        }

        public void DisplayThisAlert(string Title, string message)
        {
            DisplayAlert(Title, message, "OK");
        }

        public void DisplayThisAlert(string message)
        {
            DisplayAlert("Alert", message, "OK");
        }

        public async Task<bool> DisplayThisChoice(string Title, string message)
        {
            var response = await DisplayAlert(Title, message, "OK", "Cancel");
            return response;
        }

        public async Task<bool> DisplayThisChoice(string message)
        {
            var response = await DisplayAlert("Alert", message, "OK", "Cancel");
            return response;
        }
    }
}