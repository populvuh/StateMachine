using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageE : StateMachinePage
	{
		public PageE (NavigationPage navPage) : base(navPage)
		{
			System.Diagnostics.Debug.WriteLine ("PageE.ctor()");

			InitializeComponent ();

			Title = "Page E";
		}
	}
}

