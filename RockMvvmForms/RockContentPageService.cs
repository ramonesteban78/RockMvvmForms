using System;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public class RockContentPageService<TViewModel> : IRockPageService where TViewModel : class, IViewModel
	{
		private readonly IViewFactory _viewFactory;

		public RockContentPageService ()
		{
			_viewFactory = DependencyService.Get<IViewFactory> ();
		}

		public Page Create (IViewModel vm) {
			var view = _viewFactory.Resolve<TViewModel> (vm as TViewModel);
			return view as ContentPage;
		}
	}
}

