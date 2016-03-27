using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using RockMvvmForms;

namespace MarvelRockSample
{
    public class FirstViewModel : ViewModelBase
    {
		private readonly IMarvelApiService _marvelService;
		private bool _IsFirstLoad = true;
		public FirstViewModel ()
		{
			_marvelService = RockServiceLocator.Current.Get<IMarvelApiService>();
		}

		public override async Task InitAsync ()
		{
			await LoadData ();
		}

		#region SearchText

		private string _SearchText;

		public string SearchText {
			get {
				return _SearchText;
			}
			set {
				_SearchText = value;
				OnPropertyChanged ("SearchText");
			}
		}

		#endregion

		#region CharacterList

		private List<CharacterItemViewModel> _CharacterList;

		public List<CharacterItemViewModel> CharacterList {
			get {
				return _CharacterList;
			}
			set {
				_CharacterList = value;
				OnPropertyChanged ("CharacterList");
			}
		}

		#endregion

		#region SearchByName Command

		private ICommand _SearchByName;

		public ICommand SearchByName {
			get {
				return _SearchByName ?? (_SearchByName = new Command (
					async () => await ExecuteSearchByNameCommand (),
					ValidateSearchByNameCommand)); 
			}
		}

		private async Task ExecuteSearchByNameCommand ()
		{
			await LoadData (SearchText);
		}

		private bool ValidateSearchByNameCommand ()
		{
			return true;
		}

		#endregion

		#region CharacterSelection Command

		private ICommand _CharacterSelection;

		public ICommand CharacterSelection {
			get {
				return _CharacterSelection ?? (_CharacterSelection = new Command<CharacterItemViewModel> (
					ExecuteCharacterSelectionCommand,
					ValidateCharacterSelectionCommand)); 
			}
		}

		private void ExecuteCharacterSelectionCommand (CharacterItemViewModel character)
		{
			this.Navigation.PushAsync<DetailViewModel> (new DetailViewModel (character));
		}

		private bool ValidateCharacterSelectionCommand (CharacterItemViewModel character)
		{
			return true;
		}

		#endregion

		#region LoadData

		public async Task LoadData (string filter = null, int limit = 0, int offset = 0)
		{
			IsBusy = true;

			var result = await _marvelService.GetCharacters (filter, limit, offset);


			if (result != null) {
				CharacterList = (from p in result.Results
				                 select new CharacterItemViewModel () {
						Id = p.Id,
						Name = p.Name,
						Thumbnail = p.Thumbnail.Path + "." + p.Thumbnail.Extension,
						Description = p.Description
				}).ToList ();
			}

			IsBusy = false;

		}

		#endregion




			
    }
}
