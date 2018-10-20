using System;

namespace UnitTestProject.Events
{
	public class AgeChangedEventArgs : EventArgs
	{
		public int OldAge { get; set; }
		public int NewAge { get; set; }
	}
}
