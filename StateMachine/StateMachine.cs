using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StateMachineTest
{
	public class StateMachine
	{
		private NavigationPage _navigationPage;
		private readonly TaskCompletionSource<SequenceResults> _taskCompletionSource = new TaskCompletionSource<SequenceResults>();


		public StateMachine (Node startNode)
		{
			// create a new navpage to push the state machine onto, and which then can be popped off at the end
			_navigationPage = new NavigationPage();								

			// _OkHandler is a static, to save having to pass HandleSequenceEnd into the StateMachinePage constructor
			StateMachinePage._EndHandler += HandleSequenceEnd;
			StateMachinePage._CancelHandler += HandleCancel;

			// create the first page of the sequence
			StateMachinePage p = PageFactory.CreatePage (startNode._pageType, _navigationPage );
			startNode.CreatePages (p, _navigationPage);

			// start the sequence going ...
			_navigationPage.PushAsync (p);
		}


		private void HandleSequenceEnd(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine ("StateMachine.HandleSequenceEnd()");

			_taskCompletionSource.TrySetCanceled();
		}


		public void HandleCancel(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine ("StateMachine.HandleCancel()");

			_taskCompletionSource.TrySetResult(new SequenceResults (false));
		}

		async public Task ShowAsync (INavigation navigation)
		{
			System.Diagnostics.Debug.WriteLine ("StateMachine.ShowAsync()");

			// push on the base nav page modally, so that the whole lot can be poped off at the end
			await navigation.PushModalAsync(_navigationPage);

			// wait till its finished, then clean it all up
			var results = await _taskCompletionSource.Task;

			await navigation.PopModalAsync ();
		}			
	}
}

