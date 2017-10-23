using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XamarinViews
{
    public partial class PickerDemo : ContentPage
    {
        public static List<string> picker3Source;
        public PickerDemo()
        {
            #region for picker3 with xaml binding
            /*
            picker3Source = new List<Picker3Items>()
            {
                new Picker3Items{item="Apples"},
                 new Picker3Items{item="Almonds"},
                 new Picker3Items{item="Bananas"},
                 new Picker3Items{item="Cherrys"},
                 new Picker3Items{item="Guavas"},
                 new Picker3Items{item="Grapes"},
                 new Picker3Items{item="Lichis"},
                 new Picker3Items{item="Oranges"},
                 new Picker3Items{item="PineApples"},
                 new Picker3Items{item="SugarCanes"}
            };
            */
            #endregion

            InitializeComponent();

            #region for picker1 with c# binding
            Dictionary<string, Color> picker1color = new Dictionary<string, Color>()
            {
                {"Black", Color.Black},
                {"Accent", Color.Accent},
                {"Blue", Color.Blue},
                {"CadetBlue", Color.CadetBlue},
                {"SeaGreen", Color.SeaGreen},
                {"DarkGreen", Color.DarkGreen},
                {"GreenYellow", Color.GreenYellow},
                {"RoyalBlue", Color.RoyalBlue},
                {"IndianRed", Color.IndianRed},
                {"OrangeRed", Color.OrangeRed},
                {"Maroon", Color.Maroon},
                {"Brown", Color.Brown},
                {"BurlyWood", Color.BurlyWood},
                {"DarkGoldenrod", Color.DarkGoldenrod}
            };

            foreach (var item in picker1color)
            {
                picker1.Items.Add(item.Key);
            }

            picker1.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                try
                {
                    var picker = sender as Picker;
                    if (!(picker.SelectedIndex <= -1))
                    {
                        //picker1Selected = picker1color.TryGetValue(picker1.SelectedItem.ToString(), out tempColor);
                        //var valueess = picker1color.GetEnumerator();
                        //var pickerselection = picker1.Items[picker.SelectedIndex];
                        var picker1Option = picker1color.FirstOrDefault(X => X.Key == picker.SelectedItem.ToString()).Value;
                        label1.TextColor = picker1Option;
                    }
                    else
                    {
                        label1.TextColor = Color.Default;
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }

            };
            #endregion

            #region for picker3 with xaml binding
            List<string> picker3Source = new List<string>()
            {
                {"Apples"},{"Almonds"},
                {"Bananas"},
                {"Cherrys"},
                {"Guavas"},{"Grapes"},
                {"Lichis"},
                {"Oranges"},
                {"PineApples"},
                {"SugarCanes"}
            };
            picker3.ItemsSource = picker3Source;
            #endregion
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
                Navigation.PushModalAsync(new Date_TimePickerDemo(), false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }

    public class Picker3Items
    {
        public string item { get; set; }
    }
}
