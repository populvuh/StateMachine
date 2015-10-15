using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace StateMachineTest
{
	public enum PageType
	{
		eInvalid,
		ePageA,
		ePageB,
		ePageC,
		ePageD,
		ePageE,
		ePageF
	};

	#region PageFactory
	public class PageFactory
	{

		public static StateMachinePage CreatePage(PageType pageType, NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel)
		{
			StateMachinePage page=null;
			switch (pageType) {
			case PageType.ePageA:
				page = new PageA (navPage, stateMachineData, HandleSequenceEnd, HandleCancel);	
				break;
			case PageType.ePageB:
				page = new PageB (navPage, stateMachineData, HandleSequenceEnd, HandleCancel);
				break;
			case PageType.ePageC:
				page = new PageC (navPage, stateMachineData, HandleSequenceEnd, HandleCancel);
				break;
			case PageType.ePageD:
				page = new PageD (navPage, stateMachineData, HandleSequenceEnd, HandleCancel);
				break;
			case PageType.ePageE:
				page = new PageE (navPage, stateMachineData, HandleSequenceEnd, HandleCancel);
				break;
			case PageType.ePageF:
				page = new PageF (navPage, stateMachineData, HandleSequenceEnd, HandleCancel);
				break;
			case PageType.eInvalid:
			default:
				System.Diagnostics.Debug.WriteLine ("PageFactory.CreatePage() - Error: invalid page type - {0} ", pageType);
				break;
			}

			return page;
		}			
	}
	#endregion

}

