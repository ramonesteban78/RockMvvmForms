using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using UXDivers.Artina.Player.iOS;
using UXDivers.Artina.Player;

namespace MarvelRockSample.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif


			#if DESIGN
			LoadApplication (Player.CreateApplication(new Config("Good Gorilla")));
			#else
			LoadApplication (new App ());
			#endif


			return base.FinishedLaunching (app, options);
		}
	}
}

