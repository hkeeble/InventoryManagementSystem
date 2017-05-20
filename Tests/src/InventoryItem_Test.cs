using System;
using NUnit.Framework;
using InventorySystem;

namespace Tests
{
    [TestFixture]
    public class InventoryItem_Test
    {
        static readonly double TEST_VALUE = 100.0;
        static readonly DateTime TEST_RECEIVED_DATE = DateTime.Today;

        private class InventoryItem_Mock : InventoryItem
        {
            public InventoryItem_Mock(Double value, DateTime receivedDate)
                : base(value, receivedDate)
            { }
        }

        [Test]
        public void TestConstruction()
        {
            InventoryItem_Mock inventoryItem = new InventoryItem_Mock(TEST_VALUE, TEST_RECEIVED_DATE);

            Assert.AreEqual(inventoryItem.Value, 100.0, "Inventory Item Value not set correctly.");
            Assert.AreEqual(inventoryItem.ReceivedDate, TEST_RECEIVED_DATE, "Inventory Item Recieved Date not set correctly.");
        }
    }
}
