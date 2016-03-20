using System;

using Xamarin.Forms;

using System.Collections.Generic;

namespace Samples
{
	public class App : Application
	{
		public App ()
		{
			ListView list = new ListView 
			{
				ItemsSource = new List<string> {
					"ExtendedPicker",
					"ItemTappedAttached",
					"TappedGestureAttached",
					"EntryCompletedAttached",
					"SegmentedButton"
				},
			};

			list.ItemSelected += async (sender, arg) => {
				switch (arg.SelectedItem.ToString ()) {
				case "ExtendedPicker":
					await MainPage.Navigation.PushAsync(new ColorPickerPage());
					break;
				case "ItemTappedAttached":
					await MainPage.Navigation.PushAsync(new AircraftPage());
					break;
				case "TappedGestureAttached":
					await MainPage.Navigation.PushAsync(new MotorbikePage());
					break;
				case "EntryCompletedAttached":
					await MainPage.Navigation.PushAsync(new PasswordEntryPage());
					break;
				case "SegmentedButton":
					// not yet implemented //
					break;
				}
			};

			MainPage = new NavigationPage (new ContentPage{
				Content = list});
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

