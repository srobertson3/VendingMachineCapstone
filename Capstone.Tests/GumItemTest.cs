using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace Capstone.Tests
{
	[TestClass]
	public class GumItemTest
	{
		[TestMethod]
		public void Verify_GumItem_MakeSound()
		{
			GumItem testGum = new GumItem("test", 1);

			string testSound = testGum.MakeSound();

			Assert.AreEqual("Chew Chew, Yum!", testSound);
		}
	}
}
