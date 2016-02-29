using System;
using Xamarin.Forms;
using MarvelRockSample.iOS;
using UIKit;
using Foundation;

[assembly: Dependency (typeof(OpenWebService))]
namespace MarvelRockSample.iOS
{
	public class OpenWebService : IOpenWebService
	{
		public OpenWebService ()
		{
		}

		#region IOpenWebService implementation

		public void OpenUrl (string url)
		{
			UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
		}

		#endregion
	}
}

