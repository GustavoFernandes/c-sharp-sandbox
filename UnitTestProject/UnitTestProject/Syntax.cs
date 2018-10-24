using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathematics = System.Math; // using alias directive

using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert; // using static directive

namespace UnitTestProject
{
	[TestClass] // <- attribute
	public class Syntax // <- test class must be public for test runner to find it
	{
        class Person
        {
            // fields
            private readonly Guid id = Guid.NewGuid(); // readonly can only be initialized in constructor or field initializer
            private string name;

            // properties
            public string Name
            {
                // accessors
                get => name;
                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        name = value;
                    }
                }
            }

            // Auto-implemented property. It doesn't have an associated field.
            public int Height { get; set; }
        }

        [TestMethod]
        public void PersonTest()
        {
            Person alice = new Person
            {
                Name = "Alice"
            };
        }

		[TestMethod]
		public void UsingAliasDirectiveExample()
		{
			AreEqual(16, Mathematics.Pow(4, 2));
		}
	}
}
