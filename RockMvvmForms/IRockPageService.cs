using System;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public interface IRockPageService
	{
		Page Create(IViewModel vm);
	}
}

