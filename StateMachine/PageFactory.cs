using System;
using System.Collections.Generic;

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
		private Dictionary<PageType,Type> _registered = new Dictionary<PageType,Type>();
		private Dictionary<PageType,StateMachinePage> _loaded = new Dictionary<PageType,StateMachinePage>();

		public static StateMachinePage CreatePage(PageType pageType, NavigationPage navPage)
		{
			StateMachinePage page=null;
			switch (pageType) {
			case PageType.ePageA:
				page = new PageA (navPage);	
				break;
			case PageType.ePageB:
				page = new PageB (navPage);
				break;
			case PageType.ePageC:
				page = new PageC (navPage);
				break;
			case PageType.ePageD:
				page = new PageD (navPage);
				break;
			case PageType.ePageE:
				page = new PageE (navPage);
				break;
			case PageType.ePageF:
				page = new PageF (navPage);
				break;
			case PageType.eInvalid:
			default:
				break;
			}

			return page;
		}
			
		/*public void Setup(NavigationPage navPage=null, StateMachineData stateMachineData=null) 
		{
			if ( _registered.Count == 0 ) {
				RegisterAll ();
				Load();
			}

			foreach (var entry in _loaded)
			{
				StateMachinePage page = (StateMachinePage)entry.Value;
				page._bInStateMachine = (null != navPage);
				page._navigationPage = navPage;
				//page._stateMachineData = stateMachineData;
			}
		}

		private void Load()
		{
			foreach (var entry in _registered)
			{
				Type type = (Type)entry.Value;
				StateMachinePage page = (StateMachinePage)Activator.CreateInstance (type);
				_loaded.Add(entry.Key,page);
			}
		}

		private void RegisterAll()
		{
			Register (PageType.ePageA, typeof(PageA));
			Register (PageType.ePageB, typeof(PageB));
			Register (PageType.ePageC, typeof(PageC));
			Register (PageType.ePageD, typeof(PageD));
			Register (PageType.ePageE, typeof(PageE));
			Register (PageType.ePageF, typeof(PageF));
		}

		private void Register(PageType pageType, Type type)
		{
			_registered.Add(pageType, type);
		}*/
	}
	#endregion

}

