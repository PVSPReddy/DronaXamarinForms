using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BehaviorsAndTriggers
{
    public class CustomEntryBehaviors : Behavior<CustomEntry>
    {
        CustomEntry localEntry;
        int oldTextLength, newTextLength;
        public CustomEntryBehaviors()
        {

        }

        protected override void OnAttachedTo(CustomEntry entry)
        {
            localEntry = entry;
            entry.TextChanged += EntryTextChangedEvents;
            entry.Completed += TextChangeCompletedEvents;
            entry.Unfocused += TextChangeCompletedEvents;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(CustomEntry entry)
        {
            localEntry = entry;
            entry.TextChanged -= EntryTextChangedEvents;
            entry.Completed -= TextChangeCompletedEvents;
            entry.Unfocused -= TextChangeCompletedEvents;
            base.OnDetachingFrom(entry);
        }

        private void EntryTextChangedEvents(object sender, TextChangedEventArgs e)
        {
            try
            {
                string textEntered = localEntry.Text;
                localEntry.IsValidEntry = false;
                switch (localEntry.CustomEntryType)
                {
                    case "Numeric":
                        NumericSelected();
                        break;
                    case "MobileGeneral":
                        break;
                    case "MobileStructured":
                        MobileStructuredSelected();
                        //localEntry.Text = String.Format("{0:###-###-####}", textEntered.ToCharArray());
                        //localEntry.Text = localEntry;
                        break;
                    case "MobileGeneralWithCode":
                        break;
                    case "MobileStructuredWithCode":
                        break;
                    default:
                        break;
                };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        #region for Numeric entry
        private void NumericSelected()
        {
            try
            {
                if (localEntry.TextColor != Color.Black)
                {
                    localEntry.TextColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region for structured mobile number
        private void MobileStructuredSelected()
        {
            try
            {
                if (localEntry.TextColor != Color.Black)
                {
                    localEntry.TextColor = Color.Black;
                }
                if (localEntry.Text.Length <= 12)
                {
                    if (oldTextLength == 0)
                    {
                        oldTextLength = localEntry.Text.Length;
                    }
                    else
                    {
                        newTextLength = localEntry.Text.Length;
                        if (!(oldTextLength > newTextLength))
                        {
                            if (newTextLength > 12)
                            {
                                localEntry.Text = localEntry.Text.Remove(newTextLength - 1);
                            }
                            else if (newTextLength == 7)
                            {
                                localEntry.Text += "-";
                            }
                            else if (newTextLength == 3)
                            {
                                localEntry.Text += "-";
                            }
                            else
                            {

                            }
                            /*
                            if (newTextLength >= 3 && newTextLength < 7)
                            {
                                if (!(localEntry.Text.Contains("-")))
                                {
                                    localEntry.Text = localEntry.Text.Insert(3, "-");
                                }
                                else
                                {
                                    var values = localEntry.Text.ToCharArray();
                                    if (localEntry.Text.IndexOf('-') == 3)
                                    {
                                        
                                    }
                                    else
                                    {
                                        //var textValue = localEntry.Text;
                                        //localEntry.Text = (localEntry.Text.Remove((textValue.IndexOf('-') - 1), 1));
                                        //if(localEntry.Text.Length >= 3)
                                        //{
                                        //    localEntry.Text = localEntry.Text + "-";
                                        //}
                                    }
                                }
                            }
                            else if (newTextLength >= 7)
                            {
                                if (localEntry.Text.IndexOf('-') != 3)
                                {
                                    localEntry.Text = localEntry.Text.Insert(3, "-");
                                }
                                else if (localEntry.Text.LastIndexOf('-') != 7)
                                {
                                    localEntry.Text = localEntry.Text.Insert(7, "-");
                                }
                                else
                                {

                                }
                            }
                            else
                            {

                            }
                            */
                        }
                        else
                        {
                            #region comment if got any problem
                            /*
                            if (localEntry.Text.Length > 8)
                            {
                                if (localEntry.Text.IndexOf('-') != 3)
                                {
                                    localEntry.Text = localEntry.Text.Insert(3, "-");
                                }
                                else if (localEntry.Text.LastIndexOf('-') != 7)
                                {
                                    localEntry.Text = localEntry.Text.Insert(7, "-");
                                }
                                else
                                {

                                }
                            }
                            */
                            #endregion
                        }
                        oldTextLength = newTextLength;
                    }
                }
                else
                {
                    localEntry.Text = localEntry.Text.Remove(localEntry.Text.Length - 1);
                    //var allTextChars = localEntry.Text.ToCharArray();
                    //if(allTextChars[3] != '-')
                    //{
                    //    localEntry.Text = localEntry.Text.Insert(3, "-");
                    //}
                    //else
                    //{
                    //}
                    //if (allTextChars[7] != '-')
                    //{
                    //    localEntry.Text = localEntry.Text.Insert(7, "-");
                    //}
                    //else
                    //{
                    //}
                    //if(localEntry.Text.Length > 12)
                    //{
                    //    localEntry.Text = localEntry.Text.Remove(localEntry.Text.Length - 1);
                    //}

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion

        #region final validation after the text change completion
        private void TextChangeCompletedEvents(object sender, EventArgs e)
        {
            try
            {
                string textEntered = localEntry.Text;
                switch (localEntry.CustomEntryType)
                {
                    case "Numeric":
                        if (textEntered != null)
                        {
                            var IsValidNumber = Regex.IsMatch(textEntered, "^[0-9]*$");
                            if (!IsValidNumber)
                            {
                                localEntry.TextColor = Color.Red;
                                localEntry.IsValidEntry = false;
                            }
                            else
                            {
                                localEntry.TextColor = Color.Black;
                                localEntry.IsValidEntry = true;
                            }
                        }
                        else
                        {

                        }
                        break;
                    case "MobileGeneral":
                        break;
                    case "MobileStructured":
                        if (textEntered != null)
                        {
                            var IsValidNumber = Regex.IsMatch(textEntered, "^[1-9][0-9]{2}(-)[0-9]{3}(-)[0-9]{4}$");
                            if (!IsValidNumber)
                            {
                                localEntry.TextColor = Color.Red;
                                localEntry.IsValidEntry = false;
                            }
                            else
                            {
                                localEntry.TextColor = Color.Black;
                                localEntry.IsValidEntry = true;
                            }
                        }
                        else
                        {

                        }
                        break;
                    case "MobileGeneralWithCode":
                        break;
                    case "MobileStructuredWithCode":
                        break;
                    default:
                        break;
                };
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        #endregion
    }
}

