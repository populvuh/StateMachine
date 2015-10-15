using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace StateMachineTest
{
	public static class AttachedProperties
	{
		//public AttachedProperties ()
		//{}

		/// <summary>
		/// Determines the state machine entry index
		/// </summary>
		public static BindableProperty IndexProperty =
			BindableProperty.CreateAttached(
				propertyName: "Index", 
				returnType: typeof(int), 
				declaringType: typeof(Button), 
				defaultValue: -0);


		public static BindableProperty TestStringProperty = 
			BindableProperty.CreateAttached(
				propertyName: "TestString",
				returnType: typeof(string),
				declaringType: typeof(Button),
				defaultValue: string.Empty);

	}
}

