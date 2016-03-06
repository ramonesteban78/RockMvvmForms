using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MarvelRockSample.UITests
{
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

		[Test]
		public void DotNetMalagaTest ()
		{
			app.ScrollDownTo("Agent Brand");
			app.Screenshot("Scrolled to Agent Brand");
			app.Tap(x => x.Marked("Agent Brand"));
			app.Screenshot("Tapped on view UILabel with Text: 'Agent Brand'");
			app.Tap(x => x.Text("Marvel Rocks"));
			app.Screenshot("Tapped on view UILabel with Text: 'Marvel Rocks'");
			app.Tap(x => x.Class("UISearchBarTextField"));
			app.Screenshot("Tapped on view UISearchBarTextField");
			app.EnterText(x => x.Class("UISearchBarTextField"), "Thor");
			app.Screenshot("Entered 'Thor' into view UISearchBarTextField");

			app.PressEnter ();

			app.Tap(x => x.Class("Xamarin_Forms_Platform_iOS_Platform_DefaultRenderer").Index(22));
			app.Screenshot("Tapped on view Xamarin_Forms_Platform_iOS_Platform_DefaultRenderer");
			app.Tap(x => x.Text("Marvel Rocks"));
			app.Screenshot("Tapped on view UILabel with Text: 'Marvel Rocks'");

			Assert.IsTrue (true);
		}

		[Test]
		public void PorlaTarde ()
		{
			app.Tap(x => x.Marked("A-Bomb (HAS)"));
			app.Screenshot("Tapped on view UILabel with Text: 'A-Bomb (HAS)'");
			app.Tap(x => x.Text("Marvel Rocks"));
			app.Screenshot("Tapped on view UILabel with Text: 'Marvel Rocks'");
			app.Tap(x => x.Class("UISearchBarTextField"));
			app.Screenshot("Tapped on view UISearchBarTextField");
			app.EnterText(x => x.Class("UISearchBarTextField"), "Thor");
			app.Screenshot("Entered 'Thor' into view UISearchBarTextField");

			app.PressEnter ();

			app.Tap(x => x.Class("Xamarin_Forms_Platform_iOS_LabelRenderer"));
			app.Screenshot("Tapped on view Xamarin_Forms_Platform_iOS_LabelRenderer");
			app.Tap(x => x.Text("Marvel Rocks"));
			app.Screenshot("Tapped on view UILabel with Text: 'Marvel Rocks'");

			Assert.IsTrue (true);
		}
	}
}

