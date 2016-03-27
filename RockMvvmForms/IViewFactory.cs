using System;
using Xamarin.Forms;

namespace RockMvvmForms
{
	[Obsolete("Use the static class ViewFactory. This interface is no longer available",true)]
	public interface IViewFactory
	{
		void Register<TViewModel, TView>() 
			where TViewModel : class, IViewModel 
			where TView : Page;


		Page Resolve<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel;


	}
}

