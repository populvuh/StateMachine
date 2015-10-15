using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StateMachineTest
{
	public class StateMachineData : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		string _dataA;
		public string dataA {
			get	{ return _dataA; }
			set {
				if (_dataA != value) {
					_dataA = value;
					RaisePropertyChanged ();
				}
			}
		}

		string _dataB;
		public string dataB {
			get { return _dataB; }
			set {
				if (_dataB != value) {
					_dataB = value;
					RaisePropertyChanged ();
				}
			}
		}

		void RaisePropertyChanged ([CallerMemberName] string propertyName = "")
		{
			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}


		public StateMachineData ()
		{
		}
	}

}

