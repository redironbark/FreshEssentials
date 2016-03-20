using System;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Samples
{
	public class AircraftViewModel : INotifyPropertyChanged
	{

		INavigation navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand Click { get; set; }

		object selectedItem;

		public List<AircraftModel> Aircraft;


		public  AircraftViewModel(INavigation navigation)
		{
			this.navigation = navigation;

			Click = new Command (OnClick); 

			Aircraft = new List<AircraftModel>
			{
				new AircraftModel{Name = "Avro Lancaster", Detail = "RAF Bomber", Url = "AvroLancaster.jpg"},
				new AircraftModel{Name = "Bristol Blenheim", Detail = "RAF Light Bomber", Url = "BristolBlenheim.jpg"},
				new AircraftModel{Name = "DeHavilland Mosquito", Detail = "RAF Fighter-Bomber", Url = "DeHavillandMosquito.jpg"},
				new AircraftModel{Name = "Focke Wulf", Detail = "Luftwaffe Fighter", Url = "FockeWulf.jpg"},
				new AircraftModel{Name = "Gloster Gladiator", Detail = "RAF Obsolete Fighter", Url = "GlosterGladiator.jpg"},
				new AircraftModel{Name = "Hawker Hurricane", Detail = "RAF Fighter", Url = "HawkerHurricane.jpg"},
				new AircraftModel{Name = "Red Arrows Hawk", Detail = "RAF Display Aircraft", Url = "HawkRedArrows.jpg"},
				new AircraftModel{Name = "Junkers Ju 87 Stuka", Detail = "Luftwaffe Dive-Bomber", Url = "JunkersJu87Stuka.jpg"},
				new AircraftModel{Name = "Messerschmitt BF109", Detail = "Luftwaffe Fighter", Url = "MesserschmittBF109.jpg"},
				new AircraftModel{Name = "Mitsubishi Zero", Detail = "Japanese Fighter", Url = "MitsubishiZero.jpg"},
				new AircraftModel{Name = "Supermarine Spitfire", Detail = "RAF Fighter", Url = "SupermarineSpitfire.jpg"},
				new AircraftModel{Name = "Supermarine Spitfire Vb", Detail = "RAF Fighter", Url = "SupermarineSpitfireVb.jpg"},
				new AircraftModel{Name = "Messerschmitt BF110", Detail = "Luftwaffe Heavy Fighter", Url = "MesserschmittBF110.jpg"},
				new AircraftModel{Name = "Mitsubishi Dinah", Detail = "Japanese Reconnaissance Airaft", Url = "MitsubishiDinah.jpg"},
				new AircraftModel{Name = "Supermarine Swift", Detail = "RAF Jet Fighter", Url = "SupermarineSwift.jpg"},
				new AircraftModel{Name = "Mig 29 Fulcrum", Detail = "Russian Jet Fighter", Url = "Mig29Fulcrum.jpg"},
				new AircraftModel{Name = "Westland Sea King", Detail = "RAF Helicopter", Url = "WestlandSeaKing.jpg"},
				new AircraftModel{Name = "DeHavilland Mosquito FBVI", Detail = "RAF Antiship Bomber", Url = "DeHavillandMossquitoFBVI.jpg"}
			};

		}
		private async void OnClick()
		{
			var model = ((AircraftModel)selectedItem);
			await navigation.PushModalAsync(new ImagePage(model.Url, model.Name ));
		}
		//
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null) 
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		//
		public object SelectedItem
		{
			set
			{
				if (selectedItem != value) 
				{
					selectedItem = value;
					OnPropertyChanged ("SelectedItem");
				}
			}
			get 
			{
				return selectedItem;
			}
		}
		//
	}
}

