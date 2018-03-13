using System;

using Xamarin.Forms;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace XamarinMVVM
{
    public class MVVMLoginViewModel : INotifyPropertyChanged
    {
        #region for Global Variables
        public string vmUserName { get; set; }
        public string vmUserPassword { get; set; }
        INavigation navigation { get; set; }
        public ICommand btnLoginCommand { get; private set; }
        //public Action btnClickedAction { get; private set; }
        #endregion

        public MVVMLoginViewModel(INavigation Navigation)
        {
            this.navigation = Navigation;
            btnLoginCommand = new Command(async (object obj) => await btnLoginClicked(obj));
            //btnClickedAction = new Action(btnClicked)
        }

        Task<bool> btnLoginClicked(object obj)
        {
            return null;
            //navigation.PushModalAsync();
        }

        void btnClicked(object obj, EventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}

