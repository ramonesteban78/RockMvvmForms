using System;
using System.Threading.Tasks;

namespace RockMvvmForms
{
	public interface IViewModel
	{
		INavigator Navigation { get; set; }
		void View_Appearing (object sender, EventArgs e);
		void View_Disappearing (object sender, EventArgs e);
		Task InitAsync();
	}
}

