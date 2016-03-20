using System;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Tools
{
	public class ExtendedPicker : Picker
	{		
		public ExtendedPicker()
		{
			SetInitialValues ();
		}

		public ExtendedPicker(string DisplayProperty, IList ItemsSource, bool CanHaveAll, string AllTitle )
		{
			SetInitialValues ();
			this.DisplayProperty = DisplayProperty;
			this.ItemsSource = ItemsSource;
			this.CanHaveAll = CanHaveAll;
			this.AllTitle = AllTitle;
		}

		private void SetInitialValues()
		{
			base.SelectedIndexChanged += (sender, args) => 
			{
				SelectedItem = null; 
				if (CanHaveAll && SelectedIndex == 0)  
					return;
				if(SelectedIndex != -1) 
					SelectedItem = ItemsSource [SelectedIndex];			
			};
		}

		/// <summary>
		/// The can have all property.
		/// </summary>
		public static readonly BindableProperty CanHaveAllProperty = 
			BindableProperty.Create<ExtendedPicker, bool> (p => p.CanHaveAll, false,
				propertyChanged: (bindable, oldValue, newValue) => 
				{
					ExtendedPicker picker = (ExtendedPicker)bindable;
					//
					if (picker.CanHaveAll && picker.AllTitle != null) 
					{
						var tmpList = new List<object> (); 

						tmpList.Add (picker.AllTitle);

						if (picker.ItemsSource != null) 
						{
							foreach (var item in ((IList)picker.ItemsSource))
								tmpList.Add (item);
						}

						picker.ItemsSource = tmpList;
						loadItemsAndSetSelected(bindable);
					}				 
				});	
		public bool CanHaveAll 
		{
			get { return (bool)GetValue (CanHaveAllProperty); }
			set { SetValue (CanHaveAllProperty, value); }
		}

		/// <summary>
		/// All title property.
		/// </summary>
		public static readonly BindableProperty AllTitleProperty = 
			BindableProperty.Create<ExtendedPicker, string> (p => p.AllTitle, default(string));
		public string AllTitle 
		{
			get { return (string)GetValue (AllTitleProperty); }
			set { SetValue (AllTitleProperty, value); }
		}

		/// <summary>
		/// The item currently selected.
		/// </summary>
		public static readonly BindableProperty SelectedItemProperty = 
			BindableProperty.Create<ExtendedPicker, object> (p => p.SelectedItem, null, BindingMode.TwoWay, 
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					ExtendedPicker picker = (ExtendedPicker)bindable;
					if (picker.ItemsSource != null && picker.SelectedItem != null)				
						picker.SelectedIndex = picker.ItemsSource.IndexOf(newValue);
				});

		public object SelectedItem
		{
			get { return base.GetValue(ExtendedPicker.SelectedItemProperty); }
			set { base.SetValue(ExtendedPicker.SelectedItemProperty, value);}
		}

		/// <summary>
		/// The property contained in the list item that the Picker will display.
		/// Must be of type string.
		/// </summary>
		public static readonly BindableProperty DisplayPropertyProperty = 
			BindableProperty.Create<ExtendedPicker, string>(p => p.DisplayProperty, null, BindingMode.OneWay,  
				propertyChanged: (bindable, oldValue, newValue) => loadItemsAndSetSelected(bindable));

		public string DisplayProperty
		{
			get { return (string)base.GetValue(ExtendedPicker.DisplayPropertyProperty); }
			set { base.SetValue(ExtendedPicker.DisplayPropertyProperty, value); }
		}

		/// <summary>
		/// The list of items that the picker contains.
		/// </summary>
		public static readonly BindableProperty ItemsSourceProperty = 
			BindableProperty.Create<ExtendedPicker, IEnumerable>(p=>p.ItemsSource, null, BindingMode.OneWay, 
				propertyChanged: (bindable, oldValue, newValue) =>
				{
					ExtendedPicker picker = (ExtendedPicker)bindable;
					//
					if (picker.CanHaveAll)  
					{
						if (oldValue is IList && newValue is IList
							&& (((IList)oldValue).Count+1) == (((IList)newValue).Count)) 
						{
							//This is if we just added the new one already
						}
						else
						{
							var objectList = new List<object> (); // Create new list

							objectList.Add(picker.AllTitle);

							foreach (var item in ((IList)newValue))
								objectList.Add (item);

							picker.ItemsSource = objectList;
						}
					} 
					else 
					{
						picker.ItemsSource = (IList)newValue;
					}
					//
					loadItemsAndSetSelected(bindable); // Set strings in base class
				});	

		public IList ItemsSource
		{
			get { return (IList)base.GetValue(ExtendedPicker.ItemsSourceProperty); }
			set { base.SetValue(ExtendedPicker.ItemsSourceProperty, value); }
		}

		static void loadItemsAndSetSelected(BindableObject bindable)
		{
			// This method sets the List of Strings in the Base class.
			ExtendedPicker picker = (ExtendedPicker)bindable;
			if (picker.ItemsSource as IEnumerable != null)
			{
				picker.SelectedIndex = -1;
				picker.Items.Clear ();
				int count = 0;
				foreach (object obj in (IEnumerable)picker.ItemsSource)
				{
					string value = string.Empty;
					if (picker.DisplayProperty != null)
					{
						// get  string from from ItemsSource identified by DisplayProperty
						var prop = obj.GetType ().GetRuntimeProperties ().FirstOrDefault(
							p => string.Equals(p.Name, picker.DisplayProperty, StringComparison.OrdinalIgnoreCase));

						//
						if (prop != null) 
						{
							value = prop.GetValue (obj).ToString ();
						} else {
							value = obj.ToString ();
						}//
					}
					else
					{
						value = obj.ToString();
					}

					picker.Items.Add(value);  // populate base list of items

					if (picker.SelectedItem != null)
					{
						if (picker.SelectedItem == obj)
						{
							picker.SelectedIndex = count;
						}
					}
					count++;
				}
			}
		}
	}
}


