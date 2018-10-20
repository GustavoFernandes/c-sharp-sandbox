using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject.Events
{
	[TestClass]
	public class Delegates
	{
		#region Introduction

		class Calculator
		{
			public int Add(int a, int b)
			{
				return a + b;
			}
		}

		// a delegate is a type that references methods
		public delegate int Adder(int x, int y);

		[TestMethod]
		public void Introduction()
		{
			Calculator calculator = new Calculator();
			Adder adder = new Adder(calculator.Add);

			Assert.AreEqual(9, calculator.Add(4, 5));
			Assert.AreEqual(9, adder(4, 5));
		}

		#endregion

		#region Name Changed Delegate

		private int nameChangedCounter = 0;

		private void OnNameChanged(string oldName, string newName)
		{
			Assert.AreNotEqual(oldName, newName);
			nameChangedCounter++;
		}

		[TestMethod]
		public void TestNameChangedDelegate()
		{
			Person person = new Person();

			// Person's NameChanged delegate is null which is referenced in the Name setter
			Assert.ThrowsException<NullReferenceException>(() =>
			{
				person.Name = "Alice";
			});

			person.NameChanged = new NameChangedDelegate(OnNameChanged);

			Assert.AreEqual(0, nameChangedCounter);

			person.Name = "Alice";
			Assert.AreEqual(1, nameChangedCounter);

			person.Name = "Bob";
			Assert.AreEqual(2, nameChangedCounter);

			person.Name = "Bob";
			Assert.AreEqual(2, nameChangedCounter);

			person.Name = "Charlie";
			Assert.AreEqual(3, nameChangedCounter);
		}

		#endregion

		#region Age Changed Delegate

		private int ageChangedCounter = 0;
		private int ageChangedCounter2 = 0;

		private void OnAgeChanged(object sender, AgeChangedEventArgs args)
		{
			Assert.IsTrue(sender is Person);

			Assert.AreNotEqual(args.OldAge, args.NewAge);
			ageChangedCounter++;
		}

		private void OnAgeChanged2(object sender, AgeChangedEventArgs args) => ageChangedCounter2++;

		[TestMethod]
		public void TestAgeChangedDelegate()
		{
			Person person = new Person();

			person.AgeChanged += OnAgeChanged; // same as new AgeChangedDelegate(OnAgeChanged)
			person.AgeChanged += OnAgeChanged2;

			Assert.AreEqual(0, ageChangedCounter);

			person.Age = 99;
			Assert.AreEqual(1, ageChangedCounter);

			person.Age = -15;
			Assert.AreEqual(1, ageChangedCounter);

			person.Age = 203;
			Assert.AreEqual(1, ageChangedCounter);

			person.AgeChanged -= OnAgeChanged2;

			person.Age = 20;
			Assert.AreEqual(2, ageChangedCounter);
			Assert.AreEqual(1, ageChangedCounter2);
		}

		#endregion
	}
}
