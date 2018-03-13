using System;

using Xamarin.Forms;

namespace XamarinMVVM
{
    public class MVVMDemoTwoViewModel : BaseViewModel
    {

        private string firstSchemaToCompare;

        public string FirstSchemaToCompare
        {
            get { return firstSchemaToCompare; }
            set
            {
                firstSchemaToCompare = value;
                OnPropertyChanged("FirstSchemaToCompare");
            }
        }

        public MVVMDemoTwoViewModel()
        {
        }
    }
}


/*


https://gist.github.com/almirvuk/cdbbb168089a42f93cace89dbba08aa3
https://github.com/conceptdev/xamarin-forms-samples/blob/master/TodoMvvm/TodoMvvm/ViewModels/BaseViewModel.cs

https://stackoverflow.com/questions/1315621/implementing-inotifypropertychanged-does-a-better-way-exist
public class Data : INotifyPropertyChanged
{
	// boiler-plate
	public event PropertyChangedEventHandler PropertyChanged;
	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChangedEventHandler handler = PropertyChanged;
		if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
	}
	protected bool SetField<T>(ref T field, T value, string propertyName)
	{
		if (EqualityComparer<T>.Default.Equals(field, value)) return false;
		field = value;
		OnPropertyChanged(propertyName);
		return true;
	}

	// props
	private string name;
	public string Name
	{
		get { return name; }
		set { SetField(ref name, value, "Name"); }
	}
}

*/