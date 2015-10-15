using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageA : StateMachinePage
	{
		public PageA (NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel) : 
			base(navPage, stateMachineData, HandleSequenceEnd, HandleCancel)
		{
			System.Diagnostics.Debug.WriteLine ("PageA.ctor()");
			InitializeComponent ();

			Title = "Page A";
		}


		public override void SaveInputData() {
		}

	}
}

