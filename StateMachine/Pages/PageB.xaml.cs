﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageB : StateMachinePage
	{
		public PageB (NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel) : 
			base(navPage, stateMachineData, HandleSequenceEnd, HandleCancel)
		{
			System.Diagnostics.Debug.WriteLine ("PageB.ctor()");

			InitializeComponent ();
		}

		public override void OnShow() {
			if (null == _stateMachineData.dataA)
				_stateMachineData.dataA = "abc xyz";
			
			_stateMachineData.dataA = _stateMachineData.dataA.ToUpper ();
			System.Diagnostics.Debug.WriteLine ("PageB.OnShow( {0} )", _stateMachineData.dataA);
		}
	}
}

