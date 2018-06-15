using System;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class CandyItemTests
	{
		[TestMethod]
		public void Verify_CandyItem_MakeSound()
		{
			CandyItem testCandy = new CandyItem("test", 1);

			string testSound = testCandy.MakeSound();

			Assert.AreEqual("Munch Munch, Yum!", testSound);
		}
	}
}
