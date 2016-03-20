using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Samples
{
	public partial class PasswordEntryPage : ContentPage
	{
		public PasswordEntryPage ()
		{
			InitializeComponent ();

			BindingContext = new PasswordEntryViewModel (this);

		}

		protected override void OnAppearing()
		{
			username.Focus ();
		}
	}
}

