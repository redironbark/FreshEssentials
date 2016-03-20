﻿using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace Tools
{
	public class TappedGestureAttached
	{
		public static readonly BindableProperty CommandProperty =
			BindableProperty.CreateAttached (
				propertyName: "Command",
				returnType: typeof(ICommand),
				declaringType: typeof(View),
				defaultValue: null,
				defaultBindingMode: BindingMode.OneWay,
				validateValue: null,
				propertyChanged: OnItemTappedChanged);

		public static readonly BindableProperty CommandParameterProperty =
			BindableProperty.CreateAttached (
				propertyName: "CommandParameter",
				returnType: typeof(object),
				declaringType: typeof(View),
				defaultValue: null,
				defaultBindingMode: BindingMode.OneWay,
				validateValue: null);


		public static object GetCommandParameter(BindableObject bindable)
		{
			return (object)bindable.GetValue (CommandProperty);
		}

		public static void SetCommandParameter(BindableObject bindable, object value)
		{
			bindable.SetValue (CommandProperty, value);
		}

		public static ICommand GetCommand(BindableObject bindable)
		{
			return (ICommand)bindable.GetValue (CommandProperty);
		}

		public static void SetCommand(BindableObject bindable, ICommand value)
		{
			bindable.SetValue (CommandProperty, value);
		}

		public static void OnItemTappedChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = bindable as View;

			if (control != null) 
			{
				control.GestureRecognizers.Clear ();
				control.GestureRecognizers.Add 
				(
					new TapGestureRecognizer() 
					{
						Command = new Command((o) => 
							{
								var command = GetCommand (control);

								object parameter = control.GetValue (CommandParameterProperty);

								if (command != null && command.CanExecute (parameter))
									command.Execute (parameter);
							})
					}
				);
			}
		}

	}
}

