using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.Collections;
using System.Collections.Generic;


namespace Capstone.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void Verify_FeedMoney()
        {
			Dictionary<string, List<Item>> test = new Dictionary<string, List<Item>>();
			VendingMachine machine = new VendingMachine(test);

			machine.FeedMoney(1);

			Assert.AreEqual<decimal>(1, machine.Balance);
        }

		[TestMethod]
		public void Verify_FeedMoney_InvalidInput()
		{
			Dictionary<string, List<Item>> test = new Dictionary<string, List<Item>>();
			VendingMachine machine = new VendingMachine(test);

			machine.FeedMoney(1.5m);

			Assert.AreEqual<decimal>(0, machine.Balance);

			machine.FeedMoney(-5);

			Assert.AreEqual<decimal>(0, machine.Balance);
		}

		[TestMethod]
		public void Verify_Vend()
		{
			Dictionary<string, List<Item>> test = new Dictionary<string, List<Item>>();
			test.Add("Test1", new List<Item>() { new GumItem("test", 1m) });

			VendingMachine testMachine = new VendingMachine(test);
			User testUser = new User(new List<Item>());

			testMachine.FeedMoney(1);

			testMachine.Vend("Test1", testUser);

			Assert.AreEqual<int>(0, testMachine.Inventory["Test1"].Count);
			Assert.AreEqual<int>(1, testUser.Cart.Count);
			Assert.AreEqual<decimal>(0, testMachine.Balance);
		}

		[TestMethod]
		public void Verify_ReturnChange_MachineBalance0()
		{
			Dictionary<string, List<Item>> test = new Dictionary<string, List<Item>>();
			VendingMachine testMachine = new VendingMachine(test);
			User testUser = new User(new List<Item>());
			testMachine.FeedMoney(1);

			string testResponse = testMachine.ReturnChange();

			Assert.AreEqual<decimal>(0, testMachine.Balance);
			Assert.AreEqual<string>("Your change is: 4 quarters, 0 dimes, and 0 nickels.", testResponse);
			Assert.AreEqual<int>(0, testUser.Cart.Count);
		}
    }
}
