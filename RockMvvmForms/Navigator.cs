using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public class Navigator : INavigator
	{
		private readonly IViewFactory _viewFactory;
		private readonly INavigation _navigation;
		public Navigator (INavigation navigation)
		{
			_navigation = navigation;
			_viewFactory = DependencyService.Get<IViewFactory> ();
		}

		public INavigation Navigation { get { return _navigation; } }

		#region Navigation

		public virtual async Task<IViewModel> PopAsync ()
		{
			Page view = await Navigation.PopAsync();
			return view.BindingContext as IViewModel;
		}

		public async Task<IViewModel> PopModalAsync ()
		{
			Page view = await Navigation.PopModalAsync();
			return view.BindingContext as IViewModel;
		}

		public async Task PopToRootAsync ()
		{
			await Navigation.PopToRootAsync();
		}



		public async Task<TViewModel> PushAsync<TViewModel> (TViewModel viewModel) where TViewModel : class, IViewModel
		{
			var view = _viewFactory.Resolve(viewModel);
			await Navigation.PushAsync(view);
			return viewModel;
		}


		public async Task<TViewModel> PushAsync<TViewModel> () where TViewModel : class, IViewModel
		{
			var vm = Activator.CreateInstance (typeof(TViewModel));
			return await PushAsync<TViewModel>(vm as TViewModel);
		}


		public async Task<TViewModel> PushModalAsync<TViewModel> (TViewModel viewModel) where TViewModel : class, IViewModel
		{
			var view = _viewFactory.Resolve(viewModel);
			await Navigation.PushModalAsync(view);
			return viewModel;
		}


		public async Task<TViewModel> PushModalAsync<TViewModel> () where TViewModel : class, IViewModel
		{
			var vm = Activator.CreateInstance (typeof(TViewModel));
			return await PushModalAsync<TViewModel>(vm as TViewModel);
		}

		#endregion

		#region Display Alerts

		public Task DisplayAlert (string title, string message, string okbutton)
		{
			return Application.Current.MainPage?.DisplayAlert (title, message, okbutton);
		}

		public Task<bool> DisplayAlert (string title, string message, string okbutton, string cancelbutton)
		{
			return Application.Current.MainPage?.DisplayAlert (title, message, okbutton, cancelbutton);
		}

		public Task<string> DisplayActionSheet(string title,string cancel,string desctruction,string[] buttons)
		{
			return Application.Current.MainPage?.DisplayActionSheet (title, cancel, desctruction, buttons);
		}

		#endregion


	}
}

