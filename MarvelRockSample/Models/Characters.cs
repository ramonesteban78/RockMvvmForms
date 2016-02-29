using System;
using Newtonsoft.Json;

namespace MarvelRockSample
{
	public class Characters
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("description")]
		public string Description { get; set; }
		[JsonProperty("thumbnail")]
		public ImageUrl Thumbnail { get; set; }

	}
}

