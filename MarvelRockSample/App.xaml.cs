using System;
using System.Collections.Generic;
using Xamarin.Forms;
using RockMvvmForms;

namespace MarvelRockSample
{
	public partial class App : Application
	{
		private IViewFactory _viewFactory;

		public App ()
		{
			InitializeComponent (); 

			// Register the services in the Forms Service Locator
			RegisterServices ();

			// Register the ViewModels and asociate them to the corresponding Views
			RegisterViews ();

			// The root page of your application
			MainPage = new RockNavigationPageService<FirstViewModel>().Create();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		private void RegisterServices()
		{
			DependencyService.Register<IViewFactory, ViewFactory> ();
			DependencyService.Register<IMarvelApiService, MarvelApiService> ();
		}

		private void RegisterViews()
		{
			_viewFactory = DependencyService.Get<IViewFactory> ();

			_viewFactory.Register<FirstViewModel, FirstView> ();
			_viewFactory.Register<DetailViewModel, DetailView> ();
		}
	}
}

