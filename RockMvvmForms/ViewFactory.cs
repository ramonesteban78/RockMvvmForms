using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RockMvvmForms
{
	public class ViewFactory : IViewFactory
	{
		private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();

		public void Register<TViewModel, TView> () where TViewModel : class, IViewModel where TView : Page
		{
			_map [typeof(TViewModel)] = typeof(TView);
		}

		public Page Resolve<TViewModel> (TViewModel viewModel) where TViewModel : class, IViewModel
		{
			var viewType = _map[typeof(TViewModel)];
			var view = Activator.CreateInstance(viewType) as Page;
			view.BindingContext = viewModel;
			viewModel.Navigation = new Navigator(view.Navigation);

			Task.Run (async () => await viewModel.InitAsync ());

			// Events Appearing and Disappering
			view.Appearing += viewModel.View_Appearing;
			view.Disappearing += viewModel.View_Disappearing;
			
			return view;
		}
			
	}
}

