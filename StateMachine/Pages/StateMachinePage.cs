using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;


namespace StateMachineTest
{

	public class StateMachineData : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = delegate {};

		string _dataA;

		public string dataA {
			get
			{ return _dataA; }
			set {
				if (_dataA != value) {
					_dataA = value;
					RaisePropertyChanged ();
				}
			}
		}

		string _dataB;

		public string dataB {
			get
			{ return _dataB; }
			set {
				if (_dataB != value) {
					_dataB = value;
					RaisePropertyChanged ();
				}
			}
		}

		//public string dataC	{ get; set; }
		//public string dataD	{ get; set; }
		//public string dataE	{ get; set; }

		void RaisePropertyChanged ([CallerMemberName] string propertyName = "")
		{
			PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}
	}


	public class StateMachinePage : ContentPage
	{
		public NavigationPage _navigationPage { get; set; }
		public List<StateMachinePage> _nextPages = new List<StateMachinePage> ();

		static public event EventHandler _CancelHandler;
		static public event EventHandler _EndHandler;

		static public StateMachineData _stateMachineData = new StateMachineData ();

		public StateMachinePage ()
		{
		}

		public StateMachinePage (NavigationPage navPage)
		{
			_navigationPage = navPage;
			BindingContext = _stateMachineData;
		}

		public void OnNext (object sender, EventArgs args)
		{
			SaveInputData ();

			// use the buttons CommandParameter to pass in the index of the next page (if more than 1 button)
			string strIdx = (null==((Button)sender).CommandParameter) ? "0" : ((Button)sender).CommandParameter.ToString();
			int idx = Int32.Parse ((null == strIdx) ? "0" : strIdx);
			System.Diagnostics.Debug.WriteLine ("{0}.OnNext() - NextPages.Count={1}, NextPage.idx={2} )", Title, _nextPages.Count, idx);


			// if no more pages, or next button styleid > page count, they r at the end of this branch
			if (_nextPages.Count == 0 || _nextPages.Count <= idx || null == _navigationPage) {
				
				OnEndSequence (args);										// the final state, so call the end handler

			} else {

				StateMachinePage nextPage = _nextPages [idx];
				if (null == nextPage) {											// aarrrgghhh, no page
					OnEndSequence (args);										// so call the end handler rather than crash
				}

				nextPage.OnShow ();												// do anything it needs to do before displaying itself (load data etc)
				_navigationPage.PushAsync (nextPage);							// display the page
			}
		}

		protected virtual void OnEndSequence (EventArgs e)
		{
			EventHandler handler = _EndHandler;
			if (handler != null) {
				handler (this, e);
			}
		}

		public void OnCancel (object sender, EventArgs e) 
		{
			EventHandler handler = _CancelHandler;
			if (handler != null) {
				handler (this, e);
			}
		}

		public virtual void SaveInputData ()
		{
		}

		public virtual void OnShow ()
		{
		}
	}
}

