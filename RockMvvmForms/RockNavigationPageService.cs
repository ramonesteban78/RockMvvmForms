using System;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public class RockNavigationPageService<TViewModel> : IRockPageService where TViewModel : class, IViewModel
	{
		private readonly IViewFactory _viewFactory;

		public RockNavigationPageService ()
		{
			_viewFactory = DependencyService.Get<IViewFactory> ();
		}

		public Page Create (IViewModel vm) {
			var view = _viewFactory.Resolve<TViewModel> (vm as TViewModel);
			return new NavigationPage (view);
		}
	}
}

