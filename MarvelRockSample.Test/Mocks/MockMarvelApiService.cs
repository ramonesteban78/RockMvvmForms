using System;
using System.Threading.Tasks;

namespace MarvelRockSample.Test
{
	public class MockMarvelApiService : IMarvelApiService
	{
		#region IMarvelApiService implementation
		public Task<MarvelApiData<Characters>> GetCharacters (string filter = null, int limit = 0, int offset = 0)
		{
			return Data.GetCharacters (filter);
		}
		#endregion
		
	}
}

