using System;
using System.Windows.Input;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Samples
{
	public class MotorbikeViewModel : INotifyPropertyChanged
	{
		string suzukiOutput;
		string kawasakiOutput;

		string suzukiLocation;
		string kawasakiLocation;

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand Click { get; set; }

		int SuzukiIndex; 
		int KawasakiIndex; 
		int SuzukiCount; 
		int KawasakiCount; 

		List<MotorBike> SuzukiMotorBikes = new List<MotorBike>
		{
			new MotorBike("1983 RG 250", "1983_RG250.jpg"),
			new MotorBike("1985 RG 125", "1985_RG125.jpg"),
			new MotorBike("1986 RG 250", "1986_RG250.jpg"),
			new MotorBike("1988 GSXR 400", "1988_GSXR400.jpg"),
			new MotorBike("1989 GSXR 750", "1989_GSXR750.jpg"),
			new MotorBike("1992 RGV 250", "1992_RGV250.jpg"),
		};

		List<MotorBike> KawasakiMotorBikes = new List<MotorBike>
		{
			new MotorBike("1998 ZX600", "1998_ZX600.jpg"),
			new MotorBike("1999 KL250", "1999_KL250.jpg"),
			new MotorBike("2002 ZX9R", "2002_ZX9R.jpg"),
			new MotorBike("2011 ZZR1400", "2011_ZZR1400.jpg"),
			new MotorBike("2014 Versys 650", "2014_Versys650.jpg"),
		};

		public  MotorbikeViewModel()
		{
			Click = new Command (OnClick); 
			SuzukiCount = SuzukiMotorBikes.Count;
			KawasakiCount = KawasakiMotorBikes.Count;
			//
			SuzukiIndex = 0; 
			KawasakiIndex = 0;
			//
			MotorBike bike = SuzukiMotorBikes [SuzukiIndex];
			SuzukiOutput = bike.Name;
			SuzukiLocation = bike.Url;
			//
			bike = KawasakiMotorBikes [KawasakiIndex];
			KawasakiOutput = bike.Name;
			KawasakiLocation = bike.Url;
		}
		private void OnClick(object parameter)
		{
			MotorBike bike;
			switch((string)parameter)
			{
			case "Suzuki":
				SuzukiIndex = (SuzukiIndex + 1) % SuzukiCount;
				bike = SuzukiMotorBikes [SuzukiIndex];
				SuzukiOutput = bike.Name;
				SuzukiLocation = bike.Url;
				break;
			case "Kawasaki":
				KawasakiIndex = (KawasakiIndex + 1) % KawasakiCount;
				bike = KawasakiMotorBikes [KawasakiIndex];
				KawasakiOutput = bike.Name;
				KawasakiLocation = bike.Url;
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
		public string SuzukiOutput
		{
			set
			{
				if (suzukiOutput != value) 
				{
					suzukiOutput = value;
					OnPropertyChanged ("SuzukiOutput");
				}
			}
			get 
			{
				return suzukiOutput;
			}
		}
		//
		public string KawasakiOutput
		{
			set
			{
				if (kawasakiOutput != value) 
				{
					kawasakiOutput = value;
					OnPropertyChanged ("KawasakiOutput");
				}
			}
			get 
			{
				return kawasakiOutput;
			}
		}
		//
		public string SuzukiLocation
		{
			set
			{
				if (suzukiLocation != value) 
				{
					suzukiLocation = value;
					OnPropertyChanged ("SuzukiLocation");
				}
			}
			get 
			{
				return suzukiLocation;
			}
		}

		//
		public string KawasakiLocation
		{
			set
			{
				if (kawasakiLocation != value) 
				{
					kawasakiLocation = value;
					OnPropertyChanged ("KawasakiLocation");
				}
			}
			get 
			{
				return kawasakiLocation;
			}
		}

	}
}

