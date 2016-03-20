using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Samples
{
	public partial class AircraftPage : ContentPage
	{
		public AircraftPage ()
		{
			InitializeComponent ();

			AircraftViewModel viewModel = new AircraftViewModel (this.Navigation);

			BindingContext = viewModel;

			AircraftList.ItemsSource = viewModel.Aircraft;
		}
	}
}

