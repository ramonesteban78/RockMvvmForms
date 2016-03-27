using System;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelRockSample.Test
{
	[TestFixture ()]
	public class MarvelApiServiceTest
	{
		IMarvelApiService mock;

		[SetUp()]
		public void Init()
		{
			mock = new MockMarvelApiService ();		
		}

		[Test()]
		public async void Check_Marvel_APi_when_returns_data ()
		{
			var results = await mock.GetCharacters (string.Empty, 0, 0);

			Assert.IsNotNull (results);
			Assert.IsNotNull (results.Results);
			Assert.IsTrue (results.Results.Any());
		}

		[Test()]
		public async void Check_Marvel_APi_when_filter_the_data ()
		{
			var results = await mock.GetCharacters ("thor", 0, 0);

			Assert.IsNotNull (results);
			Assert.IsNotNull (results.Results);
			Assert.IsTrue (results.Results.Any());
		}

		[Test()]
		public async void Check_Marvel_APi_when_no_data_is_returned ()
		{
			var results = await mock.GetCharacters ("spiderman", 0, 0);

			Assert.IsFalse (results.Results.Any());
		}
	}
}

