using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;


namespace StateMachineTest
{
	// Base page for all pages in the sequence
	public class StateMachinePage : ContentPage
	{
		NavigationPage navigationPage { get; set; }
		List<StateMachinePage> nextPages = new List<StateMachinePage> ();

		protected event EventHandler CancelHandler;
		protected event EventHandler EndHandler;
		protected StateMachineData _stateMachineData	{ get; set; }


		public StateMachinePage ()
		{
		}

		public StateMachinePage (NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel)
		{
			navigationPage = navPage;
			_stateMachineData = stateMachineData;
			BindingContext = _stateMachineData;

			CancelHandler += HandleCancel;
			EndHandler += HandleSequenceEnd;
		}

		public void AddNext( StateMachinePage nextPage )
		{
			nextPages.Add (nextPage);
		}

		public void OnNext (object sender, EventArgs args)
		{
			SaveInputData ();

			// use the buttons AttachedProperties.IndexProperty to pass in the index of the next page (if more than 1 button)
			int idx = (int)((Button)sender).GetValue (AttachedProperties.IndexProperty);

			System.Diagnostics.Debug.WriteLine ("{0}.OnNext() - NextPages.Count={1}, NextPage.idx={2} )", Title, nextPages.Count, idx);


			// if no more pages, or next button index out of range, they r at the end of this branch
			if (nextPages.Count == 0 || nextPages.Count <= idx || idx < 0 || null == navigationPage) {
				
				OnEndSequence (args);										// the final state, so call the end handler

			} else {

				// wrap the retrieval in a try/catch, just in case ...
				StateMachinePage nextPage = null;
				try {
					nextPage = nextPages [idx];
				}
				catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine ("{0}.OnNext() - Error: idx={1}, msg={2}", Title, idx, ex.Message);
					nextPage = null;												// so it will call the end handler rather than crash
				}

				if (null == nextPage) {												// aarrrgghhh, no page
					OnEndSequence (args);											// so call the end handler rather than crash
				} else {
					nextPage.OnShow ();												// do anything it needs to do before displaying itself (load data etc)
					navigationPage.PushAsync (nextPage);							// display the page
				}
			}
		}

		protected virtual void OnEndSequence (EventArgs e)
		{
			EventHandler handler = EndHandler;
			if (handler != null) {
				handler (this, e);
			}
		}

		public void OnCancel (object sender, EventArgs e) 
		{
			EventHandler handler = CancelHandler;
			if (handler != null) {
				handler (this, e);
			}
		}

		public virtual void SaveInputData ()
		{
		}

		public virtual void OnShow ()
		{
		}
	}
}

