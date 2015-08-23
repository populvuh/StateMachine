using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StateMachineTest
{
	public partial class StartPage : ContentPage
	{
		public StartPage ()
		{
			InitializeComponent ();
		}

		async void OnStateMachine(object sender, EventArgs args)
		{
			// /*
			Node nodeA = new Node (PageType.ePageA);
			Node nodeB = nodeA.Add (PageType.ePageB);

			Node nodeC = nodeB.Add (PageType.ePageC);
			Node nodeD = nodeC.Add (PageType.ePageD);
			nodeB.Add (nodeD);

			Node nodeE = nodeD.Add (PageType.ePageE);
			nodeE.Add (PageType.ePageF);

			Node nodeF = nodeD.Add (PageType.ePageF);
			nodeF.Add (PageType.ePageE);

			StateMachine sm = new StateMachine (nodeA);

			await sm.ShowAsync (Navigation);
		}

		async void OnStateMachine2(object sender, EventArgs args)
		{
			Node nodeF = new Node (PageType.ePageF);
			Node nodeE = nodeF.Add (PageType.ePageE);
			Node nodeD = nodeE.Add (PageType.ePageD);

			Node nodeC = nodeD.Add (PageType.ePageC);
			Node nodeB = nodeC.Add (PageType.ePageB);
			nodeB.Add (PageType.ePageA);

			StateMachine sm = new StateMachine (nodeF);

			await sm.ShowAsync (Navigation);
		}

	}
}

