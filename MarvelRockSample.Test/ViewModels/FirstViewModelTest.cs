using System;
using NUnit.Framework;
using System.Linq;
using RockMvvmForms;

namespace MarvelRockSample.Test
{
	[TestFixture ()]
	public class FirstViewModelTest
	{
		FirstViewModel vm;

		[SetUp()]
		public void Init()
		{
			RegisterServices ();
			vm = new FirstViewModel ();
		}


		[Test()]
		public async void FirstViewModel_init_async_test ()
		{
			await vm.InitAsync ();

			Assert.IsTrue (string.IsNullOrEmpty(vm.SearchText));
			Assert.IsNotNull (vm.CharacterList);
			Assert.IsTrue (vm.CharacterList.Any ());
		}


		// Register services in the DependencyService Service Locator
		private void RegisterServices()
		{
			RockServiceLocator.Current.Register<IMarvelApiService, MockMarvelApiService>();
		}
	}
}

