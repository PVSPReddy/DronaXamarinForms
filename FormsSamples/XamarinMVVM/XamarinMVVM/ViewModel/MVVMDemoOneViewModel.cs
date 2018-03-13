using System;

using Xamarin.Forms;
using System.ComponentModel;
using System.Globalization;

namespace XamarinMVVM
{
    public class MVVMDemoOneViewModel : INotifyPropertyChanged, IValueConverter
    {


        public MVVMDemoOneViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return null;
        }
    }
}

