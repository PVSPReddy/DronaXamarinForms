using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinViews
{
    public partial class EntryDemo : ContentPage
    {
        public EntryDemo()
        {
            InitializeComponent();

            entry4.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    long i = -1;
                    var entry = sender as Entry;
                    if (!(Int64.TryParse(entry.Text, out i)))
                    {
                        entry4.TextColor = Color.Red;
                    }
                    else
                    {
                        entry4.TextColor = Color.Black;
                        if (entry.Text.Length <= 10)
                        {
                            entry4.TextColor = Color.Black;
                        }
                        else
                        {
                            entry4.TextColor = Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            };

            entry3.TextChanged += (object sender, TextChangedEventArgs e) =>
            {
                try
                {
                    long i = -1;
                    var entry = sender as Entry;
                    if (!(Int64.TryParse(entry.Text, out i)))
                    {
                        entry3.TextColor = Color.Red;
                    }
                    else
                    {
                        entry3.TextColor = Color.Black;
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
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
                Navigation.PushModalAsync(new EditorDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
