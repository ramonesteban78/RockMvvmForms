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

//			listCharacters.ItemTapped += (object sender, ItemTappedEventArgs e) => {
//				var vm = this.BindingContext as FirstViewModel;
//				vm.CharacterSelection.Execute(e.Item);
//
//				listCharacters.SelectedItem = null;
//			};
		}
	}
}

