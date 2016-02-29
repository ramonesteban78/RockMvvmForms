using System;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public interface IViewFactory
	{
		void Register<TViewModel, TView>() 
			where TViewModel : class, IViewModel 
			where TView : Page;


		Page Resolve<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel;


	}
}

