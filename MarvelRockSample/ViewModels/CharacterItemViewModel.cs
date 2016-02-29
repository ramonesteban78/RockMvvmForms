using System;
using RockMvvmForms;

namespace MarvelRockSample
{
	public class CharacterItemViewModel : ViewModelBase
	{
		
		#region Id

		private int _Id;

		public int Id {
			get {
				return _Id;
			}
			set {
				_Id = value;
				OnPropertyChanged ("Id");
			}
		}

		#endregion

		#region Name

		private string _Name;

		public string Name {
			get {
				return _Name;
			}
			set {
				_Name = value;
				OnPropertyChanged ("Name");
			}
		}

		#endregion

		#region Thumbnail

		private string _Thumbnail;

		public string Thumbnail {
			get {
				return _Thumbnail;
			}
			set {
				_Thumbnail = value;
				OnPropertyChanged ("Thumbnail");
			}
		}

		#endregion

		#region Description

		private string _Description;

		public string Description {
			get {
				return _Description;
			}
			set {
				_Description = value;
				OnPropertyChanged ("Description");
			}
		}

		#endregion

	}
}

