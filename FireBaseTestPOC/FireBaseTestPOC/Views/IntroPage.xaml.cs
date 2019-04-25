using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireBaseTestPOC.Services;
using Xamarin.Forms;

namespace FireBaseTestPOC.Views
{
    public enum DigitsOrder
    {
        Normal, Ascending, ExactAscendingWihAdjacentRepitition, ExactAscending, Descending
    }

    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
        }

        void DoneButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                //Navigation.PushModalAsync(new DynamicGridPage());
                //DependencyService.Get<IFireBaseService>().GetAllImageUrlsFromServer();
                //CheckSumOfDigits(0, 10000);
                int[] integers = { 1, 2, 6 };
                //CheckSumOfDigits(0, 100, integers, DigitsOrder.Ascending);
                CheckSumOfDigits(0, 10000, integers, DigitsOrder.ExactAscendingWihAdjacentRepitition);
            }
            catch(Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public List<DigitsListData> CheckSumOfDigits(int startIndex, int endIndex, int[] sumShouldBeEquals, DigitsOrder digitsOrder = DigitsOrder.Normal, bool isSingleValue = false)
        {
            popUpHolder.IsVisible = true;
            List<DigitsListData> resultsList;
            resultsList = CheckSumOfDigits(startIndex, endIndex);
            List<DigitsListData> _resultsList = new List<DigitsListData>();
            foreach (var result in resultsList)
            {
                DigitsListData _result = CheckSumOfDigitsEqualsList(result, sumShouldBeEquals);
                if(_result != null)
                {
                    DigitsListData __result = SettingDigitsInOrder(_result, digitsOrder);
                    if(__result != null)
                    {
                        _resultsList.Add(__result);
                    }
                }
            }
            foreach (var item in _resultsList)
            {
                System.Diagnostics.Debug.WriteLine("\n Number : " + item.Digits.ToString() + " Final Result : " + item.DigitsSum + "\n");
            }
            popUpHolder.IsVisible = false;
            return resultsList;
        }

        #region for after effects : Screening after getting all the digits and their sum
        public DigitsListData CheckSumOfDigitsEqualsList(DigitsListData _result, int[] sumShouldBeEquals)
        {
            DigitsListData result = null;//new DigitsListData();
            if (sumShouldBeEquals != null)
            {
                if (sumShouldBeEquals.Length > 0)
                {
                    foreach (var item in sumShouldBeEquals)
                    {
                        if(_result.DigitsSum == item)
                        {
                            result = _result;
                        }
                    }
                }
            }
            return result;
        }

        public DigitsListData SettingDigitsInOrder(DigitsListData _result, DigitsOrder digitsOrder)
        {
            DigitsListData result = null;
            if (digitsOrder == DigitsOrder.Normal)
            {
            }
            else if (digitsOrder == DigitsOrder.Ascending)
            {
                var itemDigits = GetIndividualDigits(_result.Digits);
                bool isValid = false;
                for (int i = 0; i < itemDigits.Length; i++)
                {
                    if (i + 1 <= itemDigits.Length - 1)
                    {
                        if (itemDigits[i] < itemDigits[i + 1])
                        {
                            isValid = true;
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                }
                if (isValid)
                {
                    result = _result;
                }
            }
            else if (digitsOrder == DigitsOrder.ExactAscending)
            {
                var itemDigits = GetIndividualDigits(_result.Digits);
                bool isValid = true;
                for (int i = 0; i < itemDigits.Length; i++)
                {
                    if (i + 1 <= itemDigits.Length - 1)
                    {
                        if (itemDigits[i] < itemDigits[i + 1])
                        {
                            //isValid = true;
                        }
                        else
                        {
                            isValid = false;
                        }
                    }
                }
                if (isValid)
                {
                    result = _result;
                }
            }
            else if (digitsOrder == DigitsOrder.ExactAscendingWihAdjacentRepitition)
            {
                var itemDigits = GetIndividualDigits(_result.Digits);
                bool isValid = true;
                for (int i = 0; i < itemDigits.Length; i++)
                {
                    if (i + 1 <= itemDigits.Length - 1)
                    {
                        if (itemDigits[i] > itemDigits[i + 1])
                        {
                            isValid = false;
                        }
                        else
                        {
                            //isValid = true;
                        }
                    }
                }
                if (isValid)
                {
                    result = _result;
                }
            }
            else
            { }
            return result;
        }
        #endregion

        public List<DigitsListData> CheckSumOfDigits(int startIndex, int endIndex)
        {
            List<DigitsListData> resultsList = new List<DigitsListData>();
            for (int i = startIndex; i < endIndex; i++)
            {
                int[] chars = GetIndividualDigits(i);
                int result = AddDigits(chars);
                while ((result.ToString()).Length > 1)
                {
                    int[] resultChar = GetIndividualDigits(result);
                    result = AddDigits(resultChar);
                }
                resultsList.Add(new DigitsListData { Digits = i, DigitsSum = result });
                //System.Diagnostics.Debug.WriteLine ("\n Number : " + i.ToString () + " Final Result : " + result + "\n");
            }
            return resultsList;
        }

        public int[] GetIndividualDigits(int number)
        {
            int[] digits = new int[number.ToString().Length];
            int i = 0;
            int numberLength = number.ToString().Length;
            while (numberLength > i)
            {
                digits[i] = number % 10;
                var _number = number.ToString().Remove((number.ToString().Length) - 1);
                number = (string.IsNullOrEmpty(_number)) ? 0 : Convert.ToInt32(_number);
                i++;
            }
            return ReverseIndividualDigitsPos(digits);
        }

        public int[] ReverseIndividualDigitsPos(int[] _digits)
        {
            int i = _digits.Length - 1;
            int[] digits = new int[_digits.Length];
            for (int j = 0; j <= i; j++)
            {
                digits[j] = _digits[i - j];
            }
            return digits;
        }

        public int AddDigits(int[] digits)
        {
            int response = 0;
            foreach(var item in digits)
            {
                response += (Convert.ToInt32(item));
            }
            //System.Diagnostics.Debug.WriteLine( "\t In progress: " + response + "\t");
            return response;
        }
	}

    public class DigitsListData
    {
        public int Digits { get; set; }
        public int DigitsSum { get; set; }
    }
}