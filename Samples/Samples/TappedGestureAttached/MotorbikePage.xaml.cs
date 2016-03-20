using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Samples
{
	public partial class MotorbikePage : ContentPage
	{
		public MotorbikePage ()
		{
			InitializeComponent ();

			BindingContext = new MotorbikeViewModel ();
		}
	}
}

