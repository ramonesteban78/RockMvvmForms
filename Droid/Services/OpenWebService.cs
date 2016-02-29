using System;
using Xamarin.Forms;
using MarvelRockSample.Droid;
using Android.Content;

[assembly: Dependency (typeof(OpenWebService))]
namespace MarvelRockSample.Droid
{
	public class OpenWebService : IOpenWebService
	{
		#region IOpenWebService implementation

		public void OpenUrl (string url)
		{
			var uri = Android.Net.Uri.Parse (url);
			var intent = new Intent (Intent.ActionView, uri); 
			intent.SetFlags (ActivityFlags.NewTask);
			Android.App.Application.Context.StartActivity (intent);
		}

		#endregion
		
	}
}

