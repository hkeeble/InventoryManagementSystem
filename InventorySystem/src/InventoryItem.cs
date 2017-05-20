using System;

namespace InventorySystem
{
    /// <summary>
    /// Base Inventory Item class.
    /// </summary>
    public abstract class InventoryItem
    {
        public DateTime ReceivedDate { get; private set; }
        public Double Value { get; set; }

        /// <summary>
        /// Creates a new Inventory Item.
        /// </summary>
        /// <param name="value">The currency value of the inventory item.</param>
        /// <param name="receivedDate">The date the inventory item was received.</param>
        public InventoryItem(Double value, DateTime receivedDate)
        {
            Value = value;
            ReceivedDate = receivedDate;
        }
    }
}
