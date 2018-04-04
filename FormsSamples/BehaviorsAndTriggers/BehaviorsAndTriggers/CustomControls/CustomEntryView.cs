using System;

using Xamarin.Forms;

namespace BehaviorsAndTriggers
{
    public class CustomEntryView : ContentView
    {
        public CustomEntry entry;// { get; set; }
        //public StackLayout stackBorder;// { get; set; }
        public BoxView box;// { get; set; }
        public Label label;// { get; set; }
        public StackLayout holder;// { get; set; }
        public Image image;// { get; set; }
        public StackLayout mainHolder;// { get; set; }

        public CustomEntryView()
        {
            var screenHeight = (App.screenHeight * 1) / 100;
            var screenWidth = (App.screenWidth * 1) / 100;

            entry = new CustomEntry()
            {
                Placeholder="Enter Name Here",
                BackgroundColor = Color.Yellow,
                //HeightRequest = (screenHeight * 7),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            //stackBorder = new StackLayout()
            //{
            //    Children = {entry},
            //    //Padding = new Thickness(1,1,1,1),
            //    BackgroundColor = Color.Transparent,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            box = new BoxView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            label = new Label()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            image = new Image()
            {
                Source = ImageSource.FromFile("AsteriskOneOrange.png"),//ImageSource.FromFile("ExclamationOne.png"),
                IsVisible = false,
                BackgroundColor = Color.Yellow,
                HeightRequest = (screenWidth * 10),
                WidthRequest = (screenWidth * 10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            ////Grid gridHolder = new Grid()
            ////{
            ////    RowDefinitions =
            ////    {
            ////        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
            ////    },
            ////    ColumnDefinitions =
            ////    {
            ////        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            ////        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            ////        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
            ////    }
            ////};
            //holder = new StackLayout()
            //{
            //    Children = { entry, box, label },
            //    //Children = { stackBorder },
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            //mainHolder = new StackLayout()
            //{
            //    Children = { holder, image },
            //    Orientation = StackOrientation.Horizontal,
            //    BackgroundColor = Color.Yellow,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};
            holder = new StackLayout()
            {
                //Children = { entry, image },
                Orientation = StackOrientation.Horizontal,
                //Children = { stackBorder },
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Grid gridHolder = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    //new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                },
                RowSpacing = 0,
                ColumnSpacing = 0,
                Padding = new Thickness(0, 0, 2, 0),
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            gridHolder.Children.Add(entry, 0, 0);
            gridHolder.Children.Add(image, 1, 0);

            mainHolder = new StackLayout()
            {
                Children = { gridHolder },
                //Children = { entry, image },
                //Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(1, 1, 1, 1),
                //Spacing = 0,
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Content = mainHolder;
        }
    }
}

