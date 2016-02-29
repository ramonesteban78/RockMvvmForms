using System;
using System.ComponentModel;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public abstract class ViewModelBase : INotifyPropertyChanged, IViewModel
	{

		public ViewModelBase ()
		{
			

		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, 
					new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		public INavigator Navigation { get; set; }


		#region IsBusy

		private bool _IsBusy;

		public bool IsBusy {
			get {
				return _IsBusy;
			}
			set {
				_IsBusy = value;
				OnPropertyChanged ("IsBusy");
			}
		}

		#endregion

		#region Title

		private string _Title;

		public string Title {
			get {
				return _Title;
			}
			set {

				_Title = value;
				OnPropertyChanged ("Title");
			}
		}

		#endregion

		public virtual void View_Appearing (object sender, EventArgs e)
		{
			
		}

		public virtual void View_Disappearing (object sender, EventArgs e)
		{
			
		}
	}
}

