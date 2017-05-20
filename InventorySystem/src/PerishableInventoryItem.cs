using System;

namespace InventorySystem
{
    /// <summary>
    /// An inventory item that is considered perishable.
    /// </summary>
    public abstract class PerishableInventoryItem : InventoryItem
    {
        /// <summary>
        /// The life in days of this perishable from it's received date until it expires.
        /// </summary>
        public int LifeInDays { get; private set; }

        /// <summary>
        /// Creates a new Perishable Inventory Item.
        /// </summary>
        /// <param name="value">The currency value of this perishable inventory item.</param>
        /// <param name="receivedDate">The received date of this perishable inventory item.</param>
        /// <param name="lifeInDays">The life in days from the received date of this perishable item.</param>
        public PerishableInventoryItem(Double value, DateTime receivedDate, int lifeInDays) 
            : base(value, receivedDate)
        {
            LifeInDays = lifeInDays;
        }


        /// <summary>
        /// Get the expiration date for this perishable item.
        /// </summary>
        /// <returns>The date that this perishable item expires.</returns>
        public DateTime GetExpirationDate()
        {
            return ReceivedDate.AddDays(LifeInDays);
        }

        /// <summary>
        /// Check if this perishable item has expired.
        /// </summary>
        /// <returns>Returns true if the item has expired.</returns>
        public bool HasExpired()
        {
            return (GetExpirationDate().CompareTo(DateTime.Now) < 0);
        }
    }
}
