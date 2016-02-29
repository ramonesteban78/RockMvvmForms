using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MarvelRockSample
{
	public class MarvelApiService : IMarvelApiService
	{
		private const string MarvelDns = "https://gateway.marvel.com/v1/public/";
		private const string MarvelCredentials = "?ts=1&apikey=a81593164289ccb83f5f908ead89b163&hash=f413dc2ff725ee0c871141bf2acc4252";

		#region GetCharacters

		public async Task<MarvelApiData<Characters>> GetCharacters (string filter, int limit, int offset)
		{
			var querystring = string.Empty;
			if (!string.IsNullOrEmpty(filter))
				querystring += $"&nameStartsWith={System.Net.WebUtility.UrlEncode(filter)}";
			if (limit > 0)
				querystring += $"&limit={limit.ToString()}";
			if (offset > 0)
				querystring += $"&offset={offset.ToString()}";

			var result = await this.MakeHttpCall<MarvelApiResult<Characters>> (querystring);
			return result.Data;

		}

		#endregion

		#region MakeHttpCall

		private async Task<TOutput> MakeHttpCall<TOutput> (string filter)
		{

			HttpClient client = new HttpClient ();
			HttpContent content = null;

			string url = $"{MarvelDns}characters{MarvelCredentials}{filter}";


			HttpResponseMessage response = new HttpResponseMessage ();
			try {

				response = await client.GetAsync (url);

				string responseText = await response.Content.ReadAsStringAsync ();
				if (response.IsSuccessStatusCode) {
					return JsonConvert.DeserializeObject<TOutput> (responseText);
				} else {
					throw new Exception (string.Format ("Response Statuscode for {0}: {1}", url, response.StatusCode));
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
				throw ex;
			}
		}

		#endregion
	}
}

