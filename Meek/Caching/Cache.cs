using System;
using Meek.Caching.Events;
using System.Collections.Generic;

namespace Meek.Caching
{
    public class Cache : ICache, IDisposable
    {

        #region CacheItem
        /// <summary>
        /// CacheItem Object
        /// </summary>
        private class CacheItem
        {
            public object Value { get; set; }

            public DateTime Created { get; set; }

            public DateTime? Expiration { get; set; }
        }
        #endregion

        #region Events
        /// <summary>
        /// Raised when an Item is added to the Cache
        /// </summary>
        public event ItemAdded OnItemAdded;

        /// <summary>
        /// Raised when an Item is deleted from the Cache
        /// </summary>
        public event ItemDeleted OnItemDeleted;
        #endregion

        #region Properties
        
        #region Container
        /// <summary>
        /// CacheItem Container
        /// </summary>
        private Dictionary<string, CacheItem> Container { get; set; }
        #endregion

        #region CacheName
        /// <summary>
        /// Cache Unique Identifier/Name
        /// </summary>
        public string CacheName { get; private set; }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Internal Constructor to restrict creation of instance outside of assembly
        /// </summary>
        /// <param name="cacheName">Unique Cache Name</param>
        internal Cache(string cacheName)
        {
            CacheName = cacheName;
            Container = new Dictionary<string, CacheItem>();
        }
        #endregion

        #region this[key]
        /// <summary>
        /// Get or Sets the Cache Item Value based on an Item Key
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns>object</returns>
        public object this[string key]
        {
            get
            {
                if(Container.ContainsKey(key))
                {
                    var cacheItem = Container[key];

                    if (Equals(cacheItem.Expiration, default(DateTime)))
                        return Container[key].Value;
                    
                    return (DateTime.Now >= cacheItem.Expiration) 
                        ? null
                        : Container[key].Value;
                }
                return null;
            }
            set
            {
                if (!Container.ContainsKey(key))
                {
                    var cacheItem = new CacheItem
                                    {
                                        Value = value,
                                        Created =  DateTime.Now
                                    };

                    Container.Add(key, cacheItem);
                    if(!Equals(OnItemAdded, null))
                        OnItemAdded(this, new ItemAddedEventArgs(key, value));
                }
                else
                    Container[key].Value = value;
            }
        }
        #endregion

        #region GetValue
        /// <summary>
        /// Gets the Value of an Item with the specified Key
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <returns>object</returns>
        public object GetValue(string key)
        {
            return this[key];
        }
        #endregion

        #region Insert/Add
        /// <summary>
        /// Inserts an Item to the Cache identified by a specified Key
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        public void Insert(string key, object value)
        {
            this[key] = value;
        }

        /// <summary>
        /// Inserts an Item to the Cache identified by a specified Key with a given Expiration
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        /// <param name="expiration">Item Expiration</param>
        public void Insert(string key, object value, DateTime expiration)
        {
            if(Container.ContainsKey(key))
                throw new Exception("Item Key already exists.");

            var cacheItem = new CacheItem
                            {
                                Value = value,
                                Created = DateTime.Now,
                                Expiration = expiration
                            };
            Container.Add(key, cacheItem);
            if (!Equals(OnItemAdded, null))
                OnItemAdded(this, new ItemAddedEventArgs(key, value));
        }

        /// <summary>
        /// Adds an Item to the Cache identified by a specified Key
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        /// <returns>object</returns>
        public object Add(string key, object value)
        {
            this[key] = value;
            return this[key];
        }

        /// <summary>
        /// Adds an Item to the Cache identified by a specified Key with a given Expiration
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="value">Item Value</param>
        /// <param name="expiration">Item Expiration</param>
        /// <returns>object</returns>
        public object Add(string key, object value, DateTime expiration)
        {
            if (Container.ContainsKey(key))
                throw new Exception("Item Key already exists.");

            var cacheItem = new CacheItem
                            {
                                Value = value,
                                Created = DateTime.Now,
                                Expiration = expiration
                            };
            Container.Add(key, cacheItem);
            if (!Equals(OnItemAdded, null))
                OnItemAdded(this, new ItemAddedEventArgs(key, value));
            return Container[key].Value;
        }
        #endregion

        #region Remove
        /// <summary>
        /// Removes an Item from the Cache identified by the specified Key
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            if (!Container.ContainsKey(key))
                return;

            var cachedValue = Container[key];
            Container.Remove(key);
            if(!Equals(OnItemDeleted, null))
                OnItemDeleted(this, new ItemDeletedEventArgs(key, cachedValue));
        }
        #endregion

        #region SetExpiration
        /// <summary>
        /// Sets a Cache Item specified by a Key with an Expiration Date
        /// </summary>
        /// <param name="key">Item Key</param>
        /// <param name="expiration">Expiration Date</param>
        public void SetExpiration(string key, DateTime expiration)
        {
            if(!Container.ContainsKey(key))
                return;
            Container[key].Expiration = expiration;
        }
        #endregion

        #region Clear
        /// <summary>
        /// Clear all Cache Values
        /// </summary>
        public void Clear()
        {
            Container.Clear();
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Disposes the Object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                Container = null;
            }
        }
        #endregion
    }
}
