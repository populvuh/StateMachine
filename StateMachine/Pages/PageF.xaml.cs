using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageF : StateMachinePage
	{
		public PageF (NavigationPage navPage) : base(navPage)
		{
			System.Diagnostics.Debug.WriteLine ("PageF.ctor()");

			InitializeComponent ();

			Title = "Page F";
		}
	}
}

