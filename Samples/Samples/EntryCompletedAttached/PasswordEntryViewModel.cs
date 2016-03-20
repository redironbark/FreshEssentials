using System;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Samples
{
	public class PasswordEntryViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand Completed { get; set; }

		string username;

		string password;

		bool validUsername;

		bool validPassword;

		Page page;

		public List<Employee> Staff;

		public PasswordEntryViewModel (Page page)
		{
			this.page = page;

			Completed = new Command (OnCompleted); 

			Staff = new List<Employee> {
				new Employee{ Name = "katie", Password = "jaguar" },
				new Employee{ Name = "keira", Password = "cheetah" },
				new Employee{ Name = "kyler", Password = "tiger" },
				new Employee{ Name = "kylie", Password = "puma" },
				new Employee{ Name = "karen", Password = "lynx" },
				new Employee{ Name = "keith", Password = "lion" },
			};

			validUsername = false;

		}
		private void OnCompleted(object parameter)
		{
			switch((string)parameter)
			{
			case "usernameEntered":
				foreach (Employee person in Staff) {
					if (person.Name == username) {
						validUsername = true;
						break;
					}
				}
				if (validUsername == false) 
				{
					Username = "";
					page.DisplayAlert ("Inavlid Username", "A person with that name does not exist", "OK");
				}
				break;
			case "passwordEntered":
				foreach (Employee person in Staff) {
					if (person.Name == username) {
						validUsername = true;
						if (person.Password == password) {	
							validPassword = true;
						}
					}
				}	
				if ((validUsername == false) || (validPassword == false)) 
				{
					Username = "";
					Password = "";
					page.DisplayAlert ("Inavlid Password", "Password does not match", "OK");
				}
				break;
			}
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
		public string Username
		{
			set
			{
				if (username != value) 
				{
					username = value;
					OnPropertyChanged ("Username");
				}
			}
			get 
			{
				return username;
			}
		}
		//
		public string Password
		{
			set
			{
				if (password != value) 
				{
					password = value;
					OnPropertyChanged ("Password");
				}
			}
			get 
			{
				return password;
			}
		}
	}
}

