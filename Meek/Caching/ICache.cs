using System;
using Meek.Caching.Events;

namespace Meek.Caching
{
    /// <summary>
    /// Inteface for a Cache Instance
    /// </summary>
    public interface ICache
    {
        #region Events
        /// <summary>
        /// Raised when an Item is added to the Cache
        /// </summary>
        event ItemAdded OnItemAdded;

        /// <summary>
        /// Raised when an Item is deleted from the Cache
        /// </summary>
        event ItemDeleted OnItemDeleted;
        #endregion

        #region CacheName
        /// <summary>
        /// Cache Unique Identifier/Name
        /// </summary>
        string CacheName { get; }
        #endregion

        #region Key
        /// <summary>
        /// Get or Sets the Cache Item Value based on an Item Key
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns>object</returns>
        object this[string key] { get; set; }
        #endregion

        #region GetValue
        /// <summary>
        /// Gets the Value of an Item with the specified Key
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <returns>object</returns>
        object GetValue(string key);
        #endregion

        #region Add
        /// <summary>
        /// Inserts an Item to the Cache identified by a specified Key
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        void Insert(string key, object value);

        /// <summary>
        /// Inserts an Item to the Cache identified by a specified Key with a given Expiration
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        /// <param name="expiration">Item Expiration</param>
        void Insert(string key, object value, DateTime expiration);

        /// <summary>
        /// Adds an Item to the Cache identified by a specified Key
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        /// <returns>object</returns>
        object Add(string key, object value);

        /// <summary>
        /// Adds an Item to the Cache identified by a specified Key with a given Expiration
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        /// <param name="expiration">Item Expiration</param>
        /// <returns>object</returns>
        object Add(string key, object value, DateTime expiration);
        #endregion

        #region Delete
        /// <summary>
        /// Removes an Item from the Cache identified by the specified Key
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
        #endregion

        #region SetExpiration
        /// <summary>
        /// Sets a Cache Item specified by a Key with an Expiration Date
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="expiration">Expiration Date</param>
        void SetExpiration(string key, DateTime expiration);
        #endregion

        #region Clear
        /// <summary>
        /// Clear all Cache Values
        /// </summary>
        void Clear();
        #endregion
    }
}
