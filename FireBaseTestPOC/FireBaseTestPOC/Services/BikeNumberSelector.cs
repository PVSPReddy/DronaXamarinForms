using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireBaseTestPOC.Services
{
    public class BikeNumberSelector
    {
        public BikeNumberSelector(){}

        public BikeNumberSelector(bool isTesting)
        {
            try
            {
                Console.WriteLine("Hello World!");
                // CheckSumOfDigits(0, 100);
                //CheckSumOfDigits(0, 10000);
                int[] integers = { 2 };
                // int[] integers = {1,2,6};//{1,2,6};//null;// {};
                // CheckSumOfDigits(0, 10000, integers);
                CheckSumOfDigits(1000, 10000, integers, DigitsOrder.ExactAscendingWihAdjacentRepitition);
                // CheckSumOfDigits(1000, 10000, integers, DigitsOrder.ExactAscendingWihAdjacentRepitition);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
        }

        public async Task<List<DigitsListData>> GetNumbersList(int startIndex, int endIndex, int[] sumShouldBeEquals, DigitsOrder digitsOrder = DigitsOrder.Normal, bool isSingleValue = false)
        {
            List<DigitsListData> resultsList = null;
            try
            {
                await CheckSumOfDigits(startIndex, endIndex, sumShouldBeEquals, digitsOrder, isSingleValue);
            }
            catch (Exception ex)
            {
                var msg = ex.Message + "\n" + ex.StackTrace;
                System.Diagnostics.Debug.WriteLine(msg);
            }
            return resultsList;
        }

        async Task<List<DigitsListData>> CheckSumOfDigits(int startIndex, int endIndex, int[] sumShouldBeEquals, DigitsOrder digitsOrder = DigitsOrder.Normal, bool isSingleValue = false)
        {
            List<DigitsListData> resultsList;
            resultsList = CheckSumOfDigits(startIndex, endIndex);
            List<DigitsListData> _resultsList = new List<DigitsListData>();
            foreach (var result in resultsList)
            {
                /*
                if(sumShouldBeEquals != null)
                {
                  _result = (sumShouldBeEquals != null) ? ((sumShouldBeEquals.Count() > 0 ) ? CheckSumOfDigitsEqualsList(result, sumShouldBeEquals)  : null) : null;
                }
                  if(_result != null)
                  {
                      DigitsListData __result = SettingDigitsInOrder(_result, digitsOrder);
                      if(__result != null)
                      {
                          _resultsList.Add(__result);
                      }
                  }
                */
                DigitsListData _result = CheckSumOfDigitsEqualsList(result, sumShouldBeEquals);
                if (_result != null)
                {
                    DigitsListData __result = SettingDigitsInOrder(_result, digitsOrder);
                    if (__result != null)
                    {
                        _resultsList.Add(__result);
                    }
                }
            }
            foreach (var item in _resultsList)
            {
                System.Diagnostics.Debug.WriteLine("\n Number : " + item.Digits.ToString() + " Final Result : " + item.DigitsSum + "\n");
                // Console.WriteLine("\n Number : " + item.Digits.ToString() + " Final Result : " + item.DigitsSum + "\n");
                //Console.WriteLine("Number : " + item.Digits.ToString() + " Final Result : " + item.DigitsSum);
            }
            Console.WriteLine("Count : " + _resultsList.Count.ToString());
            return resultsList;
        }

        #region for after effects : Screening after getting all the digits and their sum
        DigitsListData CheckSumOfDigitsEqualsList(DigitsListData _result, int[] sumShouldBeEquals)
        {
            DigitsListData result = null;//new DigitsListData();
            if (sumShouldBeEquals != null)
            {
                if (sumShouldBeEquals.Length > 0)
                {
                    foreach (var item in sumShouldBeEquals)
                    {
                        if (_result.DigitsSum == item)
                        {
                            result = _result;
                        }
                    }
                }
                else
                {
                    result = _result;
                }
            }
            else
            {
                result = _result;
            }
            return result;
        }

        DigitsListData SettingDigitsInOrder(DigitsListData _result, DigitsOrder digitsOrder)
        {
            DigitsListData result = null;
            if (digitsOrder == DigitsOrder.Normal)
            {
                result = _result;
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
            {
                result = _result;
            }
            return result;
        }
        #endregion

        List<DigitsListData> CheckSumOfDigits(int startIndex, int endIndex)
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

        int[] GetIndividualDigits(int number)
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

        int[] ReverseIndividualDigitsPos(int[] _digits)
        {
            int i = _digits.Length - 1;
            int[] digits = new int[_digits.Length];
            for (int j = 0; j <= i; j++)
            {
                digits[j] = _digits[i - j];
            }
            return digits;
        }

        int AddDigits(int[] digits)
        {
            int response = 0;
            foreach (var item in digits)
            {
                response += (Convert.ToInt32(item));
            }
            //System.Diagnostics.Debug.WriteLine( "\t In progress: " + response + "\t");
            return response;
        }
    }

    public enum DigitsOrder
    {
        Normal, Ascending, ExactAscendingWihAdjacentRepitition, ExactAscending, Descending
    }


    public class DigitsListData
    {
        public int Digits { get; set; }
        public int DigitsSum { get; set; }
    }
}
