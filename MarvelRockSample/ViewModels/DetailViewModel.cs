
using Xamarin.Forms;
using System.Windows.Input;
using RockMvvmForms;

namespace MarvelRockSample
{
	public class DetailViewModel : ViewModelBase
	{
		private readonly IOpenWebService _openWebService;

		public DetailViewModel (CharacterItemViewModel character)
		{
			Character = character;
			_openWebService = DependencyService.Get<IOpenWebService> ();
		}

		#region Character

		private CharacterItemViewModel _Character;

		public CharacterItemViewModel Character {
			get {
				return _Character;
			}
			set {
				_Character = value;
				OnPropertyChanged ("Character");
			}
		}

		#endregion


		#region OpenWeb Command

		private ICommand _OpenWeb;

		public ICommand OpenWeb {
			get {
				return _OpenWeb ?? (_OpenWeb = new Command (
					ExecuteOpenWebCommand,
					ValidateOpenWebCommand)); 
			}
		}

		private void ExecuteOpenWebCommand ()
		{
			_openWebService.OpenUrl (Character.Thumbnail);
		}

		private bool ValidateOpenWebCommand ()
		{
			return true;
		}

		#endregion


	}
}

