using System;
using System.Threading.Tasks;

namespace MarvelRockSample
{
	public interface IMarvelApiService
	{
		Task<MarvelApiData<Characters>> GetCharacters (string filter = null, int limit = 0, int offset = 0);
	}
}

