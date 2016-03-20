# FreshEssentials for Xamarin.Forms

## Introduction

FreshEssentials is a library of tools designed to make it easier to build Xamarin Forms applications.

One of the bottlenecks in the development of Xamarin Forms Applications is that XAML Controls are still under development and some of the features that are already available in the Windows Runtime XAML Framework have not yet been transferred across. This leaves the developer with the only option of writing these by themself, which is time consuming and prevents the developer from concentating on more pressing tasks.

This library aims to alleviate the developer from this burden by providing already built tools for the most commonly used controls.


So far the following types of tools have been built:

 - Controls that extend existing Xamarin Controls: the ExtendedPicker.

 - Command Attached properties: the ItemTappedAttached, EntryCompletedAttached and the TappedGestureAttached.

 - Custom built Controls: the SegmentedButton

These are explained in more detail in the relevent sections contained within this article.


## Existing Controls that have been Extended

#### The ExtendedPicker.

This class extends the existing Picker class described at https://developer.xamarin.com/api/type/Xamarin.Forms.Picker/.

The operation of the original class is similar to that of a pop-up keyboard. The user clicks on the text-entry field to bring up a list of items to choose from. The list of items displayed is a string, which is typically set to the index of an external source such as a dictionary (or similar). The user codes the property changed event to handle the fetching and displaying of the chosen item from the dictionary. 

The extended class adds to the functionality of the original picker class by loading the external source of items internally within the control. Consequently the property changed event is handled automatically, freeing the user from this task.

###### Instructions 

Install the Tools package using NuGet. Alternatively manually add the Tools.dll to the reference of your projects for common pcl, iOS and droid.

Create the control from the code behind
```
Tools.ExtendedPicker picker = new Tools.ExtendedPicker 
			{ 
				Title = "Color",
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 190,
				DisplayProperty = "Name",   
				ItemsSource = ColorProperties,  
				AllTitle = "List of Colors",
				CanHaveAll = true
			};
```

where `"Name"` is the field from the `ColorProperty` object to display in the Extended Picker list and `ColorProperties` is a List of `ColorProperty` objects that is maintained by the control.


###### Implementation and Samples 

The implementation of this ExtendedPicker is given at:

- [ExtentedPicker.cs](https://github.com/redironbark/FreshEssentials/blob/master/Tools/Tools/ExtendedPicker.cs)

The sample for this ExtendedPicker is given at:

- [ColorPickerPage.xaml](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/ExtendedPicker/ColorPickerPage.xaml)

- [ColorPickerPage.xaml.cs](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/ExtendedPicker/ColorPickerPage.xaml.cs)


## Command Attached Properties

One of the hallmarks of Xamarin Forms is that it uses MVVM, just like its big brother Windows Runtime XAML Framework. How this works is that essentially, the user builds a View-Model class by deriving it from the INotifyPropertyChanged interface, implements the PropertyChanged Event and fires it when a property changes<sup>✝</sup>. The properties of Controls in the XAML View are then able to bind to properties in the ViewModel. Events occurring in the XAML View, such as button clicks etc, are handled slightly differently. They use the Command Property to bind to the View-Model, rather than ordinary properties. 

Unfortunately the Command Property is not availaible on every XAML control, which is the job of the tools provided here. The tools in this section make the Command Property available to XAML Controls that would otherwise not have them. This is achieved by creating the property as an external property, otherwise known as the Attached Property. Although it can be argued that this can be handled by creating a Tap Gesture, an Attached Property simplifies the code considerably. Michael Ridland has discussed Attached Properties in more depth at http://www.michaelridland.com/xamarin/xaml-attached-properties-tricks-in-xamarin-forms/.

<sup>✝</sup>*Note that FreshMVVM handles much of the labour of creating MVVM applications automatically and the reader is encouraged to use this for new applications (https://github.com/rid00z/FreshMvvm)*.


#### The ItemTappedAttached Property

The ItemTappedProperty is a command property designed to be attached to a ListView to handle the case of when an item is tapped in the list.

###### Instructions 

Install the Tools package using NuGet. Alternatively manually add the Tools.dll to the reference of your projects for common pcl, iOS and droid.

In Xaml, add the Tools reference to the ContentPage
```
xmlns:local="clr-namespace:Tools;assembly=Tools"
```

then attach the property to the desired ListView
```
<ListView x:Name="AircraftList" 
	local:ItemTappedAttached.Command="{Binding Click}"
	SelectedItem="{Binding SelectedItem}">
```

In the code behind set the ContentPage binding context to the ViewModel
```
AircraftViewModel viewModel = new AircraftViewModel (this.Navigation);

BindingContext = viewModel;
```

###### Implementation and Samples

The implementation of this AttachedProperty is given at:

- [ItemTappedAttached.cs](https://github.com/redironbark/FreshEssentials/blob/master/Tools/Tools/ItemTappedAttached.cs)

The sample for this AttachedProperty is given at:

- [AircraftPage.xaml](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/ItemTappedAttached/AircraftPage.xaml)

- [AircraftPage.xaml.cs](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/ItemTappedAttached/AircraftPage.xaml.cs)

#### The TappedGestureAttached Property

The TappedGestureAttached is a command property designed to be attached to a control such as an Image to handle the case of when an item is tapped. 

###### Instructions 

Install the Tools package using NuGet. Alternatively manually add the Tools.dll to the reference of your projects for common pcl, iOS and droid.

In Xaml, add the Tools reference to the ContentPage
```
xmlns:local="clr-namespace:Tools;assembly=Tools"
```

then attach the property to the desired component
```
<Image Source="{Binding SuzukiLocation}" 
	local:TappedGestureAttached.Command="{Binding Click}"
	local:TappedGestureAttached.CommandParameter="Suzuki">
</Image>
```

In the code behind set the ContentPage binding context to the ViewModel
```
BindingContext = new MotorbikeViewModel ();
```

###### Implementation and Samples

The implementation of this AttachedProperty is given at:

- [TappedGestureAttached.cs](https://github.com/redironbark/FreshEssentials/blob/master/Tools/Tools/TappedGestureAttached.cs)

The sample for this AttachedProperty is given at:

- [MotorbikePage.xaml](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/TappedGestureAttached/MotorbikePage.xaml)

- [MotorbikePage.xaml.cs](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/TappedGestureAttached/MotorbikePage.xaml.cs)


#### The EntryCompletedAttached

The EntryCompletedAttached is a command property designed to be attached to a control such as an Entry to handle the case of when text entry is completed. 

An example would be password entry.

###### Instructions 

Install the Tools package using NuGet. Alternatively manually add the Tools.dll to the reference of your projects for common pcl, iOS and droid.

In Xaml, add the Tools reference to the ContentPage
```
xmlns:local="clr-namespace:Tools;assembly=Tools"
```

then attach the property to the Entry control
```
<Entry x:Name="username" 
	WidthRequest="200" 
	Text="{Binding Username}"
	local:EntryCompletedAttached.Command="{Binding Completed}"
	local:EntryCompletedAttached.CommandParameter="usernameEntered"/>
```

In the code behind set the ContentPage binding context to the ViewModel
```
BindingContext = new PasswordEntryViewModel (this);
```

###### Implementation and Samples

The implementation of this AttachedProperty is given at:

- [EntryCompletedAttached.cs](https://github.com/redironbark/FreshEssentials/blob/master/Tools/Tools/EntryCompletedAttached.cs)

The sample for this AttachedProperty is given at:

- [PasswordEntryPage.xaml](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/EntryCompletedAttached/PasswordEntryPage.xaml)

- [PasswordEntryPage.xaml.cs](https://github.com/redironbark/FreshEssentials/blob/master/Samples/Samples/EntryCompletedAttached/PasswordEntryPage.xaml.cs)

## Custom Built Controls

#### The SegmentedButton

One of the issues that arose during recent development was that of how to deal with rounded corners. Currently this is poorly handled in Xamarin compared to Windows Runtime. The SegmentedButton control is a button controll with rounded corners.

###### How to use this control 

The implementation of this AttachedProperty is given at:

The sample for this AttachedProperty is given at:
