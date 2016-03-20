using System;

using Xamarin.Forms;

namespace Samples
{
	public class ImagePage : ContentPage
	{
		public ImagePage (string imageSource, string name)
		{
			Padding = new Thickness (20, 20, 20, 20);
			Label label = new Label {
				Text = name,
				HorizontalOptions = LayoutOptions.Center,				
				VerticalOptions = LayoutOptions.Center
			};

			Image image = new Image {
				Source = imageSource,
				HorizontalOptions = LayoutOptions.Center,				
				VerticalOptions = LayoutOptions.Center
			};

			image.GestureRecognizers.Add (
				new TapGestureRecognizer ((obj, arg) => Navigation.PopModalAsync ()));

			Content = new StackLayout 
			{ 
				VerticalOptions = LayoutOptions.Center,
				Children = { image, label }
			};
		}
	}
}