using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageB : StateMachinePage
	{
		public PageB (NavigationPage navPage) : base(navPage)
		{
			System.Diagnostics.Debug.WriteLine ("PageB.ctor()");

			InitializeComponent ();

			Title = "Page B";
		}

		public override void OnShow() {
			if (null == _stateMachineData.dataA)
				_stateMachineData.dataA = "abc xyz";
			
			_stateMachineData.dataA = _stateMachineData.dataA.ToUpper ();
			System.Diagnostics.Debug.WriteLine ("PageB.OnShow( {0} )", _stateMachineData.dataA);
		}
	}
}

