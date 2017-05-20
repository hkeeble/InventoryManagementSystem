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
        /// The expiration date of this perishable.
        /// </summary>
        public DateTime ExpirationDate
        {
            get
            {
                if(ExpirationDate == null)
                {
                    ExpirationDate = ReceivedDate.AddDays(LifeInDays);
                }
                return ExpirationDate;
            }
            private set { ExpirationDate = value; }
        }
        
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
        /// Whether or not this perishable has expired.
        /// </summary>
        /// <returns>Returns true if the perishable has expired.</returns>
        public bool HasExpired()
        {
            return (ExpirationDate.CompareTo(DateTime.Now) < 0);
        }
    }
}
