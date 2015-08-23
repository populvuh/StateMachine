using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageD : StateMachinePage
	{
		public PageD (NavigationPage navPage) : base(navPage)
		{
			System.Diagnostics.Debug.WriteLine ("PageD.ctor()");

			InitializeComponent ();

			Title = "Page D";
		}
	}
}

