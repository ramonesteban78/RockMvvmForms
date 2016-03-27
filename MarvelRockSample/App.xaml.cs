using System;
using System.Collections.Generic;
using Xamarin.Forms;
using RockMvvmForms;

namespace MarvelRockSample
{
	public partial class App : Application
	{
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

		private void RegisterServices()
		{
			RockServiceLocator.Current.Register<IMarvelApiService, MarvelApiService> ();
		}

		private void RegisterViews()
		{
			ViewFactory.Register<FirstViewModel, FirstView> ();
			ViewFactory.Register<DetailViewModel, DetailView> ();
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
			
	}
}

