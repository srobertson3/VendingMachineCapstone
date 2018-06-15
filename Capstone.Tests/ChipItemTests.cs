using System;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests
{
	[TestClass]
	public class ChipItemTests
	{
		[TestMethod]
		public void Verify_ChipItem_MakeSound()
		{
			ChipItem testChip = new ChipItem("test", 1);

			string testSound = testChip.MakeSound();

			Assert.AreEqual("Crunch Crunch, Yum!", testSound);
		}
	}
}
