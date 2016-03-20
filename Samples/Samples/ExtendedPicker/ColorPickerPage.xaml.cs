using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Samples
{
	public partial class ColorPickerPage : ContentPage
	{
		class ColorProperty // This is the object type that the Extented Picker will use.
		{
			public string Name { get; set; }
			public Color BackGroundColor{ get; set; }
			public ColorProperty(string Name, Color BackGroundColor)
			{
				this.Name = Name;
				this.BackGroundColor = BackGroundColor;
			}
		};

		List<ColorProperty> ColorProperties = // This is the list of objects that will be loaded into the Extented Picker source
			new List<ColorProperty>
		{
			new ColorProperty("Aqua", Color.Aqua), 
			new ColorProperty("Black", Color.Black), 
			new ColorProperty("Blue", Color.Blue),  
			new ColorProperty("Fuchsia",Color.Fuchsia),  
			new ColorProperty("Gray", Color.Gray), 
			new ColorProperty("Green", Color.Green),  
			new ColorProperty("Lime", Color.Lime), 
			new ColorProperty("Maroon", Color.Maroon), 
			new ColorProperty("Navy", Color.Navy), 
			new ColorProperty("Purple", Color.Purple), 
			new ColorProperty("Red", Color.Aqua), 
			new ColorProperty("Silver", Color.Silver), 
			new ColorProperty("Teal", Color.Teal), 
			new ColorProperty("White", Color.White), 
			new ColorProperty("Yellow", Color.Yellow), 
		};

		public ColorPickerPage ()
		{
			InitializeComponent ();

			Label header = new Label
			{
				Text = "Extented Picker Control Example",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			Tools.ExtendedPicker picker = new Tools.ExtendedPicker 
			{ 
				Title = "Color",
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 190,
				DisplayProperty = "Name",  // Set the text to display of the Extended Picker to use the Name field 
				// from the Color Property object.
				ItemsSource = ColorProperties, // Set the source that the Extented Picker will use. In this case, ColorProperties list. 
				AllTitle = "List of Colors",
				CanHaveAll = true
			};

			Frame frame = new Frame {
				WidthRequest = 150,
				HeightRequest = 150,
				HorizontalOptions = LayoutOptions.Center,
				HasShadow = false,
				OutlineColor = Color.Silver,
				BindingContext = picker  // Bind to the Extended picker control
			};
			frame.SetBinding (Frame.BackgroundColorProperty, "SelectedItem.BackGroundColor"); 

			Content = new StackLayout 
			{
				Children=
				{
					header, frame, picker
				}
				};
		}
	}
}

