using System;
using System.Collections.Generic;
using System.Threading;

namespace AngbandOS.Core.ExpiringDictionary
{
    /// <summary>
    /// A thread-safe dictionary that stores values with an expiration time.
    /// Any TKey is supported (including tuple types). Expired entries are removed
    /// automatically by a background timer. TryGet is implemented using an
    /// EnterUpgradeableReadLock -> EnterWriteLock pattern to avoid races with the cleanup thread.
    /// This implementation uses a named value-tuple as the entry to avoid heap allocation for the Entry class.
    /// </summary>
    /// <typeparam name="TKey">Key type (must be notnull)</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    public sealed class ExpiringDictionary<TKey, TValue> : IDisposable where TKey : notnull
    {
        private readonly Dictionary<TKey, (TValue Value, DateTimeOffset Expiry)> _dictionary = new Dictionary<TKey, (TValue Value, DateTimeOffset Expiry)>();
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);
        private readonly Timer _cleanupTimer;
        private readonly TimeSpan _defaultTimeToLive;

        /// <summary>
        /// Create an ExpiringDictionary.
        /// </summary>
        /// <param name="defaultTimeToLive">Default TTL used when Set is called without a TTL</param>
        /// <param name="cleanupInterval">How often cleanup runs to remove expired entries (default 60s)</param>
        public ExpiringDictionary(TimeSpan defaultTimeToLive)
        {
            if (defaultTimeToLive <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(defaultTimeToLive), "defaultTimeToLive must be > TimeSpan.Zero");

            _defaultTimeToLive = defaultTimeToLive;

            _cleanupTimer = new Timer(_ => CollectExpired(), null, Timeout.Infinite, Timeout.Infinite);
            ResetTimer();
        }

        private void ResetTimer()
        {
            DateTimeOffset? nextExpiry = null;

            _lock.EnterReadLock();
            try
            {
                foreach (KeyValuePair<TKey, (TValue Value, DateTimeOffset Expiry)> pair in _dictionary)
                {
                    if (nextExpiry is null || pair.Value.Expiry < nextExpiry.Value)
                    {
                        nextExpiry = pair.Value.Expiry;
                    }
                }
            }
            finally
            {
                _lock.ExitReadLock();
            }

            if (nextExpiry is null)
            {
                _cleanupTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            else
            {
                TimeSpan delay = nextExpiry.Value - DateTimeOffset.UtcNow;
                if (delay < TimeSpan.Zero)
                {
                    delay = TimeSpan.Zero;
                }

                _cleanupTimer.Change(delay, Timeout.InfiniteTimeSpan);
            }
        }

        /// <summary>
        /// Add or update a value for the specified key with an explicit TTL (or default TTL when null).
        /// </summary>
        public DateTimeOffset Set(TKey key, TValue value, TimeSpan? ttl = null)
        {
            TimeSpan effectiveTtl = ttl.HasValue && ttl.Value > TimeSpan.Zero ? ttl.Value : _defaultTimeToLive;
            var expiry = DateTimeOffset.UtcNow.Add(effectiveTtl);

            // Acquire write lock to avoid races with TryGet cleanup/upgrades and background cleanup.
            _lock.EnterWriteLock();
            try
            {
                _dictionary[key] = (value, expiry);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
            ResetTimer();
            return expiry;
        }

        /// <summary>
        /// Try to get the value for a key. Returns false for missing or expired entries.  A returned entry may be expired by the time it is returned.  Retrieval of an entry updates its expiration.
        /// </summary>
        public bool TryGet(TKey key, out TValue value, bool allowExpired = false)
        {
            value = default!;
            var now = DateTimeOffset.UtcNow;

            _lock.EnterUpgradeableReadLock();
            try
            {
                if (!_dictionary.TryGetValue(key, out var entry))
                {
                    return false;
                }

                // If expired and not allowed, return false
                if (!allowExpired && now >= entry.Expiry)
                {
                    return false;
                }

                value = entry.Value;

                // Update the expiration.
                _lock.EnterWriteLock();
                try
                {
                    _dictionary[key] = (entry.Value, now.Add(_defaultTimeToLive));
                }
                finally
                {
                    _lock.ExitWriteLock();
                }

                return true;
            }
            finally
            {
                _lock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Try to remove the entry for the specified key.
        /// </summary>
        public bool Remove(TKey key)
        {
            _lock.EnterWriteLock();
            try
            {
                return _dictionary.Remove(key);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Returns whether the dictionary contains the given key and the entry is not expired.
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            return TryGet(key, out _);
        }

        /// <summary>
        /// Number of entries currently stored (may include entries that are about to be removed by cleanup).
        /// </summary>
        public int Count
        {
            get
            {
                _lock.EnterReadLock();
                try
                {
                    return _dictionary.Count;
                }
                finally
                {
                    _lock.ExitReadLock();
                }
            }
        }

        public void CollectExpired()
        {
            List<TKey> expired = new List<TKey>();

            _lock.EnterReadLock();
            try
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;
                foreach (KeyValuePair<TKey, (TValue Value, DateTimeOffset Expiry)> pair in _dictionary)
                {
                    if (pair.Value.Expiry <= now)
                    {
                        expired.Add(pair.Key);
                    }
                }
            }
            finally
            {
                _lock.ExitReadLock();
            }

            if (expired.Count > 0)
            {
                _lock.EnterWriteLock();
                try
                {
                    foreach (TKey key in expired)
                    {
                        _dictionary.Remove(key);
                    }
                }
                finally
                {
                    _lock.ExitWriteLock();
                }
            }
            ResetTimer();
        }

        public void Dispose()
        {
            // We need to stop the timer to ensure it isn't running anymore.  Disposal is required to break the runtime root.
            // Per ChatGPT, call backs may already be queued so we need to wait for them to finish before disposing the timer.
            using var wait = new ManualResetEvent(false);
            _cleanupTimer.Dispose(wait);
            wait.WaitOne();
        }
    }
}
