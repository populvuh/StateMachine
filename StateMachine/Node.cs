using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StateMachineTest
{
	public class Node 
	{
		public PageType pageType { get; set; }
		private List<Node> _nextPages = new List<Node> ();

		public Node( PageType p )
		{
			pageType = p;
		}

		// create a new node, and then add it to the nextPages list
		public Node Add( PageType p ) {
			Node node = new Node(p);
			_nextPages.Add (node);

			return node;
		}

		// add an existing node to the nextPages list
		public Node Add( Node n ) {
			_nextPages.Add (n);

			return n;
		}


		// recurse over the tree of pages, creating the next page, adding it to the the current page, 
		// and then passing in the next page to be used as the current
		public void CreatePages( StateMachinePage currPage, NavigationPage navPage, StateMachineData stateMachineData, EventHandler HandleSequenceEnd, EventHandler HandleCancel ) {
			System.Diagnostics.Debug.WriteLine ("Node.CreatePages( {0} )", currPage.Title);

			// iter over the list of next pages (usually only 1, but sometimes more)
			foreach (Node node in _nextPages) {
				System.Diagnostics.Debug.WriteLine ("foreach {0}", node.pageType);

				StateMachinePage nextPage = PageFactory.CreatePage (node.pageType, navPage, stateMachineData, HandleSequenceEnd, HandleCancel);		// create page
				currPage.AddNext (nextPage);														// add to current pages nextpages list

				node.CreatePages (nextPage, navPage, stateMachineData, HandleSequenceEnd, HandleCancel);												// recurse to next level, and repeat
			}

			System.Diagnostics.Debug.WriteLine ("Node.CreatePages( {0} ) Fin", currPage.Title);
		}
	}
}

