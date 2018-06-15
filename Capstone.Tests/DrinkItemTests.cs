using System;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class DrinkItemTests
	{
		[TestMethod]
		public void Verify_DrinkItem_MakesSound()
		{
			DrinkItem testDrink = new DrinkItem("test", 1);

			string testSound = testDrink.MakeSound();

			Assert.AreEqual("Glug Glug, Yum!", testSound);
		}
	}
}
