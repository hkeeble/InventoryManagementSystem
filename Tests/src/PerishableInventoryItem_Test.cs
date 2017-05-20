using System;
using NUnit.Framework;
using InventorySystem;

namespace Tests
{
    [TestFixture]
    class PerishableInventoryItem_Test
    {
        private class PerishableInventoryItem_Mock : PerishableInventoryItem
        {
            public PerishableInventoryItem_Mock(Double value, DateTime receivedDate, int lifeInDays) :
                base(value, receivedDate, lifeInDays)
            { }
        }

        private static readonly Double TEST_VALUE = 100.0;
        private static readonly int TEST_LIFE_IN_DAYS = 5;
        private static readonly DateTime TEST_RECEIVED_DATE = DateTime.Today;

        private PerishableInventoryItem_Mock TestPerishableItem;
        private PerishableInventoryItem_Mock TestPerishableItemExpired;

        [OneTimeSetUp]
        public void Setup()
        {
            TestPerishableItem = new PerishableInventoryItem_Mock(TEST_VALUE, TEST_RECEIVED_DATE, TEST_LIFE_IN_DAYS);
            TestPerishableItemExpired = new PerishableInventoryItem_Mock(TEST_VALUE, TEST_RECEIVED_DATE.AddDays(-(TEST_LIFE_IN_DAYS + 1)), TEST_LIFE_IN_DAYS);
        }

        [Test]
        public void TestConstruction()
        {
            Assert.AreEqual(TestPerishableItem.Value, 100.0, "Inventory Item Value not set correctly.");
            Assert.AreEqual(TestPerishableItem.ReceivedDate, TEST_RECEIVED_DATE, "Inventory Item Recieved Date not set correctly.");
        }

        [Test]
        public void TestExpirationDate()
        {
            Assert.AreEqual(TestPerishableItem.GetExpirationDate(), TEST_RECEIVED_DATE.AddDays(TEST_LIFE_IN_DAYS), "Expiration date calculation is incorrect.");
        }

        [Test]
        public void TestHasExpired()
        {
            Assert.IsTrue(TestPerishableItemExpired.HasExpired(), "Perishable item should have expired.");
        }
    }
}
