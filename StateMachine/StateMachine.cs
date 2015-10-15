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

		StateMachineData _stateMachineData = new StateMachineData ();			// shared data struct, used by all pages to pass data


		public StateMachine (Node startNode)
		{
			// create a new navpage to push the state machine onto, and which then can be popped off at the end
			_navigationPage = new NavigationPage();								

			// create the first page of the sequence
			StateMachinePage p = PageFactory.CreatePage (startNode.pageType, _navigationPage, _stateMachineData, HandleSequenceEnd, HandleCancel );
			startNode.CreatePages (p, _navigationPage, _stateMachineData, HandleSequenceEnd, HandleCancel);

			// start the sequence going ...
			_navigationPage.PushAsync (p);
		}


		private void HandleSequenceEnd(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine ("StateMachine.HandleSequenceEnd()");

			_taskCompletionSource.TrySetResult(new SequenceResults (true));
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

