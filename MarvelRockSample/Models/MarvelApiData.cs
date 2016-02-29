using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarvelRockSample
{
	public class MarvelApiData<TResult>
	{
		[JsonProperty("offset")]
		public int Offset { get; set; }
		[JsonProperty("limit")]
		public int Limit { get; set; }
		[JsonProperty("total")]
		public int Total { get; set; }
		[JsonProperty("count")]
		public int Count { get; set; }
		[JsonProperty("results")]
		public List<TResult> Results { get; set; }
	}
}

