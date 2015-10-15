using System;

namespace StateMachineTest
{
	public class SequenceResults
	{
		public bool OK { get; private set; }
		public bool Canceled { get; private set; }

		public SequenceResults(bool OK)
		{
			this.OK = OK;
			Canceled = !OK;
		}
	}
}

