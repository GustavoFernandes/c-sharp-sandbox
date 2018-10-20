namespace UnitTestProject.Events
{
	class Person
	{
		#region Name

		public NameChangedDelegate NameChanged;

		private string name;

		public string Name
		{
			get => name;
			set
			{
				if (name != value) // if new value is different than current name
				{
					NameChanged(name, value);
					name = value;
				}
			}
		}

		#endregion

		#region Age

		/*
		 * Use events to prevent the subscriber list from being reassigned (i.e. AgeChanged = null)
		 * This only allows for += and -= to be used.
		 */
		public event AgeChangedDelegate AgeChanged;

		private int age;

		public int Age
		{
			get => age;
			set
			{
				if (AgeChanged != null) // need a null-check to make sure there are subscribers
				{
					if (age != value && value > 0 && value < 100)
					{
						AgeChanged(this, new AgeChangedEventArgs
						{
							OldAge = age,
							NewAge = value
						});

						age = value;
					}
				}
			}
		}

		#endregion
	}
}
