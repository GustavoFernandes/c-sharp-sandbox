using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathematics = System.Math; // using alias directive

using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert; // using static Directive

namespace UnitTestProject
{
	[TestClass] // <- attributes
	public class Syntax // <- test class must be public for test runner to find it
	{
		[TestMethod]
		public void UsingAliasDirectiveExample()
		{
			AreEqual(16, Mathematics.Pow(4, 2));
		}
	}
}
