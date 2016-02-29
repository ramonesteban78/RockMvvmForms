using System;
using Xamarin.Forms;

namespace RockMvvmForms
{
	public class RockMasterDetailPageService<TViewModelMenu, TViewModelDetail> 
		where TViewModelMenu : class, IViewModel where TViewModelDetail : class, IViewModel
	{
		public MasterDetailPage Create(Page pageMenu, Page pageDetail, string icon = null)
		{
			var master = new MasterDetailPage ();
			master.Master = pageMenu;
			if (icon != null) master.Icon = icon;
			master.Detail = pageDetail;
			return master;
		}
	}
}

