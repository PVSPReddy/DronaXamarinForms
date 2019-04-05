using System;

using Xamarin.Forms;

namespace FireBaseTestPOC.CustomControls
{
    public class DynamicViewButtons : ContentView
    {
        StackLayout mainStackLayout;

        public event EventHandler<CustomTapEventArgs> HorizontalButtonClickedEvent;
        public event EventHandler<CustomTapEventArgs> VerticalButtonClickedEvent;

        public DynamicViewButtons()
        {
            SetUpLayout();
        }

        void SetUpLayout()
        {
            mainStackLayout = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            ScrollView mainScrollView = new ScrollView()
            {
                Content = mainStackLayout,
                Orientation = ScrollOrientation.Both,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Button horizontalAddButton = new Button()
            {
                Text = "+",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            horizontalAddButton.Clicked += HorizontalButtonClickedEvents;
            Button horizontalDeleteButton = new Button()
            {
                Text = "-",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            horizontalDeleteButton.Clicked += HorizontalButtonClickedEvents;
            StackLayout horizontalStackLayout = new StackLayout()
            {
                Children = { horizontalAddButton, horizontalDeleteButton },
                BackgroundColor = Color.Green,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Button verticalAddButton = new Button()
            {
                Text = "+",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            verticalAddButton.Clicked += VerticalButtonClickedEvents;
            Button verticalDeleteButton = new Button()
            {
                Text = "-",
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            verticalDeleteButton.Clicked += VerticalButtonClickedEvents;
            StackLayout verticalStackLayout = new StackLayout()
            {
                Children = { verticalAddButton, verticalDeleteButton },
                BackgroundColor = Color.Maroon,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //StackLayout stackLayout = new StackLayout()
            //{
            //    Children = { verticalStackLayout },
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            Grid mainGrid = new Grid()
            {
                RowDefinitions = {
                    //new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height = GridLength.Auto },
                    new RowDefinition{ Height = GridLength.Auto }
                },
                ColumnDefinitions = {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = GridLength.Auto },
                    //new ColumnDefinition{ Width = GridLength.Auto }
                },
                Padding = new Thickness(20,20,20,20),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            mainGrid.Children.Add(mainScrollView, 0, 0);
            mainGrid.Children.Add(horizontalStackLayout, 0, 2, 1, 2);
            mainGrid.Children.Add(verticalStackLayout, 1, 0);
            //mainGrid.Children.Add(horizontalStackLayout, 1, 0);
            //mainGrid.Children.Add(verticalStackLayout, 0, 2, 1, 2);
            Content = mainGrid;
        }

        private void HorizontalButtonClickedEvents(object sender, EventArgs e)
        {
            try
            {
                EventHandler<CustomTapEventArgs> handler = HorizontalButtonClickedEvent;
                CustomTapEventArgs customTapEventArgs = new CustomTapEventArgs();
                var owner = (Button)sender;
                if(owner.Text == "+")
                {
                    customTapEventArgs.ButtonOption = ButtonOption.Add;
                }
                else if(owner.Text == "-")
                {
                    customTapEventArgs.ButtonOption = ButtonOption.Delete;
                }
                else
                {
                }
                if (handler != null)
                {
                    handler(sender, customTapEventArgs);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        private void VerticalButtonClickedEvents(object sender, EventArgs e)
        {
            try
            {
                EventHandler<CustomTapEventArgs> handler = VerticalButtonClickedEvent;
                CustomTapEventArgs customTapEventArgs = new CustomTapEventArgs();
                var owner = (Button)sender;
                if (owner.Text == "+")
                {
                    customTapEventArgs.ButtonOption = ButtonOption.Add;
                }
                else if (owner.Text == "-")
                {
                    customTapEventArgs.ButtonOption = ButtonOption.Delete;
                }
                else
                {
                }
                if (handler != null)
                {
                    handler(sender, customTapEventArgs);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        public void AddChildren(View view)
        {
            mainStackLayout.Children.Add(view);
        }

        public void RemoveChildren(View view)
        {
            try
            {
                mainStackLayout.Children.Remove(view);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }

        public void ClearAllChildren()
        {
            try
            {
                mainStackLayout.Children.Clear();
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
            }
        }
    }

    public class CustomTapEventArgs : EventArgs
    {
        public ButtonOption ButtonOption { get; set; }
    }
    public enum ButtonOption
    {
        Add, Delete
    }

}

