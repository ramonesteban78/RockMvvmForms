using System;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public class RockContentPageService<TViewModel> : IRockPageService where TViewModel : class, IViewModel
	{
		public Page Create (IViewModel vm) {
			var view = ViewFactory.Resolve<TViewModel> (vm as TViewModel);
			return view as ContentPage;
		}
			
		public Page Create () {
			var vm = Activator.CreateInstance<TViewModel> ();
			var view = ViewFactory.Resolve<TViewModel> (vm as TViewModel);
			return view as ContentPage;
		}
	}
}

