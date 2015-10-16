using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class PageC : StateMachinePage
	{
		public PageC (NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel) : 
			base(navPage, stateMachineData, HandleSequenceEnd, HandleCancel)
		{
			System.Diagnostics.Debug.WriteLine ("PageC.ctor()");

			InitializeComponent ();
		}

		public override void OnShow() {
			// reverse the string input at pageB
			if (null == _stateMachineData.dataB)
				_stateMachineData.dataB = "abc xyz";
			char[] array = _stateMachineData.dataB.ToCharArray();
			Array.Reverse(array);
			_stateMachineData.dataB = new String(array);
			System.Diagnostics.Debug.WriteLine ("PageC.OnShow( {0} )", _stateMachineData.dataB);
		}
	}
}

