using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageD : StateMachinePage
	{
		public PageD (NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel) : 
			base(navPage, stateMachineData, HandleSequenceEnd, HandleCancel)
		{
			System.Diagnostics.Debug.WriteLine ("PageD.ctor()");

			InitializeComponent ();
		}
	}
}

