using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelRockSample.Test
{
	public static class Data
	{	
		public static Task<MarvelApiData<Characters>> GetCharacters (string filter)
		{
			return Task.Run (() => {
				
				var result = new MarvelApiData<Characters> () {
					Offset = 0,
					Count = 2,
					Limit = 0,
					Total = 2,
					Results = new List<Characters>() {
						new Characters() {
							Id = 1,
							Name = "Thor",
							Thumbnail = new ImageUrl() {
								Path = "http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350.jpg",
								Extension = "jpg"
							},
							Description = "As the Norse God of thunder and lightning, Thor wields one of the greatest weapons ever made, the enchanted hammer Mjolnir. While others have described Thor as an over-muscled, oafish imbecile, he's quite smart and compassionate.  He's self-assured, and he would never, ever stop fighting for a worthwhile cause."
						},
						new Characters () {
							Id = 2,
							Name = "Goddess of Thunder",
							Thumbnail = new ImageUrl() {
								Path = "http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350.jpg",
								Extension = "jpg"
							},
							Description = "When the Odinson lost his ability to wield Mjolnir, the role of Thor, God of Thunder, was left unoccupied&hellip;albeit for a short time. A mysterious female figure picked up the hammer with ease, changing the inscription to fit her status as the Goddess of Thunder."
						}
					}
				};

				if (!string.IsNullOrEmpty(filter))
					result.Results = result.Results.Where (x => x.Name.ToLower ().Contains (filter.ToLower ())).ToList();

				return result;
			});
		}
	}
}

