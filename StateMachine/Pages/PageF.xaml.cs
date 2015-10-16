using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageF : StateMachinePage
	{
		public PageF (NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel) : 
			base(navPage, stateMachineData, HandleSequenceEnd, HandleCancel)
		{
			System.Diagnostics.Debug.WriteLine ("PageF.ctor()");

			InitializeComponent ();
		}
	}
}

