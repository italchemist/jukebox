﻿
namespace Jukebox.Tests {
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	
	/// <summary>
	///This is a test class for PropertiesTest and is intended
	///to contain all PropertiesTest Unit Tests
	///</summary>
	[TestClass] public class PropertiesTest {
		/// <summary>SetValue should set value of variable, get should return value of variable.</summary>
		[TestMethod] public void SetShouldSetValueOfVariableTest() {
			const string name = "variableName";
			const string value = "variableValue";
			var target = new Properties();
			target.SetValue(name, value);
			var actual = target.GetValue(name);
			Assert.AreEqual(value, actual);
		}

		/// <summary>get should return null if no variable found.</summary>
		[TestMethod] public void GetShouldReturnNullIfNoVariableFoundTest() {
			var target = new Properties();
			Assert.IsNull(target.GetValue("no_variable_found"));
		}
	}
}
