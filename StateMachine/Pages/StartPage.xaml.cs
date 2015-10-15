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

		async void OnStateMachine (object sender, EventArgs args)
		{
			Node nodeA = new Node (PageType.ePageA);
			Node nodeB = nodeA.Add (PageType.ePageB);

			Node nodeC = nodeB.Add (PageType.ePageC);
			Node nodeD = nodeC.Add (PageType.ePageD);

			// Note; nodeB has both nodeC, and nodeD added to it
			// but we only create nodeD once as we don't need 2 copies of it
			nodeB.Add (nodeD);

			Node nodeE = nodeD.Add (PageType.ePageE);
			nodeE.Add (PageType.ePageF);

			// Note; nodeD has both nodeE, and nodeF added to it
			// but we create nodeE and nodeF twice as we do need 2 copies of each (one for e--> F, and the other F --> E)
			Node nodeF = nodeD.Add (PageType.ePageF);
			nodeF.Add (PageType.ePageE);

			StateMachine sm = new StateMachine (nodeA);
		
			await sm.ShowAsync (Navigation);
		}

		async void OnStateMachine2 (object sender, EventArgs args)
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

