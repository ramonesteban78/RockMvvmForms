using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MarvelRockSample
{
	public partial class FirstView : ContentPage
	{
		public FirstView ()
		{
			InitializeComponent ();

			listCharacters.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				var vm = this.BindingContext as FirstViewModel;
				vm.CharacterSelection.Execute(e.SelectedItem);
			};
		}
	}
}

